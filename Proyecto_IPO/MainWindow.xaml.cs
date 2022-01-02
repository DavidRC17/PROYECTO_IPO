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

namespace Proyecto_IPO
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private string usuario = "mario";
        private string pwd = "ipo";
        private BitmapImage imagCheck = new BitmapImage(new Uri("/Resources/check.png", UriKind.Relative));
        private BitmapImage imagCross = new BitmapImage(new Uri("/Resources/cross.png", UriKind.Relative));
        private Window1 ventanaMenu = new Window1();
        public MainWindow()
        {
            InitializeComponent();
        }

        /*************************************
         ********** METODOS DE APOYO **********
        *************************************/

        /*************************************
        ** ACCIONES Y EVENTOS DEL PROGRAMA ***
        *************************************/
        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            txtUsuario.Background = Brushes.White;
            txtUsuario.BorderBrush = Brushes.LightGray;
            passContrasena.Background = Brushes.White;
            passContrasena.BorderBrush = Brushes.LightGray;

            if (String.IsNullOrEmpty(txtUsuario.Text) || String.IsNullOrEmpty(passContrasena.Password))
            {
                lblEstado.Content = "Debes rellenar los campos usuario y contraseña";
                lblEstado.Foreground = Brushes.Red;
            }
            else{
                if (txtUsuario.Text.Equals(usuario) && passContrasena.Password.Equals(pwd))
                {
                    txtUsuario.Background = Brushes.LightGreen;
                    txtUsuario.BorderBrush = Brushes.Green;
                    passContrasena.Background = Brushes.LightGreen;
                    passContrasena.BorderBrush = Brushes.Green;
                    ventanaMenu.Owner = this;
                    ventanaMenu.Show();
                    ventanaMenu.lblMenuDatosUsu.Content = "User: " + txtUsuario.Text + ", Last user login: " + DateTime.Today.ToString("D");
                    this.Visibility = Visibility.Hidden;
                }
                else
                {
                    if (!txtUsuario.Text.Equals(usuario))
                    {
                        txtUsuario.Background = Brushes.LightSalmon;
                        txtUsuario.BorderBrush = Brushes.Red;
                        lblEstado.Content = "Contraseña o usuario incorrectos, intentelo de nuevo";
                        lblEstado.Foreground = Brushes.Red;
                    }
                    if(!passContrasena.Password.Equals(pwd)) {
                        passContrasena.Background = Brushes.LightSalmon;
                        passContrasena.BorderBrush = Brushes.Red;
                        lblEstado.Content = "Contraseña o usuario incorrectos, intentelo de nuevo";
                        lblEstado.Foreground = Brushes.Red;
                    }
                }
            }
        }

        private void txtUsuario_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                lblEstado.Content = "Se pulsó el enter ";
                passContrasena.IsEnabled = true;
                passContrasena.Focus();
            }
        }

        private void VentanaPrincipal_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("Cerrando Protectora MAVID....", "Cerrar"); 
        }

        private void btnAyuda_Click(object sender, RoutedEventArgs e)
        {
           MessageBox.Show("Esta es la pantalla de Login:\n- En USUARIO debes poner el nombre con el que te creaste la cuenta.\n- En CONTRASEÑA debes poner la contraseña pusiste al crear la cuenta.\nSi no tienes credenciales creadas, no puedes acceder a la protectora", "Ayuda");
        }

        private void btnCerrarApp_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void MouseDown_CambiarContrasena(object sender, MouseButtonEventArgs e)
        {
            if (txtUsuario.Text.Equals(usuario))
            {
                MessageBox.Show("La contraseña es 'ipo'. Este apartado de cambiar contraseña esta por implementar", "Ayuda");
            }
            else 
            {
                MessageBox.Show("Debes introducir el usuario primero", "Error");
            }
        }
    } 
}
