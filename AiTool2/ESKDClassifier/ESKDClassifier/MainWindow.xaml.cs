using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ESKDClassifier
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Uri uri = new Uri(AppDomain.CurrentDomain.BaseDirectory + @"PictureBackground.jpg", UriKind.Relative);
            //TreeViewItem newItem = new TreeViewItem();
            //newItem.Header = "Привет мир!";
            //ESKDTree.Items.Add(newItem);
        }

        private TreeViewItem selectedItem = null;

        private void AddClass_Click(object sender, RoutedEventArgs e)
        {
            AddClassifier addClass = new AddClassifier();
            addClass.ShowDialog();
            Classifier classifier = addClass.GetClassifier();

            List<Classifier> cl = new List<Classifier>();
            if (selectedItem == null)
                ESKDTree.Items.Add(classifier);
            else
                selectedItem.Items.Add(classifier);
            //ESKDTree.ItemsSource = cl;

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
