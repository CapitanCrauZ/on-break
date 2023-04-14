using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfOnBreak
{
    class TipoEvento
    {
        // Variables
        string id;
        string nombre;
        int valorBase;
        int personalBase;

        // Constructor sin parámetros
        public TipoEvento(){
        }

        // Sobrecarga Constructor con parámetros
        public TipoEvento(string id, string nombre, int valorBase, int personalBase){
            this.Id = id;
            this.Nombre = nombre;
            this.ValorBase = valorBase;
            this.PersonalBase = personalBase;
        }

        // Propiedades
        public string Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public int ValorBase { get => valorBase; set => valorBase = value; }
        public int PersonalBase { get => personalBase; set => personalBase = value; }

        // Sobreescitura método ToString()
        public override string ToString(){
            return Id + ", " + Nombre + ", " + ValorBase + ", " + PersonalBase;
        }

        // Lista Tipo evento
        public static List<TipoEvento> alTipoEvento = new List<TipoEvento>();

        // Métodos
        public static bool Agregar(TipoEvento tipoevento){
            // Campos
            bool estado = false;

            if (tipoevento != null && Buscar(tipoevento.Id) == null){
                alTipoEvento.Add(tipoevento);
                estado = true;
            }
            return estado;
        }

        public static TipoEvento Buscar(string id){
            // Campos
            TipoEvento obj = null;

            foreach (TipoEvento newtipoevento in alTipoEvento){
                if (newtipoevento.Id.Equals(id)){
                    obj = newtipoevento;
                    break;
                }
            }
            return obj;
        }

        // Lista 
        public List<TipoEvento> ObtenerDatos() {
            return alTipoEvento;
        }

        // ????
        public static int sw = 0;

        public static int SW { get => sw; set => sw = value; }

        public void llenar() {
            alTipoEvento.Add(new TipoEvento("1", "Aniversario", 30, 15));
            alTipoEvento.Add(new TipoEvento("2", "Despedida", 10, 10));
            alTipoEvento.Add(new TipoEvento("3", "Conmemoración", 3, 18));
            alTipoEvento.Add(new TipoEvento("4", "Reapertura", 6, 10));
            sw = 1;
        }

    }
}
