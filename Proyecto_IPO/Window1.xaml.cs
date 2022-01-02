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

namespace Proyecto_IPO
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {

        public Window1()
        {
            InitializeComponent();
        }

        private void MouseDoubleClick_SalirApp(object sender, MouseButtonEventArgs e)
        {
            Application.Current.Shutdown();
        }
        
        private void MouseDoubleClick_CambiarUsuario(object sender, MouseButtonEventArgs e)
        {
           MainWindow ventanaMenu = new MainWindow();
           ventanaMenu.Owner = this;
           ventanaMenu.Show();
           this.Visibility = Visibility.Hidden;
        }

        private void VentanaMenuPrincipal_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
