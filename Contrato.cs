using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace WpfOnBreak
{
    class Contrato
    {
        // Variables
        string numeroContrato;
        string creacion;
        string termino;
        string fechaHoraInicio;
        string fechaHoraTermino;
        string direccion;
        string estaVigente;
        string tipo;
        string observaciones;
        int asistentes;
        int total;

        // Constructor sin parámetros
        public Contrato(){
        }

        // Sobrecarga Construcor con parámetros
        public Contrato(string numeroContrato, string creacion, string termino, string fechaHoraInicio, string fechaHoraTermino, string direccion, string estaVigente, string tipo, string observaciones, int asistentes, int total){
            this.NumeroContrato = numeroContrato;
            this.Creacion = creacion;
            this.Termino = termino;
            this.FechaHoraInicio = fechaHoraInicio;
            this.FechaHoraTermino = fechaHoraTermino;
            this.Direccion = direccion;
            this.EstaVigente = estaVigente;
            this.Tipo = tipo;
            this.Observaciones = observaciones;
            this.Asistentes = asistentes;
            this.Total = total;
        }

        // Propiedades
        public string NumeroContrato { get => numeroContrato; set => numeroContrato = value; }
        public string Creacion { get => creacion; set => creacion = value; }
        public string Termino { get => termino; set => termino = value; }
        public string FechaHoraInicio { get => fechaHoraInicio; set => fechaHoraInicio = value; }
        public string FechaHoraTermino { get => fechaHoraTermino; set => fechaHoraTermino = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string EstaVigente { get => estaVigente; set => estaVigente = value; }
        public string Tipo { get => tipo; set => tipo = value; }
        public string Observaciones { get => observaciones; set => observaciones = value; }
        public int Asistentes { get => asistentes; set => asistentes = value; }
        public int Total { get => total; set => total = value; }

        // Sobreescritura de método ToString()
        public override string ToString(){
            return NumeroContrato + ", " + Creacion + ", " + Termino + ", " + FechaHoraInicio + ", " + FechaHoraTermino + ", " + Direccion + ", " + EstaVigente + ", " + Tipo + ", " + Observaciones + ", " + Asistentes + ", " + Total;

        }

     
    }
}
