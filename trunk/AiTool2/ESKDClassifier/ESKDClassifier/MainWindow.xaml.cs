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
        //ObservableCollection<ESKDClass> collectionClassifier;
        List<ESKDClass> Classifier;



        private void LoadData()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
        }

        //void LoadToXML()
        //{
        //    XmlDocument d = new XmlDocument();
        //    d.Load(pathFileXML);
        //    XmlNodeList list = d.DocumentElement.ChildNodes;
        //    foreach (XmlNode node in list)
        //    {
        //        string CodESKD =  node.Attributes["CodESKD"].Value;
        //        string Description = node.Attributes["Description"].Value;
                
        //        Classifier eskd = new Classifier();
        //        eskd.CodESKD = CodESKD;
        //        eskd.Description = Description;
        //        eskd.SubClasses = getXmlNodes(node.ChildNodes);
                
        //        collectionClassifier.Add(eskd);
        //        //string ESKDClass = node.SelectSingleNode("ESKDClass").InnerText;
        //        //string last = node.SelectSingleNode("last").InnerText;
        //    }
        //}

        //ObservableCollection<ESKDClass> getXmlNodes(XmlNodeList nodes)
        //{
        //    ObservableCollection<Classifier> coll = new ObservableCollection<Classifier>();
        //    foreach (XmlNode node in nodes)
        //    {
        //        string CodESKD = node.Attributes["CodESKD"].Value;
        //        string Description = node.Attributes["Description"].Value;
        //        ESKDClass eskd = new ESKDClass();
        //        eskd.CodESKD = CodESKD;
        //        eskd.Description = Description;
        //        eskd.SubClasses = getXmlNodes(node.ChildNodes);
        //        coll.Add(eskd);
                
        //    }
        //    return coll;
        //}
        //void SaveToXml(List<ESKDClass> list)
        //{
        //    XmlDocument d = new XmlDocument();
        //    XmlNode root = d.CreateNode(XmlNodeType.Element, "ESKDClassifier", "");
        //    d.AppendChild(root);
        //    try
        //    {
        //        for (int i = 0; i < list.Count; i++)
        //        {

        //            //XmlNode n2 = 
        //            XmlNode n = d.CreateNode(XmlNodeType.Element, "ESKDClass", " ");
        //            n.Attributes.Append(d.CreateAttribute("CodESKD"));
        //            n.Attributes.Append(d.CreateAttribute("Description"));
        //            n.Attributes.Append(d.CreateAttribute("Image"));
        //            n.Attributes["CodESKD"].Value = list[i].CodESKD;
        //            n.Attributes["Description"].Value = list[i].Description;
        //            n.Attributes["PathPicture"].Value = list[i].PathPicture;
        //            XmlNode n2 = root.AppendChild(n);
        //            if (list[i].eskdViews.Count > 0)
        //                n2.AppendChild(setXmlNode(list[i].eskdViews, d));

        //        }


        //        d.Save(pathFileXML);
        //    }
        //    catch
        //    {

        //    }
        //}

        //private XmlNode setXmlNode(ObservableCollection<ESKDClass> collection, XmlDocument d)
        //{

        //    XmlNode n = d.CreateNode(XmlNodeType.Element, "ESKDClass", " ");

        //    n.Attributes.Append(d.CreateAttribute("CodESKD"));
        //    n.Attributes.Append(d.CreateAttribute("Description"));
        //    n.Attributes.Append(d.CreateAttribute("Image"));

        //    for (int j = 0; j < collection.Count; j++)
        //    {
        //        n.Attributes["CodESKD"].Value = collection[j].CodESKD;
        //        n.Attributes["Description"].Value = collection[j].Description;
        //        n.Attributes["PathPicture"].Value = collection[j].PathPicture;
        //        if (collection[j].eskdViews.Count > 0)
        //            n.AppendChild(setXmlNode(collection[j].eskdViews, d));
        //    }
        //    return n;
        //}


        public MainWindow()
        {
            InitializeComponent();

            Classifier = new List<ESKDClass>();

           
            ESKDClass root = new ESKDClass();
            root.CodESKD = "42";
            root.Description = "устройства и системы контроля и регулирования парамметрами технолоогического процесса";

            ESKDClass child = new ESKDClass();
            child.CodESKD = "421111";
            child.Description = "устройства и системы контроля и регулирования параметров технологических процессов электрические, преобразователи пневмоэлектрические, аналоговые, постоянного тока ";

            root.eskdViews.Add(child);

            Classifier.Add(root);
            Classifier.Add(new ESKDClass() { CodESKD = "75", Description = "детали-тела вращения" });
            Classifier.Add(new ESKDClass() { CodESKD = "74", Description = "детали-не тела вращения" });

            ESKDListView.ItemsSource = Classifier;
            ESKDTree.ItemsSource = Classifier;
           
            //создаём файл сериализации
            FileStream fsout = new FileStream(pathFileXML, FileMode.Create, FileAccess.Write);
            XmlSerializer serializerout = new XmlSerializer(typeof(List<ESKDClass>), new Type[] { typeof(ESKDClass) });
            serializerout.Serialize(fsout, Classifier);
            fsout.Close();


            //LoadToXML();
            //ESKDListView.Items.Add(root);
            //ESKDListView.Items.Clear();

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
