using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
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
    /// Lógica de interacción para WindowListaClientes.xaml
    /// </summary>
    public partial class WindowListaClientes : Window
    {
        private string rut;
        private string razonSocial;

        public WindowListaClientes()
        {
            InitializeComponent();

            if (ClienteCollection.SW == 0)
            {
                ClienteCollection.llenar();
            }
            dgClientes.ItemsSource = ClienteCollection.ObtenerDatos();

        }


        private void btnVolver_Click_1(object sender, RoutedEventArgs e)
        {

            this.Close();

        }


        private void dgClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         
            //WindowContrato ventana = new WindowContrato();
            //DataRowView datos = dgClientes.SelectedItem as DataRowView;
            //if (datos != null)
            //{
                //ventana.txtRutCliente.Text = datos["Rut Cliente"].ToString();
                //ventana.txtRazonSocialContratos.Text = datos["Razon Social"].ToString();
                //ventana.Show();

            //}
        }

        private void btnListarClienteClientes_Click(object sender, RoutedEventArgs e)
        {
        

        }

        private void btnListarClientesContrato_Click(object sender, RoutedEventArgs e)
        {
            WindowCliente scenario = new WindowCliente();

            try
            {
                var valorizador = (Cliente)dgClientes.SelectedItem;
                rut = valorizador.Rut;
                razonSocial = valorizador.RazonSocial;
                scenario.txtRut.Text = rut;
                //scenario.txtRazonSocialContratos.Text = razonSocial;
                //scenario.txtRutCliente.IsEnabled = false;
                //scenario.txtRazonSocialContratos.IsEnabled = false;
                scenario.txtRut.IsEnabled = false;
                scenario.ShowDialog();
               
            }
            catch { }

            


        }

        private void btnListarClientes_Click(object sender, RoutedEventArgs e)
        {
            WindowContrato ventana = new WindowContrato ();

            try
            {
                var valorizador = (Cliente)dgClientes.SelectedItem;
                rut = valorizador.Rut;
                razonSocial = valorizador.RazonSocial;
                ventana.txtRutClienteContrato.Text = rut;
                ventana.txtRazonSocialContrato.Text = razonSocial;
                //scenario.txtRazonSocialContratos.Text = razonSocial;
                //scenario.txtRutCliente.IsEnabled = false;
                //scenario.txtRazonSocialContratos.IsEnabled = false;
                ventana.txtRutClienteContrato.IsEnabled = false;
                ventana.txtRazonSocialContrato.IsEnabled = false;
                ventana.txtNumeroContrato.IsEnabled = false;
                ventana.txtNumeroContrato.Text = "Confirmar para Obtener";
                ventana.ShowDialog();

            }
            catch { }
        }
    }   
}
