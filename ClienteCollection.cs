using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfOnBreak
{
    class ClienteCollection
    {
        private static List<Cliente> alCliente = new List<Cliente>();
        private static int sw = 0;

        public static int SW { get => sw; set => sw = value; }

        public static Boolean Agregar(Cliente cliente) {
            Boolean estado = false;
            if (cliente != null && Buscar(cliente.Rut) == null) {
                alCliente.Add(cliente);
                estado = true;
            }
            return estado;
        }

        public static Cliente Buscar(string rut) {
            Cliente obj = null;

           foreach (Cliente newcliente in alCliente){
                if (newcliente.Rut.Equals(rut)) {
                    obj = newcliente;
                    break;
                }
            }
            return obj;
        }

        public static bool Eliminar(string rut) {
            bool estado = false;
            foreach (Cliente newcliente in alCliente) {
                if (newcliente.Rut.Equals(rut)) {
                    estado = alCliente.Remove(newcliente);
                    break;
                }
            }
            return estado;
        }
        public static bool Modificar(Cliente cliente) {
            bool estado = false;
            int i = 0;

            foreach (Cliente newcliente in alCliente) {
                if (newcliente.Rut.Equals(cliente.Rut)) {
                    alCliente.Remove(newcliente);
                    alCliente.Insert(i, cliente);

                    estado = true;
                    break;
                }
                i++;
            }
            return estado;
        }

        public static List<Cliente> ObtenerDatos() {
            return alCliente;
        }

        public static void llenar() {
            alCliente.Add(new Cliente("1", "Starbucks", "Gordon Bowker", "Gbawker@gmail.com", "Providencia 355", "95411258", "Alimentos", "Limitada"));
            alCliente.Add(new Cliente("2", "Coca-Cola", "Frank Robinson", "F.ronbinson@gmail.com", "Puente Alto 4673", "93965588", "Alimentos", "EIRL"));
            alCliente.Add(new Cliente("3", "SpDigital", "Richard Ashcroft", "richard.a@gmail.com", "Av.Kennedy 474", "939615511", "Servicios", "SPA"));
            alCliente.Add(new Cliente("4", "Novation", "Ian Jannaway", "JannawayI@gmail.com", "Padre Mariano 355", "93945412", "Servicios", "SociedadAnóinma"));
            SW = 1;
        } 
    }
}

