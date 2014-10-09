using System;
using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
//using System.Windows.Documents;
//using System.Windows.Input;
//using System.Windows.Media;
//using System.Windows.Media.Imaging;
//using System.Windows.Navigation;
//using System.Windows.Shapes;

using System.Data;
using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Collections.ObjectModel;

namespace ESKDClassifier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public string pathFileXML = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData) + "\\ESKDClassifier\\ESKDClassifier.xml";
        ESKDClass eskdClass;
        List<ESKDClass> Classifier;



        private void LoadData()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        }


        public MainWindow()
        {
            InitializeComponent();

            Classifier = new List<ESKDClass>();

           
            //ESKDClass root = new ESKDClass();
            //root.CodESKD = "42";
            //root.Description = "устройства и системы контроля и регулирования парамметрами технолоогического процесса";

            //ESKDClass child = new ESKDClass();
            //child.CodESKD = "421111";
            //child.Description = "устройства и системы контроля и регулирования параметров технологических процессов электрические, преобразователи пневмоэлектрические, аналоговые, постоянного тока ";

            //root.eskdViews.Add(child);

            //Classifier.Add(root);
            //Classifier.Add(new ESKDClass() { CodESKD = "75", Description = "детали-тела вращения" });
            //Classifier.Add(new ESKDClass() { CodESKD = "74", Description = "детали-не тела вращения" });

            
           
            ////создаём файл сериализации
            //FileStream fsout = new FileStream(pathFileXML, FileMode.Create, FileAccess.Write);
            //XmlSerializer serializerout = new XmlSerializer(typeof(List<ESKDClass>), new Type[] { typeof(ESKDClass) });
            //serializerout.Serialize(fsout, Classifier);
            //fsout.Close();

            //загрузка данных
            FileStream fsin = new FileStream(pathFileXML, FileMode.Open, FileAccess.Read);
            XmlSerializer serializerin = new XmlSerializer(typeof(List<ESKDClass>), new Type[] { typeof(ESKDClass) });
            Classifier = (List<ESKDClass>)serializerin.Deserialize(fsin);
            fsin.Close();

            ESKDListView.ItemsSource = Classifier;
            ESKDTree.ItemsSource = Classifier;

        }

        private TreeViewItem selectedItem = null;

        private void AddClass_Click(object sender, RoutedEventArgs e)
        {
            AddClassifier addClass = new AddClassifier();
            addClass.ShowDialog();
            eskdClass = addClass.GetClassifier();

            if (selectedItem == null)
            {
                Classifier.Add(eskdClass);
            }
            else
            {
                ESKDClass parentclass = selectedItem.DataContext as ESKDClass;
                parentclass.eskdViews.Add(eskdClass);
            }
            ESKDTree.Items.Refresh();

            //SaveToXml(collectionClassifier);

            
        }

        private void DelClass_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ESKDTree_ItemChange(object sender, RoutedPropertyChangedEventArgs<object> e)
        {
            
        }


        private void ESKDTree_Selected_Item(object sender, RoutedEventArgs e)
        {
            var item = e.OriginalSource as TreeViewItem;
            if (item != null)
            {
                //item.SetValue(TreeViewItem.IsSelectedProperty, true);
                selectedItem = item;
            }
        }
    }
}
