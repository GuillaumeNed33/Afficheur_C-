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
using System.Drawing;

namespace Afficheur
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            string path = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
            DataContext = new DataModel(path);  
        }
        public void Diaporama_Click(object sender, EventArgs e)
        {     
           Diaporama diap = new Diaporama(((DataModel)DataContext).Fichiers);
           diap.Show();
        }
    }
}


