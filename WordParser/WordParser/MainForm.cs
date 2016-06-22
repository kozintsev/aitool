using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Net;
using System.IO;
using Word = Microsoft.Office.Interop.Word;


namespace WordParser
{
    public partial class MainForm : Form
    {
        private int _n;
        private string _str, _docPath;
        private readonly string _pathapp = Application.StartupPath;
        private readonly SQLiteConnection _connLite;
        private Word.Application _wordapp;

        private Word.Document _worddocument, _newdocument;
        private Word.Paragraphs _wordparagraphs, _newParagraphs;
        private Word.Paragraph _wordparagraph, _newParagraph;


        private bool _npDict, _tran;
        private readonly List<string> _wordslist; // словарь известных слов
        private List<string> _dict; // формирующийся словарь

        public MainForm()
        {
            InitializeComponent();
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.RunWorkerCompleted += backgroundWorker_RunWorkerCompleted;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            _n = 0;
            _wordslist = new List<string>();
            var commandText = "SELECT word FROM Words";
            var filedb = _pathapp + "\\words.sqlite";
            if (!File.Exists(filedb))
            {
                MessageBox.Show(@"Отсутствует файл базы данных!", @"Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            var dbConnection = string.Format("Data Source={0}", filedb);
            try
            {

                _connLite = new SQLiteConnection(dbConnection);
                _connLite.Open();
                var comm = _connLite.CreateCommand();
                comm.CommandText = commandText;
                var liteRead = comm.ExecuteReader();
                while (liteRead.Read())
                {
                    _wordslist.Add(liteRead["word"].ToString());
                }

                commandText = "SELECT COUNT (*) FROM Words";
                var myCommand2 = _connLite.CreateCommand();
                myCommand2.CommandText = commandText;
                _n = Convert.ToInt32(myCommand2.ExecuteScalar());
                CountWordsLabel.Text = Convert.ToString(myCommand2.ExecuteScalar());
                _connLite.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Ошибка подключения к База данных: " + ex.Message, @"Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Parsing();
        }

        void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {

            switch (e.UserState.ToString())
            {
                case "1":
                    progressBar1.Value = e.ProgressPercentage;
                    break;
                case "2":
                    progressBar2.Value = e.ProgressPercentage;
                    break;

            }
        }

        static void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
        }

        private void openDoc_Click(object sender, EventArgs e)
        {
            var dlg = new OpenFileDialog
            {
                Filter = @"Текстовый файл (*.txt)|*.txt|Файлы Microsoft Word (*.doc; *.docx)|*.doc;*.docx"
            };
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            _docPath = dlg.FileName;

            _npDict = NotParDict.Checked;
            _tran = checkTransl.Checked;
            labelFileName.Text = _docPath;

            backgroundWorker.RunWorkerAsync();
        }

        private void Parsing()
        {
            var e = Path.GetExtension(_docPath);
            switch (e)
            {
                case ".txt":
                    TextParsing();
                    break;
                case ".doc":
                    WordParsing();
                    break;
                case ".docx":
                    WordParsing();
                    break;
            }
        }

        private void TextParsing()
        {
            var str = File.ReadAllLines(_docPath);
            int w = 0, i = 0;
            try
            {
                _dict = new List<string>();
                _dict.Clear();
                var findInDict = false;
                var findInWordList = false;
                var m = str.Length;
                if (m == 0) return;
                foreach (var s in str)
                {
                    var split = s.Split(' ', ',', '.', ':', '\t');
                    var n = split.Length;
                    if (n == 0) continue;
                    var j = 0;
                    foreach (var s2 in split)
                    {
                        if (s2 == "" || s2 == " " || s2.Length <= 3) break;
                        var strSaveInDict = s2;
                        strSaveInDict = strSaveInDict.Trim(); 
                        strSaveInDict = strSaveInDict.ToLower();
                        foreach (var find in _dict)
                        {
                            if (strSaveInDict == find) findInDict = true;
                        }
                        if (!findInDict)
                        {

                            foreach (var word in _wordslist)
                            {
                                if (word == strSaveInDict)
                                    findInWordList = true;
                            }
                            if (findInWordList == false)
                                _dict.Add(strSaveInDict);
                            findInWordList = false;
                            w++;
                        }
                        findInDict = false;
                        j++;
                        double proc1 = ((100 * j) / n);
                        backgroundWorker.ReportProgress((int)Math.Ceiling(proc1), 1);
                    }
                    i++;
                    double proc2 = ((100 * i) / m);
                    backgroundWorker.ReportProgress((int)Math.Ceiling(proc2), 2);
                }
                var t = new FileInfo(Path.GetDirectoryName(_docPath) + @"Dict.txt");
                var tex = t.CreateText();
                foreach (var word in _dict)
                {
                    tex.WriteLine(word);
                }
                tex.Close();
                backgroundWorker.ReportProgress(100, 1);
                backgroundWorker.ReportProgress(100, 2);
                MessageBox.Show(@"Выполненно! Слов добавленно: " + w, @"Готово!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {
                MessageBox.Show(@"Ошибка при работе с Текстовым файлом:" + ex.Message, @"Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void WordParsing()
        {
            try
            {
                _wordapp = new Word.Application {Visible = true};
                object filename = _docPath;
                object confirmConversions = true;
                object readOnly = false;
                object addToRecentFiles = true;
                var passwordDocument = Type.Missing;
                var passwordTemplate = Type.Missing;
                object revert = false;
                var writePasswordDocument = Type.Missing;
                var writePasswordTemplate = Type.Missing;
                var format = Type.Missing;
                var encoding = Type.Missing; ;
                var oVisible = Type.Missing;
                var openAndRepair = Type.Missing;
                var documentDirection = Type.Missing;
                object noEncodingDialog = false;
                var xmlTransform = Type.Missing;

                _worddocument = _wordapp.Documents.Open(ref filename,
                ref confirmConversions, ref readOnly, ref addToRecentFiles,
                ref passwordDocument, ref passwordTemplate, ref revert,
                ref writePasswordDocument, ref writePasswordTemplate,
                ref format, ref encoding, ref oVisible,
                ref openAndRepair, ref documentDirection, ref noEncodingDialog, ref xmlTransform);

                _wordparagraphs = _worddocument.Paragraphs;


                var template = Type.Missing;
                object newTemplate = false;
                object documentType = Word.WdNewDocumentType.wdNewBlankDocument;
                object visible = true;
                _newdocument = _wordapp.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);
                _newParagraphs = _newdocument.Paragraphs;

                object oMissing = System.Reflection.Missing.Value;
                var g = 1;
                var m = _wordparagraphs.Count;

                _dict = new List<string>();


                for (var i = 1; i < m; i++)
                {
                    _wordparagraph = _wordparagraphs[i];
                    _str = _wordparagraph.Range.Text;
                    var n = _wordparagraph.Range.Words.Count;
                    if (!_npDict)
                    {
                        g++;
                        _dict.Clear();
                        _newdocument.Paragraphs.Add(ref oMissing);
                        _newParagraph = _newParagraphs[g];
                        _newParagraph.Range.Font.Bold = 1;
                        _newParagraph.Range.Text = " ------------ " + i + " -------------- ";
                    }



                    for (var j = 1; j < n; j++)
                    {
                        var found = false;
                        _str = _wordparagraph.Range.Words[j].Text;
                        _str = _str.Trim(); ;
                        _str = _str.ToLower();
                        foreach (var st in _wordslist)
                        {
                            var st1 = st.Trim().ToLower();
                            if ((_str == st1) || (_str == "")) found = true;
                        }
                        if (!found)
                        {
                            var diff = false;
                            if (_dict.Count > 0)
                            {
                                foreach (var s in _dict)
                                {
                                    if (_str == s) diff = true;
                                }
                            }
                            if (!diff)
                            {
                                g++;
                                _dict.Add(_str);
                                _newdocument.Paragraphs.Add(ref oMissing);
                                _newParagraph = _newParagraphs[g];
                                _newParagraph.Range.Font.Bold = 0;
                                if (_tran) _newParagraph.Range.Text = _str + " - " + TranslateStr(_str);
                                else _newParagraph.Range.Text = _str;
                            }
                        }
                        double proc1 = ((j * 100) / n);
                        backgroundWorker.ReportProgress((int)Math.Ceiling(proc1), 2);
                    }
                    double proc2 = ((i * 100) / m);
                    backgroundWorker.ReportProgress((int)Math.Ceiling(proc2), 1);
                }
                _dict.Clear();
                backgroundWorker.ReportProgress(100, 1);
                backgroundWorker.ReportProgress(100, 2);
            }

            catch (Exception ex)
            {
                _str = ex.Message;
                MessageBox.Show(@"Ошибка при работе с MS Word:" + _str, @"Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddWorkInDict_Click(object sender, EventArgs e)
        {
            var addword = true;
            var str = WorkInDict.Text;
            if (str == "") return;
            str = str.Trim(); ;
            str = str.ToLower();
            var commandText = "SELECT word FROM Words WHERE word = \'" + str + "\'";
            try
            {
                _connLite.Open();
                var myCommand = _connLite.CreateCommand();
                myCommand.CommandText = commandText;
                var dataReader = myCommand.ExecuteReader();
                while (dataReader.Read())
                {
                    if (str != dataReader["word"].ToString()) continue;
                    MessageBox.Show(@"Такое слово уже есть в базе", @"Слово найдено",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    addword = false;
                }

                if (addword)
                {
                    commandText = "INSERT INTO Words (word) VALUES (\'" + str + "\')";
                    myCommand = _connLite.CreateCommand();
                    myCommand.CommandText = commandText;
                    myCommand.ExecuteNonQuery();
                    StatusWord.Text = str;
                    WorkInDict.Text = "";
                    CountWordsLabel.Text = "";
                    _n++;
                    CountWordsLabel.Text = Convert.ToString(_n);
                }
                _connLite.Close();
            }
            catch
            {
                MessageBox.Show(@"Ошибка подключения к База данных", @"Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void checkTopWindow_CheckedChanged(object sender, EventArgs e)
        {
            TopMost = checkTopWindow.Checked;
        }

        private static string TranslateStr(string str)
        {
            var uri = @"http://lingvo.yandex.ru/" + str + @"/с английского/";
            var transl = "";

            var b = true;
            try
            {
                var client = new WebClient();
                var response = client.DownloadData(uri);
                var getHtml = Encoding.UTF8.GetString(response);

                var result = getHtml.IndexOf("<strong>1)</strong>", StringComparison.Ordinal);
                result = result + 29;

                while (b)
                {
                    result++;
                    if (getHtml[result] == '/')
                        b = false;
                    else
                        transl += getHtml[result].ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, @"Error!");
            }
            return transl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (WorkInDict.Text != "") MessageBox.Show(TranslateStr(WorkInDict.Text), @"Translate");
        }

    }

}
