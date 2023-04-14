using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace WpfOnBreak
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnVentanaClientes_Click(object sender, RoutedEventArgs e)
        {
            WindowCliente ventana = new WindowCliente();

            ventana.Show();
        }

        private void btnVentanaContrato__Click(object sender, RoutedEventArgs e)
        {
            WindowContrato ventana = new WindowContrato();

            ventana.Show();
        }

        private void btnLIstaClientes_Click(object sender, RoutedEventArgs e)
        {
            
            WindowListaClientes ventana = new WindowListaClientes();
            ventana.dgClientes.IsReadOnly = true;
            ventana.btnListarClientesContrato.IsEnabled = false;
            ventana.Show();

        }

        private void btnListaContrato_Click(object sender, RoutedEventArgs e)
        {
            WindowListaContrato ventana = new WindowListaContrato();
            ventana.dgClientes.IsReadOnly = true;
            ventana.dgContratos.IsReadOnly = true;
            ventana.btn_ListarContrato.IsEnabled = false; 
            ventana.Show();
        }

        private void btnSalir_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void Update() {
         
        }
    }
}
