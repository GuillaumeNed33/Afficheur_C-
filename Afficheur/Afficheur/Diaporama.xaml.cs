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
using ExifLibrary;
using System.Threading;
using System.Windows.Threading;

namespace Afficheur
{
    /// <summary>
    /// Logique d'interaction pour Diaporama.xaml
    /// </summary>
    
    
    public partial class Diaporama : Window
    {
        int i = 0;
        bool pause = false;
        DispatcherTimer clock = new DispatcherTimer();

        private List<JPGFileInfo> files;
        public Diaporama(List<JPGFileInfo> Fichiers)
        {
            InitializeComponent();
            this.files = Fichiers;
            MyImage.Source = new BitmapImage(new Uri(files[i].FullName));
            
            clock.Interval = new TimeSpan(0, 0, 2);
            clock.Start();
            clock.Tick += clock_Tick;
        }

        void clock_Tick(object sender, EventArgs e)
        {
            i = (i + 1) % files.Count;
            UpdateImage();
        }

        public void UpdateImage()
        {
            MyImage.Source = new BitmapImage(new Uri(files[i].FullName));
        }

        private void Keyboard_Event(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Close();
            }
            
            else if (e.Key == Key.Right)
            {
                clock.Stop();
                i = (i + 1) % files.Count;
                UpdateImage();
                clock.Start();
            }

            else if (e.Key == Key.Left)
            {
                clock.Stop();
                if (i >= 1)
                {
                    i--;
                }
                else if (i == 0)
                {
                    i = files.Count - 1;
                }
                UpdateImage();
                clock.Start();
            }

            else if (e.Key == Key.Space)
            {
                if (!pause)
                {
                    clock.Stop();
                    pause = true;
                }
                else
                {
                    clock.Start();
                    pause = false;
                }
            }
        }
    }
}
