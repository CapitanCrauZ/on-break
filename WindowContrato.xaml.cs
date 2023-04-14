using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
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
    /// Lógica de interacción para WindowContrato.xaml
    /// </summary>
    public partial class WindowContrato : Window
    {
        WindowListaContrato listado = new WindowListaContrato();
        private string numeroContrato;
       

        private string dia;
        private string mes;
        private string anio;


        public WindowContrato()
        {
            
            InitializeComponent();

            
            if (ContratoCollection.SW == 0)
            {
                ContratoCollection.llenar();
            }
            //dgContratos.Visibility = System.Windows.Visibility.Collapsed;
            listado.dgContratos.ItemsSource = ContratoCollection.ObtenerDatos();
            txtFechaInicio3.IsEnabled = false;
            //cbxFechaInicio2.IsEnabled = false;
            txtFechaTermino3.IsEnabled = false;
            //cbxFechaTermino2.IsEnabled = false;
            txtTermino3.IsEnabled = false;
            //cbxTermino2.IsEnabled = false;
            txtCreacion1.IsEnabled = false;
            txtCreacion2.IsEnabled = false;
            txtCreacion3.IsEnabled = false;
            btnAgregar.IsEnabled = false;
         



        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public void Automatizacion()
        {

            string hora, minuto, segundo = "";
            string idfechaHora = "";
            hora = DateTime.Now.Hour.ToString();
            minuto = DateTime.Now.Minute.ToString();
            segundo = DateTime.Now.Second.ToString();
            dia = DateTime.Now.Day.ToString();
            mes = DateTime.Now.Month.ToString();
            anio = DateTime.Now.Year.ToString();
            idfechaHora = anio + (mes.Length < 2 ? 0 + mes : mes) + (dia.Length < 2 ? 0 + dia : dia) + (hora.Length < 2 ? 0 + hora : hora) + (minuto.Length < 2 ? 0 + minuto : minuto);
            txtNumeroContrato.Text = idfechaHora;


        }

        private void btnAgregar_Click(object sender, RoutedEventArgs e)
        {
            string numeroContrato, creacion, termino, fechaHoraInicio, fechaHoraTermino, direccion, estaVigente, tipo, observaciones = "";
            int asistentes = 0;
            int total = 0;
            string idFechaInicio = "";
            string idHoraInicio = "";
            string idFechaTermino = "";
            string idHoraTermino = "";

            idFechaInicio = cbxFechaInicio1 + "-" + cbxFechaInicio2.Text + "-" + txtFechaInicio3.Text;
            idHoraInicio = cbxHoraInicio.Text + ":" + cbxHoraInicio2.Text + ":00";
            idFechaTermino =cbxFechaTermino1 + "-" +  cbxFechaTermino2.Text + "-" +  txtFechaTermino3.Text;
            idHoraTermino = cbxHoraTermino.Text + ":" + cbxHoraTermino2.Text+ ":00";

            numeroContrato = txtNumeroContrato.Text;
            creacion = txtCreacion1.Text + "-" + txtCreacion2.Text + "-" + txtCreacion3.Text;
            termino = cbxTermino1 + "-" + cbxTermino2.Text + "-" + txtTermino3.Text;
            fechaHoraInicio = (idFechaInicio, idHoraInicio).ToString();
            fechaHoraTermino = (idFechaTermino, idHoraTermino).ToString();
            direccion = txtDirecion.Text;
            estaVigente = ((ComboBoxItem)cbxVigente.SelectedItem).ToString();
            tipo = ((ComboBoxItem)(cbxTipo.SelectedItem)).ToString();
            observaciones = txtObservaciones.Text;
            asistentes = int.Parse(txtAsistentes.Text);
            total = int.Parse(txtValorTotal.Text);


            Contrato contrato = new Contrato(numeroContrato, creacion, termino, fechaHoraInicio, fechaHoraTermino, direccion, estaVigente, tipo, observaciones, asistentes, total);

            if (!txtNumeroContrato.Text.Equals("") || !creacion.Equals("") || !termino.Equals("") || !fechaHoraInicio.Equals("") || !fechaHoraTermino.Equals("") || !direccion.Equals("") || !cbxVigente.Text.Equals("") || !cbxTipo.Text.Equals("") || !observaciones.Equals("") || !asistentes.Equals("") || !total.Equals(""))
            {

                if (ContratoCollection.Agregar(contrato) == true)
                {
                    MessageBox.Show("Contrato Agregado!");
                    listado.dgContratos.ItemsSource = null;
                    if ((tipo.Equals("1")))
                    {
                        TipoEvento.alTipoEvento.Add(new TipoEvento("1", "Aniversario", 30, 15));
                    }
                    else if ((tipo.Equals("2")))
                    {
                        TipoEvento.alTipoEvento.Add(new TipoEvento("2", "Despedida", 10, 10));
                    }
                    else if ((tipo.Equals("3")))
                    {
                        TipoEvento.alTipoEvento.Add(new TipoEvento("3", "Conmemoración", 3, 18));
                    }
                    else if ((tipo.Equals("4"))) {
                        TipoEvento.alTipoEvento.Add(new TipoEvento("4", "Reapertura", 6, 20));
                    }
                    
                   
                else {
                        MessageBox.Show("Error! Faltan Datos");
                    }
                        listado.dgContratos.ItemsSource = ContratoCollection.ObtenerDatos();
                        Limpiar();
                   }

            // if (ContratoCollection.Agregar(contrato) == true)
            //   {
            //     MessageBox.Show("Contrato Agregado!");
            //   listado.dgContratos.ItemsSource = null;

            // listado.dgContratos.ItemsSource = ContratoCollection.ObtenerDatos();
            //Limpiar();
            // }
            //else
            //{
            //    MessageBox.Show("Error! Contrato no Registrado");
            // }
        }

        }

        public void Limpiar()
        {
            txtNumeroContrato.Text = "";
            txtCreacion1.Text = "";
            txtCreacion2.Text = "";
            txtCreacion3.Text = "";
            cbxTermino1.Text = "";
            cbxTermino2.Text = "";
            txtTermino3.Text = "";
            cbxHoraInicio.Text = "";
            cbxHoraInicio2.Text = "";
            cbxFechaInicio1.Text = "";
            cbxFechaInicio2.Text = "";
            txtFechaInicio3.Text = "";
            cbxHoraTermino.Text = "";
            cbxHoraTermino2.Text = "";
            cbxFechaTermino1.Text = "";
            cbxFechaTermino2.Text = "";
            txtFechaTermino3.Text = "";
            txtDirecion.Text = "";
            cbxVigente.Text = "";
            cbxTipo.Text = "";
            txtObservaciones.Text = "";
            txtAsistentes.Text = "";
            txtNumeroContrato.IsEnabled = true;
            txtValorTotal.Text = "";
            txtAsistentesExtra.Text = "";
            txtPersonalExtra.Text = "";
            txtValorBase.Text = "";
            txtRazonSocialContrato.Text = "";
            txtRutClienteContrato.Text = "";
           
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            string numeroContrato= "";
            numeroContrato = txtNumeroContrato.Text;

                Contrato contrato = ContratoCollection.Buscar(numeroContrato);
            if (txtNumeroContrato.Text.Equals("")) { MessageBox.Show("Nesecita Ingresar un Número de Contrato para Buscar"); }
            else
            {
                if (contrato != null)
                {

                    txtNumeroContrato.Text = contrato.NumeroContrato;
                    txtCreacion1.Text = contrato.Creacion;
                    txtCreacion2.Text = contrato.Creacion;
                    txtCreacion3.Text = contrato.Creacion;
                    cbxFechaTermino1.Text = contrato.FechaHoraTermino;
                    cbxTermino1.Text = contrato.Termino;
                    cbxTermino2.Text = contrato.Termino;
                    txtTermino3.Text = contrato.Termino;
                    //contrato.FechaHoraInicio = (txtFechaInicio.Text, txtHoraInicio.Text).ToString();
                    //contrato.FechaHoraTermino = (txtFechaTermino.Text, txtHoraTermino.Text).ToString();
                    cbxFechaInicio1.Text = contrato.FechaHoraInicio;
                    cbxFechaInicio2.Text = contrato.FechaHoraInicio;
                    txtFechaInicio3.Text = contrato.FechaHoraInicio;
                    cbxHoraInicio.Text = contrato.FechaHoraInicio;
                    cbxHoraInicio2.Text = contrato.FechaHoraInicio;
                    cbxFechaTermino2.Text = contrato.FechaHoraTermino;
                    txtFechaTermino3.Text = contrato.FechaHoraTermino;
                    cbxHoraTermino.Text = contrato.FechaHoraTermino;
                    cbxHoraTermino2.Text = contrato.FechaHoraTermino;
                    txtDirecion.Text = contrato.Direccion;
                    cbxVigente.Text = contrato.EstaVigente;
                    cbxTipo.Text = contrato.Tipo;
                    txtObservaciones.Text = contrato.Observaciones;
                    txtAsistentes.Text = contrato.Asistentes.ToString();
                }
                else
                {
                    MessageBox.Show("Contrato, no Existe");
                }
            }
            
        }
        private void btnEliminar_Click(object sender, RoutedEventArgs e)
        {
            string numeroContrato = "";
            numeroContrato = txtNumeroContrato.Text;
            if (ContratoCollection.Eliminar(numeroContrato) == true)
            {
                MessageBox.Show("Contrato Eliminado");
                listado.dgContratos.ItemsSource = null;

                listado.dgContratos.ItemsSource = ContratoCollection.ObtenerDatos();
                Limpiar();
            }
            else
            {
                MessageBox.Show("Cliente no existe");
            }

        }

        private void btnModificar_Click(object sender, RoutedEventArgs e)
        {
            string numeroContrato, creacion, termino, fechaHoraInicio, fechaHoraTermino, direccion, estaVigente, tipo, observaciones= "";
            int asistentes = 0;
            int total = 0;

            string idFechaInicio = "";
            string idHoraInicio = "";
            string idFechaTermino = "";
            string idHoraTermino = "";


            numeroContrato = txtNumeroContrato.Text;
            creacion = txtCreacion1.Text + "-" + txtCreacion2.Text + "-" + txtCreacion3.Text;
            termino = cbxTermino1 + "-" + cbxTermino2.Text + "-" + txtTermino3.Text;
            fechaHoraInicio = (idFechaInicio, idHoraInicio).ToString();
            fechaHoraTermino = (idFechaTermino, idHoraTermino).ToString();
            //fechaHoraInicio = (txtFechaInicio.Text, txtHoraInicio.Text).ToString();
            //fechaHoraTermino = (txtFechaTermino.Text, txtHoraTermino.Text).ToString();
            direccion = txtDirecion.Text;
            estaVigente = ((ComboBoxItem)(cbxVigente.SelectedItem)).Content.ToString();
            tipo = ((ComboBoxItem)(cbxTipo.SelectedItem)).Content.ToString();
            observaciones = txtObservaciones.Text;
            asistentes = int.Parse(txtAsistentes.Text);
            total = int.Parse(txtValorTotal.Text);
            

            Contrato contrato = new Contrato(numeroContrato, creacion, termino, fechaHoraInicio, fechaHoraTermino, direccion, estaVigente, tipo, observaciones, asistentes, total);

            if (ContratoCollection.Modificar(contrato) == true)
            {
                MessageBox.Show("Contrato Modificado");
                listado.dgContratos.ItemsSource = null;

                listado.dgContratos.ItemsSource = ContratoCollection.ObtenerDatos();
                Limpiar();
            }
            else
            {
                MessageBox.Show("Contrato no existe");
                
            }



        }

        private void btnListar_Click(object sender, RoutedEventArgs e)
        {
            Limpiar();


        }

        private void dgContratos_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                //creacion, termino, fechaHoraInicio, fechaHoraTermino, direccion, estaVigente, tipo, observaciones
                //creacion = row_list.Creacion;
                //termino = row_list.Termino;
                //fechaHoraInicio = row_list.FechaHoraInicio;
                //fechaHoraTermino = row_list.FechaHoraTermino;
                //direccion = row_list.Direccion;
                //estaVigente = row_list.EstaVigente;
                //tipo = row_list.Tipo;
                //observaciones = row_list.Observaciones;
                //txtCreacion.Text = creacion;
                //txtTermino.Text = termino;
                //fechaHoraInicio = (txtFechaInicio.Text, txtHoraInicio.Text).ToString();
                //fechaHoraTermino = (txtFechaTermino.Text, txtHoraTermino.Text).ToString();
                //txtFechaInicio.Text = fechaHoraInicio;
                //txtHoraInicio.Text = fechaHoraInicio;
                //txtFechaTermino.Text = fechaHoraTermino;
                //txtHoraTermino.Text = fechaHoraTermino;
                //txtDirecion.Text = direccion;
                //cbxVigente.Text = estaVigente;
                //txtTipo.Text = tipo;
                //txtObservaciones.Text = observaciones;
                var row_list = (Contrato)listado.dgContratos.SelectedItem;
                numeroContrato = row_list.NumeroContrato;
                txtNumeroContrato.Text = numeroContrato;
                btnAgregar.IsEnabled = false;
                txtNumeroContrato.IsEnabled = false;
                
                
            }
            catch { }
        }

        private void cbConfirmar_Checked(object sender, RoutedEventArgs e)
        {
            Automatizacion();
            btnAgregar.IsEnabled = true;
            txtNumeroContrato.IsEnabled = false;
        }

        private void btnNuevoCliente_Click(object sender, RoutedEventArgs e)
        {
      
            txtNumeroContrato.IsEnabled = false;
            txtCreacion1.IsEnabled = false;
            txtCreacion2.IsEnabled = false;
            txtCreacion3.IsEnabled = false;
            txtNumeroContrato.Text = "Confirmar para Recibir";
            cbxTermino1.IsEnabled = true;
            cbxHoraInicio.IsEnabled = true;
            cbxHoraInicio2.IsEnabled = true;
            cbxFechaInicio1.IsEnabled = true;
            cbxHoraTermino.IsEnabled = true;
            cbxHoraTermino2.IsEnabled = true;
            cbxFechaTermino1.IsEnabled = true;        
            txtDirecion.IsEnabled = true;
            cbxVigente.IsEnabled = true;
            cbxTipo.IsEnabled = true;
            txtObservaciones.IsEnabled = true;
            cbConfirmar.IsEnabled = true;
            btnAgregar.IsEnabled = false;
            if ((cbConfirmar.IsChecked) == true)
            {
                btnAgregar.IsEnabled = true;
            }


        }

   

        private void btnListar_Click_1(object sender, RoutedEventArgs e)
        {

            WindowListaClientes ventana = new WindowListaClientes();
            ventana.Show();
            ventana.btnListarClientesContrato.IsEnabled = false;
            ventana.dgClientes.IsReadOnly = true;


        }

        private void btnTipoEvento_Click(object sender, RoutedEventArgs e)
        {
            WindowTipoEvento ventana = new WindowTipoEvento();
            ventana.Show();

        }

        private void btnListadoContratos_Click(object sender, RoutedEventArgs e)
        {
            
            WindowListaContrato ventana1 = new WindowListaContrato();
            ventana1.dgClientes.IsReadOnly = true;
            ventana1.Show();
        }

        private void txtCreacion1_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void btnCreacion_Click(object sender, RoutedEventArgs e)
        {
            dia = DateTime.Now.Day.ToString();
            mes = DateTime.Now.Month.ToString();
            anio = DateTime.Now.Year.ToString();

            txtCreacion1.Text = (dia.Length < 2 ? 0 + dia : dia);
            txtCreacion2.Text = (mes.Length < 2 ? 0 + mes : mes);
            txtCreacion3.Text = anio;
            txtFechaInicio3.Text = anio;
            txtFechaTermino3.Text = anio;
            txtTermino3.Text = anio;
            //cbxTermino2.Text = (mes.Length < 2 ? 0 + mes : mes);
            //txtFechaInicio2.Text = (mes.Length < 2 ? 0 + mes : mes);
            //txtFechaTermino2.Text = (mes.Length < 2 ? 0 + mes : mes);
            //txtFechaTermino2.Text = (mes.Length < 2 ? 0 + mes : mes);


        }

        private void cbxTipo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                if (cbxTipo.SelectedIndex == 0)
                {
                    txtValorBase.Text = "30";
                }
                else if (cbxTipo.SelectedIndex == 1)
                {
                    txtValorBase.Text = "10";
                }
                else if (cbxTipo.SelectedIndex == 2)
                {
                    txtValorBase.Text = "3";
                }
                else if (cbxTipo.SelectedIndex == 3) {
                    txtValorBase.Text = "6";
                }
                else
                {
                    txtValorBase.Text = "";
                }

            }
            catch(Exception ev) {
                MessageBox.Show(ev.Message);
            }
        }

        private void txtPersonalBase_TextChanged(object sender, TextChangedEventArgs e)
        {
            string v = txtAsistentes.Text;
            try
            {
                if (txtPersonalExtra.Text == "")
                {
                    if (txtAsistentes.Text == "")
                    {
                        txtValorTotal.Text = txtValorBase.Text;
                    }
                    if (int.Parse(txtAsistentes.Text) > 0 && int.Parse(txtAsistentes.Text) < 21)
                    {
                        txtValorTotal.Text = (int.Parse(txtValorBase.Text) + 3).ToString();
                    }
                    else if (int.Parse(txtAsistentes.Text) >= 21 && int.Parse(txtAsistentes.Text) <= 50)
                    {
                        txtValorTotal.Text = (int.Parse(txtValorBase.Text) + 5).ToString();
                    }
                    else if (int.Parse(txtAsistentes.Text) >= 51)
                    {
                        int c = (int.Parse(txtAsistentes.Text) - 50) / 20;
                        txtValorTotal.Text = (int.Parse(txtValorBase.Text) + 5 + (c * 2)).ToString();
                    }
                    else
                    {
                        txtValorTotal.Text = (int.Parse(txtValorBase.Text)).ToString();
                    }
                }
                if (int.Parse(txtPersonalExtra.Text) == 2)
                {
                    txtValorTotal.Text = (int.Parse(txtValorTotal.Text) + 2).ToString();
                }
                else if (int.Parse(txtPersonalExtra.Text) == 3)
                {
                    txtValorTotal.Text = (int.Parse(txtValorTotal.Text) + 3).ToString();
                }
                else if (int.Parse(txtPersonalExtra.Text) == 4)
                {
                    txtValorTotal.Text = (int.Parse(txtValorTotal.Text) + 3.5).ToString();
                }
                else if (int.Parse(txtPersonalExtra.Text) > 4)
                {
                    int c = (int.Parse(txtPersonalExtra.Text) - 4);
                    txtValorTotal.Text = (int.Parse(txtValorTotal.Text) + 3.5 + (c * 0.5)).ToString();
                }
                else {
                    txtValorTotal.Text = (int.Parse(txtValorTotal.Text)).ToString();
                }
            }
            catch (Exception ev)
            {
                MessageBox.Show(ev.Message);

            }

        }

        private void txtAsistentesExtra_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                if (txtAsistentes.Text == "")
                {
                    txtValorTotal.Text = txtValorBase.Text;
                }
                if (int.Parse(txtAsistentes.Text) > 0 && int.Parse(txtAsistentes.Text) < 21)
                {
                    txtValorTotal.Text = (int.Parse(txtValorBase.Text) + 3).ToString();
                }
                else if (int.Parse(txtAsistentes.Text) >= 21 && int.Parse(txtAsistentes.Text) <= 50)
                {
                    txtValorTotal.Text = (int.Parse(txtValorBase.Text) + 5).ToString();
                }
                else if (int.Parse(txtAsistentes.Text) >= 51)
                {
                    int c = (int.Parse(txtAsistentes.Text) - 50) / 20;
                    txtValorTotal.Text = (int.Parse(txtValorBase.Text) + 5 +((c+1)*2)).ToString();
                }
                else
                {
                    txtValorTotal.Text = (int.Parse(txtValorBase.Text)).ToString();
                }
            }

            catch (Exception ev)
            {
                MessageBox.Show(ev.Message);

            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            WindowTipoEvento ventana = new WindowTipoEvento();
            ventana.Show();
        }
    }
}
