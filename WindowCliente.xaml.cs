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
    /// Lógica de interacción para WindowCliente.xaml
    /// </summary>
    public partial class WindowCliente : Window
        
    {
        private string rut;
       

        public WindowCliente()
        {
            InitializeComponent();

            btnAgregar.IsEnabled = true;
            cbxActividadEmpresa.ItemsSource = Enum.GetValues(typeof(ActividadEmpresaEnum));
            cbxTipoEmpresa.ItemsSource = Enum.GetValues(typeof(TipoEmpresaEnum));


            if (ClienteCollection.SW == 0) {
                ClienteCollection.llenar();
                 }
            //dgClientes.Visibility = System.Windows.Visibility.Collapsed;
            dgClientes.ItemsSource = ClienteCollection.ObtenerDatos();


        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            
            string rut, razonSocial, nombreContacto, mailContacto, direccion, actividad, tipo, telefono = "";
            

            rut = txtRut.Text;
            razonSocial = txtRazonSocial.Text;
            nombreContacto = txtNombreContacto.Text;
            mailContacto = txtMailContacto.Text;
            direccion = txtDireccion.Text;
            //telefono1 = int.Parse(txtTelefono.Text);
            //telefono2 = cbxTelefono.Text;
            telefono = txtTelefono.Text;
            actividad = ((ActividadEmpresaEnum)cbxActividadEmpresa.SelectedIndex).ToString();         
            tipo = ((TipoEmpresaEnum)(cbxTipoEmpresa.SelectedIndex)).ToString();


           
            Cliente cliente = new Cliente(rut, razonSocial, nombreContacto, mailContacto, direccion, telefono, actividad, tipo);
            if (!txtRut.Text.Equals("") && !txtRazonSocial.Text.Equals("") && !txtNombreContacto.Text.Equals("") && !txtMailContacto.Text.Equals("") && !txtDireccion.Text.Equals("") && !txtTelefono.Text.Equals("") && !cbxActividadEmpresa.Text.Equals("") && !cbxTipoEmpresa.Text.Equals(""))
                
                if (ClienteCollection.Agregar(cliente) == true)
                {
                    MessageBox.Show("Cliente Agregado!");
                    
                    Limpiar();
                    
                }
                else
                {
                    MessageBox.Show("Error! Cliente no Registrado");
                }
                
            else {
                MessageBox.Show("Error Faltan Datos");
            }
            dgClientes.ItemsSource = null;
            dgClientes.ItemsSource = ClienteCollection.ObtenerDatos();


        }

        public void Limpiar() {
            txtRut.Text = "";
            txtRazonSocial.Text = "";
            txtNombreContacto.Text = "";
            txtMailContacto.Text = "";
            txtDireccion.Text = "";
            txtTelefono.Text = "";
            cbxActividadEmpresa.SelectedIndex = -1;
            cbxTipoEmpresa.SelectedIndex = -1;
            txtRut.IsEnabled = true;
            btnAgregar.IsEnabled = true;
            txtRazonSocial.IsEnabled = true;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string rut = "";
           
            rut = txtRut.Text;

            Cliente cliente = ClienteCollection.Buscar(rut);
            if (txtRut.Text.Equals("")) { MessageBox.Show("Necesita Ingresar un rut para Buscar"); }
            else
            {
                if (cliente != null)
                {

                    txtRazonSocial.IsEnabled = false;
                    txtNombreContacto.Text = cliente.NombreContacto;
                    txtRazonSocial.Text = cliente.RazonSocial;
                    txtMailContacto.Text = cliente.MailContacto;
                    txtDireccion.Text = cliente.Direccion;
                    txtTelefono.Text = cliente.Telefono.ToString();
                    cbxActividadEmpresa.Text = cliente.Actividad;
                    cbxTipoEmpresa.Text = cliente.Tipo;
                }
                else
                {
                    MessageBox.Show("Cliente, no Existe");
                }
            }
        }

        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            string rut = "";
            

            rut = txtRut.Text;

            if (ClienteCollection.Eliminar(rut) == true)
            {
                MessageBox.Show("Cliente Eliminado");
                Limpiar();
            }
            else {
                MessageBox.Show("Cliente no existe");
            }
            dgClientes.ItemsSource = null;

            dgClientes.ItemsSource = ClienteCollection.ObtenerDatos();

        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            string rut, razonSocial, nombreContacto, mailContacto, direccion, actividad, tipo, telefono = "";
            

            rut = txtRut.Text;
            razonSocial = txtRazonSocial.Text;
            nombreContacto = txtNombreContacto.Text;
            mailContacto = txtMailContacto.Text;
            direccion = txtDireccion.Text;
            telefono = txtTelefono.Text;
            actividad = ((ActividadEmpresaEnum)(cbxActividadEmpresa.SelectedItem)).ToString();
            tipo = ((TipoEmpresaEnum)(cbxTipoEmpresa.SelectedItem)).ToString();

            Cliente cliente = new Cliente(rut, razonSocial, nombreContacto, mailContacto, direccion, telefono, actividad, tipo);
            if (ClienteCollection.Modificar(cliente) == true) {
                MessageBox.Show("Cliente Modificado");
                dgClientes.ItemsSource = null;

                dgClientes.ItemsSource = ClienteCollection.ObtenerDatos();
            }
            else
            {
                MessageBox.Show("Cliente no existe");
            }
          


        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public enum ActividadEmpresa {
            Agropecuaria,
            Minería,
            Manufactura,
            Comercio,
            Hotelería,
            Alimentos,
            Transporte,
            Servicios
        }
        public enum TipoEmpresa {
            SPA,
            EIRL,
            Limitada,
            SociedadAnóinma
        }

        private void dgClientes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try {
                //txtRazonSocial.Text = razonSocial;
                //txtNombreContacto.Text = nombreContacto;
                //txtMailContacto.Text = mailContacto;
                //txtDireccion.Text = direccion;
                //txtTelefono.Text = telefono;
                //cbxActividadEmpresa.Text = actividad;
                //cbxTipoEmpresa.Text = tipo;
                //razonSocial = row_list.RazonSocial;
                //nombreContacto = row_list.NombreContacto;
                //mailContacto = row_list.MailContacto;
                //direccion = row_list.Direccion;
                //telefono = row_list.Telefono.ToString();
                //actividad = row_list.Actividad;
                //tipo = row_list.Tipo;
                var row_list = (Cliente)dgClientes.SelectedItem;
                rut = row_list.Rut;
                txtRut.Text = rut;
                txtRut.IsEnabled = false;
                btnAgregar.IsEnabled = false;
              
            } catch { }

        }

        private void btnLimpiar_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();
        }


        private void btnListar_Click_1(object sender, RoutedEventArgs e)
        {
            WindowListaClientes ventana = new WindowListaClientes();
            ventana.btnListarClientesContrato.IsEnabled = false;
            ventana.Show();
            
        }

        private void btnContrato_Click(object sender, RoutedEventArgs e)
        {
           
        }

        private void cbxActividadEmpresa_SelectedIndexChange(object sender, SelectionChangedEventArgs e)
        {
    


        }

        private void cbxActividadEmpresa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
    
}
