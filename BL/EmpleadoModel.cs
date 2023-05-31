using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class EmpleadoModel
    {
        public static ML.Result GetALL()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.UEstebanApesaEntities context = new DL.UEstebanApesaEntities())
                {

                    var cadena = context.Database.SqlQuery<ML.Empleado>("Select Nombre,ApellidoPaterno,ApellidoMaterno, Edad,Estado FROM Empleado").ToList();

                    if (cadena.Count > 0)
                    {
                        result.Objects = new List<object>();
                        foreach (var item in cadena)
                        {
                            ML.Empleado empleado = item;
                            result.Objects.Add(empleado);
                        }
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
            }
            return result;
        }

        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using (DL.UEstebanApesaEntities context = new DL.UEstebanApesaEntities())
                {
                    //var query = context.Database.SqlQuery<ML.Empleado>($"Insert Into Empleado (Nombre,ApellidoPaterno,ApellidoMaterno,Edad Estatus)values('{empleado.Nombre}','{empleado.ApellidoPaterno}','{empleado.ApellidoMaterno}',{empleado.Edad},{1})");
                    var query = context.Database.ExecuteSqlCommand($"Insert Into Empleado (Nombre,ApellidoPaterno,ApellidoMaterno,Edad, Estado)values('{empleado.Nombre}','{empleado.ApellidoPaterno}','{empleado.ApellidoMaterno}',{empleado.Edad},{1})");

                    if (query != null)
                    {
                        result.Correct = true;
                    }
                    else
                    {
                        result.Correct = false;
                    }
                }
            }
            catch (Exception e)
            {
                result.Correct = false;
                result.ErrorMessage = e.Message;
            }
            return result;
        }
    }
}
