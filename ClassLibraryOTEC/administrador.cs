using ClassLibraryDatos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryOTEC
{
    public class administrador
    {
        private string cod_administrador;
        private string nombre;
        private string correo;
        private string telefono;

        public administrador(string cod_administrador, string nombre, string correo)
        {
        }

        public administrador(string cod_administrador, string nombre, string correo, string telefono)
        {
            this.cod_administrador = cod_administrador;
            this.nombre = nombre;
            this.correo = correo;
            this.telefono = telefono;
        }

        public administrador()
        {
        }

        public string Cod_administrador { get => cod_administrador; set => cod_administrador = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Correo { get => correo; set => correo = value; }
        public string Telefono { get => telefono; set => telefono = value; }



        datos data = new datos();
        public DataSet listadoAD()
        {
            return data.listado("SELECT * FROM CR_ADMINISTRADOR");
        }
        public DataSet listadoAD(string cod_administrador)
        {
            return data.listado("SELECT * FROM CR_ADMINISTRADOR WHERE cod_administrador= '" + cod_administrador + "'");
        }
        public int guardar()
        {
            return data.ejecutar("INSERT INTO CR_ADMINISTRADOR(cod_administrador, nombre,telefono,correo) values('" + this.cod_administrador + "','" + this.nombre + "','" + this.telefono + "','" + this.correo + "')");
        }
        public int eliminar()
        {
            return data.ejecutar("DELETE FROM CR_ADMINISTRADOR WHERE  cod_administrador= '" + this.cod_administrador + "'");
        }

        public int actualizar(string Cod_asignatura)
        {
            return data.ejecutar("UPDATE CR_ADMINISTRADOR SET nombre='" + this.nombre+ "' WHERE cod_administrador='" + cod_administrador + "'");
        }
    }
}


