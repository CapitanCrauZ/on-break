using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfOnBreak
{
    class Cliente
    {
        // Variables
        string rut;
        string razonSocial;
        string nombreContacto;
        string mailContacto;
        string direccion;
        string telefono;
        string actividad;
        string tipo;

        // Constructor sin parámetros
        public Cliente(){
        }

        // Sobrecarga Constructor con parámetros
        public Cliente(string rut, string razonSocial, string nombreContacto, string mailContacto, string direccion, string telefono, string actividad, string tipo){
            this.Rut = rut;
            this.RazonSocial = razonSocial;
            this.NombreContacto = nombreContacto;
            this.MailContacto = mailContacto;
            this.Direccion = direccion;
            this.Telefono = telefono;
            this.Actividad = actividad;
            this.Tipo = tipo;
        }

        // Propiedades
        public string Rut { get => rut; set => rut = value; }
        public string RazonSocial { get => razonSocial; set => razonSocial = value; }
        public string NombreContacto { get => nombreContacto; set => nombreContacto = value; }
        public string MailContacto { get => mailContacto; set => mailContacto = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Actividad { get => actividad; set => actividad = value; }
        public string Tipo { get => tipo; set => tipo = value; }

        // Sobreescritura de método ToString()
        public override string ToString(){
            return Rut + ", " + RazonSocial + ", " + NombreContacto + ", " + MailContacto + ", " + Direccion + ", " + Telefono + ", " + Actividad + ", " + Tipo;
        }
    }
}
