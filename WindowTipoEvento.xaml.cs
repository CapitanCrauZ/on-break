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

namespace WpfOnBreak
{
    /// <summary>
    /// Lógica de interacción para WindowTipoEvento.xaml
    /// </summary>
    public partial class WindowTipoEvento : Window
    {
        private string tipo;
        TipoEvento agregado = new TipoEvento();

        public WindowTipoEvento()
        {
            InitializeComponent();

            if (TipoEvento.SW == 0)
            {
                agregado.llenar();
            }
            dgTipoEvento.ItemsSource = TipoEvento.alTipoEvento;
        }

        WindowContrato subida = new WindowContrato();

        private void btnGuardar_Click(object sender, RoutedEventArgs e)
        {
            WindowListaContrato ventana = new WindowListaContrato();

           
            ventana.dgTipoEvento.ItemsSource = null;
         
            ventana.dgTipoEvento.ItemsSource = ClienteCollection.ObtenerDatos();


        }


        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void txtId_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
