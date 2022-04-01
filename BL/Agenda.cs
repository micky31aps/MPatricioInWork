using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Agenda
    {
        public static ML.Result GetAll()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MPatricioInWorkEntities context = new DL.MPatricioInWorkEntities())
                {
                    var GetAllResult = context.AgendaGetAll().ToList();
                    result.Objects = new List<object>();
                    if (GetAllResult != null)
                    {
                        foreach (var obj in GetAllResult)
                        {
                            ML.Agenda agenda = new ML.Agenda();
                            agenda.IdTelefono = obj.IdTelefono;
                            agenda.Nombre = obj.Nombre;
                            agenda.ApellidoPaterno = obj.ApellidoPaterno;
                            agenda.ApellidoMaterno = obj.ApellidoMaterno;
                            agenda.Telefono = obj.Telefono;
                            agenda.Email = obj.Email;
                            result.Objects.Add(agenda);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontraron registros";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result GetById(int IdAgenda)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MPatricioInWorkEntities context = new DL.MPatricioInWorkEntities())
                {
                    var GetByIdResult = context.AgendaGetById(IdAgenda).FirstOrDefault();
                    if (GetByIdResult != null)
                    {
                        ML.Agenda agenda = new ML.Agenda();
                        agenda.IdTelefono = GetByIdResult.IdTelefono;
                        agenda.Nombre = GetByIdResult.Nombre;
                        agenda.ApellidoPaterno = GetByIdResult.ApellidoPaterno;
                        agenda.ApellidoMaterno = GetByIdResult.ApellidoMaterno;
                        agenda.Telefono = GetByIdResult.Telefono;
                        agenda.Email = GetByIdResult.Email;
                        result.Object = agenda;
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se encontro el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Add(ML.Agenda agenda)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MPatricioInWorkEntities context = new DL.MPatricioInWorkEntities())
                {
                    var AddResult = context.AgendaAdd(agenda.Nombre, agenda.ApellidoPaterno, agenda.ApellidoMaterno, agenda.Telefono, agenda.Email);
                    if (AddResult >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "Se agrego correctamente el registro";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Update(ML.Agenda agenda)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MPatricioInWorkEntities context = new DL.MPatricioInWorkEntities())
                {
                    var UpdateResult = context.AgendaUpdate(agenda.IdTelefono, agenda.Nombre, agenda.ApellidoPaterno, agenda.ApellidoMaterno, agenda.Telefono, agenda.Email);
                    if (UpdateResult >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se actualizo el registro correctamente";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
        public static ML.Result Delete(int IdAgenda)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.MPatricioInWorkEntities context = new DL.MPatricioInWorkEntities())
                {
                    var DeleteResult = context.AgendaDelete(IdAgenda);
                    if (DeleteResult >= 1)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                        result.ErrorMessage = "No se elimino el registro correctamente";
                    }
                }
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
                result.Ex = ex;
            }
            return result;
        }
    }
}
