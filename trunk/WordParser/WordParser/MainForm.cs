using System;
using System.Threading;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Net;
using System.IO;


using Microsoft.Office.Interop;
using Microsoft.Office.Interop.Word;
using Word = Microsoft.Office.Interop.Word;


namespace WordParser
{
    public partial class MainForm : Form
    {
        string Str, DocPath;
        string pathapp = System.Windows.Forms.Application.StartupPath;
        private OleDbConnection conn;
        private Word.Application wordapp;
        //private Word.Documents worddocuments;
        private Word.Document worddocument, newdocument;

        private Word.Paragraphs wordparagraphs, newParagraphs;
        private Word.Paragraph wordparagraph, newParagraph;
        //private Word.Words pWords;


        bool NPDict, Tran;
        List<string> wordslist;
        List<string> Dict;
        //List<char> c;

        public MainForm()
        {
            InitializeComponent();

            //с = new List<char>();
            
            
            this.backgroundWorker.WorkerReportsProgress = true;
			this.backgroundWorker.WorkerSupportsCancellation = true;
			this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
			this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
			this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);


            //if (File.Exists(dbFilename))
           // {
            //}


            string commandText = "SELECT word FROM Words";
            string ConnectionString = @"Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=" + pathapp + "\\words.accdb"; 
            wordslist = new List<string>();
			try{
			 conn = new OleDbConnection();
             conn.ConnectionString = ConnectionString;
             conn.Open();
             OleDbCommand myCommand = conn.CreateCommand();
             myCommand.CommandText = commandText;
             OleDbDataReader dataReader = myCommand.ExecuteReader();
             while (dataReader.Read())
             {
                 wordslist.Add(dataReader["word"].ToString());
                 //Console.WriteLine(dataReader["word"]);
             }

             commandText = "SELECT COUNT (*) FROM Words";
             OleDbCommand myCommand2 = conn.CreateCommand();
             myCommand2.CommandText = commandText;
             //myCommand.ExecuteScalar();
             CountWordsLabel.Text = Convert.ToString(myCommand2.ExecuteScalar());
             conn.Close();

            
			}
			catch(Exception ex){
				MessageBox.Show("Ошибка подключения к База данных: " + ex.Message, "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
				
			}
		}

        
        void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)

        {

            //for (int i = 1; i < 100; i++)

            //{

                //if (backgroundWorker.CancellationPending)

                    //  return;

                 //Thread.Sleep(1000);

                 //backgroundWorker.ReportProgress(i);

            //}
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
            //progressBar2.Value = e.ProgressPercentage;

        }

