using DL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using ML;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace BL
{
    public class Usuario
    {
        public Dictionary<string, object> GetById(int IdUsuario)
        {
            ML.Usuario usuario = new ML.Usuario();
            Dictionary<string, object> resultado = new Dictionary<string, object> { { "Excepcion", "" }, { "Resultado", false }, { "Usuario", IdUsuario } };
            ML.Tarea tarea = new ML.Tarea();
            try
            {
                using (DL.KpalomaresToDoListContext context = new DL.KpalomaresToDoListContext())
                {
                    var objeto = (from UsuarioTarea in context.UsuarioTareaStatuses
                                  join Usuario in context.Usuarios on UsuarioTarea.IdUsuario equals Usuario.IdUsuario 
                                  join Tarea in context.Tareas on UsuarioTarea.IdUsuario equals Tarea.IdTarea
                                  join Status in context.Statuses  on UsuarioTarea.IdUsuario equals Status.IdStatus
                                  where usuario.IdUsuario==IdUsuario
                                  select new { 
                                  IdUsuario=Usuario.IdUsuario,
                                  Nombre= Usuario.Nombre,
                                  ApellidoPaterno=Usuario.ApellidoPaterno,
                                  IdTarea=Tarea.IdTarea,
                                  Titulo=Tarea.Titulo,
                                  Descripcion=Tarea.Descripcion,
                                  FechaVencimiento=Tarea.FechaDeVencimiento,
                                  Status= Status.IdStatus
                                
                                  }).SingleOrDefault();
                    
                    foreach ( var item in objeto )
                    {
                        ML.Usuario usuario1 = new ML.Usuario();
                        usuario1.Nombre = item.Nombre;
                        usuario1.IdUsuario = item.IdUsuario;
                        usuario1.ApellidoPaterno = item.ApellidoPaterno;
                        ML.Tarea tarea1 = new ML.Tarea();
                        tarea1.IdTarea = item.IdTarea;
                        tarea1.Titulo = item.Titulo;
                        tarea1.Descripcion = item.Descripcion;
                        tarea1.FechaVencimiento =item.FechaVencimiento;
                        ML.Status status = new ML.Status();
                        status.IdStatus = item.Status;

                        resultado["Resultado"] = true;
                        resultado["Usuario"] = usuario1;
                    }
                }

            }
            catch (Exception ex)
            {
                resultado["Resultado"] = false;
                resultado["Excepcion"] = ex.Message;
            }


            return resultado;
        }


        public Dictionary<string, object> GetByEmail(string Email, string Password)
        {
            ML.Usuario usuario = new ML.Usuario();
            Dictionary<string, object> resultado = new Dictionary<string, object> { { "Resultado", false }, { "Excepcion", "" }, { "Usuario", null } };
            try
            {
                using (DL.KpalomaresToDoListContext context = new DL.KpalomaresToDoListContext())
                {

                    var objeto = (from Usuario in context.Usuarios
                                  where Usuario.Email == Email
                                  && Usuario.Password == Password

                                  select new
                                  {
                                      Email = Usuario.Email,
                                      Password = Usuario.Password
                                  }).SingleOrDefault();
                    if (objeto != null)
                    {
                        usuario.Email = objeto.Email;

                        resultado["Resultado"] = true;
                        resultado["Usuario"] = usuario;
                    }
                    else
                    {
                        resultado["Resultado"] = false;
                    }
                }
            }
            catch (Exception ex)
            {
                resultado["Resultado"] = false;
                resultado["Excepcion"] = ex.Message;
            }
            return resultado;
        }
    }
}



