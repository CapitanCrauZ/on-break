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
using System.Windows.Media.Media3D;
using System.Windows.Shapes;

namespace WpfOnBreak
{
    /// <summary>
    /// Lógica de interacción para WindowListaContrato.xaml
    /// </summary>
    public partial class WindowListaContrato : Window
    {
        private string numeroContrato;
        private string personalBase;
        TipoEvento agregado = new TipoEvento();
        private int asistentes;

        public WindowListaContrato()
        {
            InitializeComponent();
            if (ContratoCollection.SW == 0)
            {
                ContratoCollection.llenar();
            }

            if (TipoEvento.SW == 0)
            {
                agregado.llenar();
            }

            if (ClienteCollection.SW == 0) {
                ClienteCollection.llenar();
            }
            dgTipoEvento.ItemsSource = TipoEvento.alTipoEvento;
            dgContratos.ItemsSource = ContratoCollection.ObtenerDatos();
            dgClientes.ItemsSource = ClienteCollection.ObtenerDatos();
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnVolver_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void dgContratos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
         
        }

        private void ValorTotalEvento() {
            WindowTipoEvento ventana = new WindowTipoEvento();
            //ValorTotal = 0;

            //            if ((ventana.txtPersonalBase.Text) == ) {

            //          }
            //        else if () { }


        }

        private void btn_ListarContrato_Click(object sender, RoutedEventArgs e)
        {
            WindowContrato ventana = new WindowContrato();

            try
            {
                var row_list = (Contrato)dgContratos.SelectedItem;
                numeroContrato = row_list.NumeroContrato;
                ventana.txtNumeroContrato.Text = numeroContrato;
                ventana.Show();
                ventana.txtNumeroContrato.IsEnabled = false;

            }
            catch
            {

            }
        }

        private void dgTipoEvento_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


        }

        private void btnCalcular_Click(object sender, RoutedEventArgs e)
        {
   
            }
            //if (!v2.Equals(v1)) { 
                
            //}
            //else {
              //  MessageBox.Show("faltan Datos");
            //}
            //txtCalculoEvento.Text = valorfinal.ToString();
            //valorfinal += valorBase;  
        //}
        

        private void NotifyPropertyChanged(String numeroContrato = "") {
            WindowContrato ventana = new WindowContrato();
            if (PropertyChanged != null) {
                PropertyChanged(this, new PropertyChangingEventArgs(numeroContrato));
            }
        }

        public event PropertyChangingEventHandler
            PropertyChanged;

        private void BringWindowToFront(WindowContrato windowContrato) {
            if (!windowContrato.IsVisible) {
                windowContrato.Show();
            }
            if (windowContrato.WindowState == WindowState.Minimized) {
                windowContrato.WindowState = WindowState.Normal;
            }
            windowContrato.Activate();
        }


    }
}
