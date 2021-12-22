using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryOTEC
{
    public class curso
    {
        
        private coordinador coordinador;
        private List<asignatura> asignaturas;
        private int cod_curso;
        private string nombre;
        //constructor  vacio
        
        public curso()
        {
        }
        
        //constructor con datos
       
        public curso(coordinador coordinador, List<asignatura> asignaturas, int cod_curso, string nombre)
        {
            this.coordinador = coordinador;
            this.asignaturas = asignaturas;
            this.cod_curso = cod_curso;
            this.nombre = nombre;
        }
        
        //get y set
        public coordinador Coordinador { get => coordinador; set => coordinador = value; }
        public List<asignatura> Asignaturas { get => asignaturas; set => asignaturas = value; }
        public int Cod_curso { get => cod_curso; set => cod_curso = value; }
        public string Nombre { get => nombre; set => nombre = value; }
    }
}
