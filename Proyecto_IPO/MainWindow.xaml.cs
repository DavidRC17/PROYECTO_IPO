using System;
using System.Collections.Generic;
using System.IO;
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

namespace Proyecto_IPO
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //listadoPerros listado = new listadoPerros();
            //listado.Show();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            listadoPerros Perros = new listadoPerros();
            Perros.Show();
        }

        private BitmapImage BitmapToBitmapImage(System.Drawing.Bitmap bitmap)
        {

            MemoryStream MS = new MemoryStream();
            bitmap.Save(MS, System.Drawing.Imaging.ImageFormat.Png);
            BitmapImage ResultBitmapImage = new System.Windows.Media.Imaging.BitmapImage();

            ResultBitmapImage.BeginInit();
            ResultBitmapImage.StreamSource = new MemoryStream(MS.ToArray());
            ResultBitmapImage.CreateOptions = BitmapCreateOptions.None;
            ResultBitmapImage.CacheOption = BitmapCacheOption.Default;
            ResultBitmapImage.EndInit();

            MS.Close();
            return ResultBitmapImage;
        }
    }
}
