using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryOTEC
{
    public class coordinador
    {
        
        private int cod_Coordinador;
        private string Nombre_c;
        private string telefono;
        private string direccion;
        private string corrreo;

        //constructor  vacio
       
        public coordinador()
        {

        }
        
        //constructor con datos
        
        public coordinador(int cod_Coordinador, string nombre_c, string telefono, string direccion, string corrreo)
        {
            this.cod_Coordinador = cod_Coordinador;
            Nombre_c = nombre_c;
            this.telefono = telefono;
            this.direccion = direccion;
            this.corrreo = corrreo;
        }
       
        //get y set
        public int Cod_Coordinador { get => cod_Coordinador; set => cod_Coordinador = value; }
        public string Nombre_c1 { get => Nombre_c; set => Nombre_c = value; }
        public string Telefono { get => telefono; set => telefono = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public string Corrreo { get => corrreo; set => corrreo = value; }
    }
}
