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
using System.Windows.Shapes;

namespace Sergioteacher.Csharp05.EditorTextoA
{
    /// <summary>
    /// Lógica de interacción para Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        MainWindow Inicio;

        public bool encontrado = false;

        public Window1(MainWindow ventanaInicio)
        {
            Inicio = ventanaInicio;
            InitializeComponent();

        }

        private void BIntro_Click(object sender, RoutedEventArgs e)
        {

            encontrado = false;

            string rutaArchivo = MiTexto.Text; // Reemplaza con la ruta de tu archivo
            try
            {

                if (File.Exists(rutaArchivo))
                {
                    encontrado = true;
                }
            }
            catch (Exception ex)
            {
                // Manejar la excepción si ocurre algún problema al acceder al archivo
                Console.WriteLine("Error al acceder al archivo: " + ex.Message);
            }

            if (encontrado)
            {
                string contenido = File.ReadAllText(rutaArchivo);
                Inicio.fpath = rutaArchivo;
                Inicio.Tedit.Text = contenido;
                this.Hide();
            }
            else
            {
                MessageBox.Show("No se ha encontrado el archivo", "Archivo no encontrado", MessageBoxButton.OK, MessageBoxImage.Exclamation);
            }
        }


            private void VentanaInput_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (this.Visibility == Visibility.Visible)
            {
                //MessageBox.Show("Hola, mensaje al capturar ->  X");
                e.Cancel = true;
                Inicio.DataContext = "";
                Inicio.Show();
                this.Hide();
            }
        }

        private void VentanaInput_Activated(object sender, EventArgs e)
        {
            MiTexto.Text = "";
        }
    }
}
