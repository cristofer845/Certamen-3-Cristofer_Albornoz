using ClassLibraryOTEC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApplicationOtec.Models;

namespace WebApplicationOtec.Controllers
{
    public class AdminstradorController : ApiController
    {
        [HttpGet]
        [Route("api/v1/administrador")]
        public respuesta listar(string cod_administrador = "")
        {
            respuesta resp = new respuesta();
            try
            {
                List<administradores> listado = new List<administradores>();
                administrador adminData = new administrador();
                DataSet data = cod_administrador == "" ? adminData.listadoAD() : adminData.listadoAD(cod_administrador);
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    administradores item = new administradores();
                    item.cod_administrador = data.Tables[0].Rows[i].ItemArray[0].ToString();
                    item.nombre = data.Tables[0].Rows[i].ItemArray[1].ToString();
                    item.correo = data.Tables[0].Rows[i].ItemArray[2].ToString();
                    item.telefono = data.Tables[0].Rows[i].ItemArray[3].ToString();
                    listado.Add(item);
                }
                resp.error = false;
                resp.mensaje = "OK";
                if (listado.Count > 0)
                {
                    resp.data = listado;
                }
                else
                    resp.data = "No se encontro el admin";
                return resp;
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;
            }
        }
        [HttpPost]
        [Route("api/v1/setadministrador")]
        public respuesta guardar(administradores administrador)
        {
            respuesta resp = new respuesta();
            try
            {
                administrador admin = new administrador(administrador.cod_administrador,administrador.nombre, administrador.correo, administrador.telefono);
                int estado = admin.guardar();
                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Admin ingresado correctamente";
                    resp.data = administrador;
                }
                else
                {
                    resp.error = true;
                    resp.mensaje = "No se realizó el ingreso del amdin";
                    resp.data = null;
                }
                return resp;
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;
            }
        }
        [HttpDelete]
        [Route("api/v1/deleteadministrador")]
        public respuesta eliminar(string cod_administrador)
        {
            respuesta resp = new respuesta();
            try
            {
                administrador admin = new administrador();
                admin.Cod_administrador = cod_administrador;
                int estado = admin.eliminar();
                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "admin eliminado correctamente";
                    resp.data = null;
                }
                else
                {
                    resp.error = true;
                    resp.mensaje = "No se realizó la eliminación del admin";
                    resp.data = null;
                }
                return resp;
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;
            }
        }
        [HttpPut]
        [Route("api/v1/updateadministrador")]
        public respuesta actualizar(administradores administrador)
        {
            respuesta resp = new respuesta();
            try
            {
                administrador admin = new administrador(administrador.cod_administrador, administrador.nombre, administrador.correo, administrador.telefono);
                int estado = admin.actualizar(administrador.cod_administrador);
                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "admin Modificado correctamente";
                    resp.data = administrador;
                }
                else
                {
                    resp.error = true;
                    resp.mensaje = "No se realizó la modificación de amdin";
                    resp.data = null;
                }
                return resp;
            }
            catch (Exception e)
            {
                resp.error = true;
                resp.mensaje = "Error:" + e.Message;
                resp.data = null;
                return resp;
            }
        }
    }
}
