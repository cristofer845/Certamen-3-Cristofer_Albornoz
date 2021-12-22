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
    public class AsignaturaController : ApiController
    {
        [HttpGet]
        [Route("api/v1/asignatura")]
        public respuesta listar(string cod_asignatura = "")
        {
            respuesta resp = new respuesta();
            try
            {
                List<asignaturas> listado = new List<asignaturas>();
                asignatura asigData = new asignatura();
                DataSet data = cod_asignatura == "" ? asigData.listadoAs() : asigData.listadoAs(cod_asignatura);
                for (int i = 0; i < data.Tables[0].Rows.Count; i++)
                {
                    asignaturas item = new asignaturas();
                    item.cod_asignatura = data.Tables[0].Rows[i].ItemArray[0].ToString();
                    item.nombre_a = data.Tables[0].Rows[i].ItemArray[1].ToString();
                    item.profesor = data.Tables[0].Rows[i].ItemArray[2].ToString();
                    listado.Add(item);
                }
                resp.error = false;
                resp.mensaje = "OK";
                if (listado.Count > 0)
                {
                    resp.data = listado;
                }
                else

                    resp.data = "No se encontro la asignatura";
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
        [Route("api/v1/setasignatura")]
        public respuesta guardar(asignaturas asignatura)
        {
            respuesta resp = new respuesta();
            try
            {
                asignatura asig = new asignatura(asignatura.cod_asignatura, asignatura.nombre_a,asignatura.profesor);
                int estado = asig.guardar();
                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Asignatura ingresada correctamente";
                    resp.data = asignatura;
                }
                else
                {
                    resp.error = true;
                    resp.mensaje = "No se realizó el ingreso de la asignatura";
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
        [Route("api/v1/deleteasignatura")]
        public respuesta eliminar(string cod_asignatura)
        {
            respuesta resp = new respuesta();
            try
            {
                asignatura asig = new asignatura();
                asig.Cod_asignatura = cod_asignatura;
                int estado = asig.eliminar();
                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Asignatura eliminada correctamente";
                    resp.data = null;
                }
                else
                {
                    resp.error = true;
                    resp.mensaje = "No se realizó la eliminación de la asignatura";
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
        [Route("api/v1/updateasignatura")]
        public respuesta actualizar(asignaturas asignatura)
        {
            respuesta resp = new respuesta();
            try
            {
                asignatura asig = new asignatura(asignatura.cod_asignatura, asignatura.nombre_a,asignatura.profesor);
                int estado = asig.actualizar(asignatura.cod_asignatura);
                if (estado == 1)
                {
                    resp.error = false;
                    resp.mensaje = "Asignatura Modificada exito";
                    resp.data = asignatura;
                }
                else
                {
                    resp.error = true;
                    resp.mensaje = "No se realizó la modificación error";
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