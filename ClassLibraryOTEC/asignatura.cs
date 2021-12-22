using ClassLibraryDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryOTEC
{
    public class asignatura
    {
        
        private string cod_asignatura;
        private string nombre_a;
        private string profesor;

        
        
        public asignatura()
        {
        }
        
      
        
        public asignatura(string cod_asignatura, string nombre_a, string profesor)
        {
            this.cod_asignatura = cod_asignatura;
            this.nombre_a = nombre_a;
            this.profesor = profesor;
        }
        
      
        public string Cod_asignatura { get => cod_asignatura; set => cod_asignatura = value; }
        public string Nombre_a { get => nombre_a; set => nombre_a = value; }
        public string Profesor { get => profesor; set => profesor = value; }


        datos data = new datos();
        public DataSet listadoAs()
        {
            return data.listado("SELECT * FROM CRS_ASIGNATURA");
        }
        public DataSet listadoAs(string Cod_asignatura)
        {
            return data.listado("SELECT * FROM CRS_ASIGNATURA WHERE Cod_asignatura= '" + Cod_asignatura + "'");
        }
        public int guardar()
        {
            return data.ejecutar("INSERT INTO CRS_ASIGNATURA(Cod_asignatura, nombre_a) values('" + this.Cod_asignatura + "','" + this.nombre_a + "')");
        }
        public int eliminar()
        {
            return data.ejecutar("DELETE FROM CRS_ASIGNATURA WHERE  Cod_asignatura= '" + this.Cod_asignatura + "'");
        }

        public int actualizar(string Cod_asignatura)
        {
            return data.ejecutar("UPDATE CRS_ASIGNATURA SET nombre_a='" + this.nombre_a + "' WHERE Cod_asignatura='" + Cod_asignatura + "'");
        }
    }
}

 
