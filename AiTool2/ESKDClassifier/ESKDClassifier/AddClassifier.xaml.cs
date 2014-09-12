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
using System.Windows.Shapes;

namespace ESKDClassifier
{
    /// <summary>
    /// Interaction logic for AddClassifier.xaml
    /// </summary>
    public partial class AddClassifier : Window
    {
        public AddClassifier()
        {
            InitializeComponent();
        }

        private Classifier classifier;

        public Classifier GetClassifier()
        {
            return classifier;
        }

        private void BtnCancel_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void BtnOk_Click(object sender, RoutedEventArgs e)
        {
            // Блок проперок

            classifier = new Classifier();
            classifier.CodESKD = this.CodeESKD.Text;
            classifier.Description = this.DescESKD.Text;
            classifier.Image = this.ImageESKD.Text;
            this.Close();
        }
    }
}
