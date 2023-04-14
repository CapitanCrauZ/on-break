using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfOnBreak
{
    class ContratoCollection
    {
        private static List<Contrato> alContrato = new List<Contrato>();
        private static int sw = 0;

        public static int SW { get => sw; set => sw = value; }
        public static Boolean Agregar(Contrato contrato) {
            Boolean estado = false;
            if (contrato != null && Buscar(contrato.NumeroContrato) == null) {
                alContrato.Add(contrato);
                estado = true;
            }
            return estado;
        }

        public static Contrato Buscar(string numeroContrato) {
            Contrato obj = null;

            foreach (Contrato newcontrato in alContrato) {
                if (newcontrato.NumeroContrato.Equals(numeroContrato)) {
                    obj = newcontrato;
                    break;
                }
            }
            return obj;
        }
        public static bool Eliminar(string numeroContrato) {
            bool estado = false;
            foreach (Contrato newcontrato in alContrato) {
                if (newcontrato.NumeroContrato.Equals(numeroContrato)) {
                    estado = alContrato.Remove(newcontrato);
                    break;
                }
            }
            return estado;
        }
        public static bool Modificar(Contrato contrato) {
            bool estado = false;
            int i = 0;

            foreach (Contrato newcontrato in alContrato) {
                if (newcontrato.NumeroContrato.Equals(contrato.NumeroContrato)) {
                    alContrato.Remove(newcontrato);
                    alContrato.Insert(i, contrato);

                    estado = true;
                    break;
                }
                i++;
            }
            return estado;
        }

        public static List<Contrato> ObtenerDatos() {
            return alContrato;
        }

        public static void llenar() {
            alContrato.Add(new Contrato("121321112", "02-04-2020", "04-04-2020", "(03-04-2020, 08:30:00)", "(03-04-2020, 16:00:00)", "AV.Mara 211", "Si", "1", "sin comentarios", 25, 12));
            alContrato.Add(new Contrato("837438432", "01-04-2020", "03-04-2020", "(02-04-2020, 10:40:00)", "(02-04-2020, 13:30:00)", "Arturo Prat 412", "Si", "2", "sin comentarios", 10, 10));
            alContrato.Add(new Contrato("412411241", "03-04-2020", "05-04-2020", "(04-04-2020, 11:56:40)", "(04-04-2020, 14:30:00)", "Balmaceda 2919", "Si", "3", "sin comentarios", 45, 26));
            alContrato.Add(new Contrato("412551552", "02-04-2020", "05-04-2020", "(03-04-2020, 23:17:24)", "(04-04-2020, 01:45:00)", "Los Ciruelos 1215", "Si", "4", "sin comentarios", 30, 14));
            SW = 1;
        }
    }
}