        void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)

        {

            // MessageBox.Show(this, "Hello word!!!");

        }

        private void openDoc_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Текстовый файл (*.txt)|*.txt|Файлы Microsoft Word (*.doc; *.docx)|*.doc;*.docx";
            if (dlg.ShowDialog() != DialogResult.OK)
                return;
            DocPath = dlg.FileName;

            NPDict = NotParDict.Checked;
            Tran = checkTransl.Checked;
            labelFileName.Text = DocPath;
            
            backgroundWorker.RunWorkerAsync();
            
            //WordParsing(progressBar1, progressBar2);


            /*
            Thread t = new Thread(delegate()
                        {
                            WordParsing(progressBar2);
                        });
            t.Start();
            */


        }

        private void Parsing()
        {
        	string e = Path.GetExtension(DocPath);
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
        	string [] str;
        	str = File.ReadAllLines(DocPath);
        	int i = 0;
			try
			{
  				// read from file or write to file
  				//str.Count
  				Dict = new List<string>();
  				Dict.Clear();
  				bool FindInDict = false;
  				bool FindInWordList = false;
  				string strSaveInDict = String.Empty;
  				foreach (string s in str)
  				{
  					string [] split = s.Split(new Char [] {' ', ',', '.', ':', '\t' });

  					foreach (string s2 in split)
  					{
  						if (s2 == "" || s2 == " " || s2.Length <= 3) break;
  						strSaveInDict = s2;
  						strSaveInDict = strSaveInDict.Trim(); // убрать пробелы
                        strSaveInDict = strSaveInDict.ToLower();
  						foreach (string find in Dict)
  						{
  							if (strSaveInDict == find) FindInDict = true; 
  						}
  						if (!FindInDict)
  						{							
  							
                            foreach (string word in wordslist)
                            {
                            	if (word == strSaveInDict) 
                            		FindInWordList = true;
                            }
                            if (FindInWordList == false)
  								Dict.Add(strSaveInDict);
                            FindInWordList = false;
							i++;  							
  						}
  						FindInDict = false;
  					}
  					
  					
  				}
  				FileInfo t = new FileInfo(Path.GetDirectoryName(DocPath) + @"Dict.txt");
  				StreamWriter Tex = t.CreateText();
  				foreach (string word in Dict)
  				{
					Tex.WriteLine(word);
  				}
				Tex.Close();
				backgroundWorker.ReportProgress(100, 1);
                backgroundWorker.ReportProgress(100, 2);
				MessageBox.Show("Выполненно! Слов добавленно: " + i.ToString(), "Готово!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
  				
			}
			catch(Exception ex)
            {
                MessageBox.Show("Ошибка при работе с Текстовым файлом:" +  ex.Message, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }
        private void WordParsing()
        {
        	try
            {
                wordapp = new Word.Application();
                wordapp.Visible = true;
                Object filename = DocPath;
                Object confirmConversions = true;
                Object readOnly = false;
                Object addToRecentFiles = true;
                Object passwordDocument = Type.Missing;
                Object passwordTemplate = Type.Missing;
                Object revert = false;
                Object writePasswordDocument = Type.Missing;
                Object writePasswordTemplate = Type.Missing;
                Object format = Type.Missing;
                Object encoding = Type.Missing; ;
                Object oVisible = Type.Missing;
                Object openConflictDocument = Type.Missing;
                Object openAndRepair = Type.Missing;
                Object documentDirection = Type.Missing;
                Object noEncodingDialog = false;
                Object xmlTransform = Type.Missing;

                worddocument = wordapp.Documents.Open(ref filename,
                ref confirmConversions, ref readOnly, ref addToRecentFiles,
                ref passwordDocument, ref passwordTemplate, ref revert,
                ref writePasswordDocument, ref writePasswordTemplate,
                ref format, ref encoding, ref oVisible,
                ref openAndRepair, ref documentDirection, ref noEncodingDialog, ref xmlTransform);

                wordparagraphs = worddocument.Paragraphs;


                Object template = Type.Missing;
                //Object template = pathapp + @"template.docx";
                Object newTemplate = false;
                Object documentType = Word.WdNewDocumentType.wdNewBlankDocument;
                Object visible = true;
                newdocument = wordapp.Documents.Add(ref template, ref newTemplate, ref documentType, ref visible);
                newParagraphs = newdocument.Paragraphs;

                object oMissing = System.Reflection.Missing.Value;
                int g = 1;
                int m = wordparagraphs.Count;

                Dict = new List<string>();
       

                for (int i = 1; i < m; i++)
                {
                    wordparagraph = wordparagraphs[i];
                    Str = wordparagraph.Range.Text;
                    int n = wordparagraph.Range.Words.Count;
                    //progBar2.Value = 0;
                    //progBar2.Maximum = n;
                    if (!NPDict)
                    {
                        g++;
                        Dict.Clear();
                        newdocument.Paragraphs.Add(ref oMissing);
                        newParagraph = newParagraphs[g];
                        newParagraph.Range.Font.Bold = 1;
                        newParagraph.Range.Text = " ------------ " + i.ToString() + " -------------- ";
                    }
                    


                    for (int j = 1; j < n; j++)
                    {
                        bool found = false;
                        Str = wordparagraph.Range.Words[j].Text;
                        Str = Str.Trim();;
                        Str = Str.ToLower();
                        //Str.Length
                        foreach (string st in wordslist)
                        {
                            string st1;
                            st1 = st.Trim(); // убрать пробелы
                            st1 = st.ToLower();//в нижний регистр
                            if (( Str == st1) || (Str == "") ) found = true;
                        }
                        if (!found)
                        {              
                            bool diff = false;
                            if (Dict.Count > 0)
                            {
                                foreach (string s in Dict)
                                {
                                     if (Str == s) diff = true;
                                }
                            }
                            if (!diff)
                            {
                                g++;
                                Dict.Add(Str);
                                newdocument.Paragraphs.Add(ref oMissing);
                                newParagraph = newParagraphs[g];
                                newParagraph.Range.Font.Bold = 0;
                                if (Tran) newParagraph.Range.Text = Str + " - " + TranslateStr(Str);
                                else newParagraph.Range.Text = Str;
                            }
                        }
                        double proc1 = ((j * 100) / n);
                        backgroundWorker.ReportProgress((int)Math.Ceiling(proc1), 2);
                        //progBar2.Value = j;
                        //MessageBox.Show(Str);
                    }
                    double proc2 = ((i * 100) / m);
                    backgroundWorker.ReportProgress((int)Math.Ceiling(proc2), 1);
                    //progBar1.Value = i;
                    //MessageBox.Show(Str);
                }
                Dict.Clear();
                backgroundWorker.ReportProgress(100, 1);
                backgroundWorker.ReportProgress(100, 2);
                //Str = Convert.ToString(wordparagraphs.Count);
                //MessageBox.Show(Str);
                
            }

            catch (Exception ex)
            {
                Str = ex.Message;
                MessageBox.Show("Ошибка при работе с MS Word:" + Str, "Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CloseForm_Click(object sender, EventArgs e)
        {
            //this.backgroundWorker.CancelAsync();
            Close();
        }

        private void AddWorkInDict_Click(object sender, EventArgs e)
        {
            bool addword = true;
            string Str = WorkInDict.Text;
            if (Str == "") return;
            OleDbCommand myCommand;
            OleDbDataReader dataReader;
            Str = Str.Trim(); ;
            Str = Str.ToLower();
            string commandText = "SELECT word FROM Words WHERE word = \'" + Str + "\'";
            try{
             conn.Open();
             myCommand = conn.CreateCommand();
             myCommand.CommandText = commandText;
             dataReader = myCommand.ExecuteReader();
             while (dataReader.Read())
             {
                 if (Str == dataReader["word"].ToString())
                 {
                     MessageBox.Show("Такое слово уже есть в базе", "Слово найдено",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                     addword = false;

                 }
                 //Console.WriteLine(dataReader["word"]);
             }

             if (addword)
             {
                 commandText = "INSERT INTO Words (word) VALUES (\'" + Str + "\')";
                 myCommand = conn.CreateCommand();
                 myCommand.CommandText = commandText;
                 myCommand.ExecuteNonQuery();
                 StatusWord.Text = Str;
                 WorkInDict.Text = "";
             }
              conn.Close();

            
			}
			catch{
				MessageBox.Show("Ошибка подключения к База данных", "Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
				
			}

        }

        private void checkTopWindow_CheckedChanged(object sender, EventArgs e)
        {
            this.TopMost = checkTopWindow.Checked;
        }

        private string TranslateStr(string Str)
        {
            //Str = @"can";
            string URI = @"http://lingvo.yandex.ru/" + Str + @"/с английского/";
            string GetHTML, Transl;
            Transl = "";

            bool b = true;
            try
            {
                WebClient client = new WebClient();
                byte[] response = client.DownloadData(URI);
                GetHTML = Encoding.UTF8.GetString(response);

                int result = GetHTML.IndexOf("<strong>1)</strong>");
                result = result + 29;
                
                while (b)
                {
                    result++;
                    if (GetHTML[result] == '/')
                        b = false;
                    else
                        Transl += GetHTML[result].ToString();
                }
                
                
   
                //MessageBox.Show(test1, "Тест");
                //x = String.Compare(GetHTML, );
                //x = x + 11;
                //test1.CopyTo(x, GetHTML.ToCharArray(), 0, 15);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!");
            }
            return Transl;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (WorkInDict.Text != "") MessageBox.Show(TranslateStr(WorkInDict.Text), "Translate");
        }
    }

}
