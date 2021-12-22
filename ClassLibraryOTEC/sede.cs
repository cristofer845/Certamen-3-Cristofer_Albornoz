using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryOTEC
{
    public class sede
    {
        
        private int id_Sede;
        private string nombre;
        private administrador administrador;
        private List<curso> cursos;
       

        //constructor  vacio
       
        public sede()
        {
        }

       
        //constructor con datos
        
        public sede(int id_Sede, string nombre, administrador administrador, List<curso> cursos)
        {
            this.Id_Sede = id_Sede;
            this.Nombre = nombre;
            this.Administrador = administrador;
            this.cursos = cursos;
        }
        
        //get y set
        public int Id_Sede { get => id_Sede; set => id_Sede = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public administrador Administrador { get => administrador; set => administrador = value; }
        public List<curso> Cursos { get => cursos; set => cursos = value; }
    }
}