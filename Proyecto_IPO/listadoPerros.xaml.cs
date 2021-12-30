using System;
using System.Collections.Generic;
using System.Drawing;
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
using System.Xml;

namespace Proyecto_IPO
{
    /// <summary>
    /// Lógica de interacción para listadoPerros.xaml
    /// </summary>
    public partial class listadoPerros : Window
    {
        private List<Perro> listPerros;
        public listadoPerros()
        {
            InitializeComponent();
            // Se cargarán los datos de prueba de un fichero XML
            listPerros = CargarXMLPerros();
            // Indicar que el origen de datos del ListBox es listadoPeliculas
            lstPerros.ItemsSource = listPerros;
            //Console.WriteLine("{0}", listPerros[0].Descripcion);

        }


        private List<Perro> CargarXMLPerros()
        {
            List<Perro> listado = new List<Perro>();
            // Cargar contenido de prueba
            XmlDocument doc = new XmlDocument();
            var fichero = Application.GetResourceStream(new Uri("XMLs/Perros.xml", UriKind.Relative));
            doc.Load(fichero.Stream);
            foreach (XmlNode node in doc.DocumentElement.ChildNodes)
            {
                var nuevoPerro = new Perro("caca", "", "", 0, "", "", null, true);
                nuevoPerro.Nombre = node.Attributes["Nombre"].Value;
                nuevoPerro.Sexo = node.Attributes["Sexo"].Value;
                nuevoPerro.Raza = node.Attributes["Raza"].Value;
                nuevoPerro.Edad = Convert.ToInt32(node.Attributes["Edad"].Value);
                nuevoPerro.Fecha = node.Attributes["Fecha"].Value;
                nuevoPerro.Descripcion = node.Attributes["Descripcion"].Value;
                nuevoPerro.Foto = new Uri(Environment.CurrentDirectory + node.Attributes["Foto"].Value);            
                nuevoPerro.Image = new BitmapImage(nuevoPerro.Foto);
                nuevoPerro.Apadrinado = bool.Parse(node.Attributes["Apadrinado"].Value);

                listado.Add(nuevoPerro);
            }
            return listado;
        }
    }


}
