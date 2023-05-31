using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class Empleado
    {
        public static ML.Result Get()
        {
            ML.Result result = new ML.Result();
            try
            {
                using (SqlConnection conn = new SqlConnection(DL.Conexion.Cadena()))
                {
                    string query = "Select IdEmpleado, Nombre, ApellidoPaterno, ApellidoMaterno, Edad From Empleado";
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        cmd.Connection = conn;
                        cmd.CommandText = query;

                        DataTable EmpleadoDt = new DataTable();
                        SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);

                        sqlDataAdapter.Fill(EmpleadoDt);

                        if (EmpleadoDt.Rows.Count > 0)
                        {
                            result.Objects = new List<object>();
                            foreach (DataRow row in EmpleadoDt.Rows)
                            {
                                ML.Empleado empleado = new ML.Empleado();

                                empleado.IdEmpleado = (int)row[0];
                                empleado.Nombre = (String)row[1];
                                empleado.ApellidoPaterno = (String)row[2];
                                empleado.ApellidoMaterno = (String)row[3];
                                empleado.Edad = (int)row[4];

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
            }
            catch (Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        //public static ML.Result Add(ML.Empleado empleado)
        //{
        //    ML.Result result = new ML.Result();
        //    try
        //    {
        //        using (SqlConnection conn = new SqlConnection(DL.Conexion.Cadena()))
        //        {
        //            string query = "INSERT INTO Empleado (Nombre,ApellidoPaterno,ApellidoMaterno,Edad)VALUES(@Nombre,@ApellidoPaterno,@ApellidoMaterno,@Edad)";
        //            using (SqlCommand command = new SqlCommand(query, conn))
        //            {
        //                SqlParameter[] parameters = new SqlParameter[4];

        //                parameters[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
        //                parameters[0].Value = empleado.Nombre;

        //                parameters[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
        //                parameters[1].Value = empleado.ApellidoPaterno;

        //                parameters[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
        //                parameters[2].Value = empleado.ApellidoMaterno;

        //                parameters[3] = new SqlParameter("Edad", SqlDbType.Int);
        //                parameters[3].Value = empleado.Edad;

        //                command.Parameters.AddRange(parameters);
        //                command.Connection.Open();

        //                int rowAfectadas = command.ExecuteNonQuery();

        //                if (rowAfectadas > 0)
        //                {
        //                    result.Correct = true;
        //                }
        //                else
        //                {
        //                    result.Correct = false;
        //                }

        //            }
        //        }

        //    }
        //    catch (Exception ex)
        //    {
        //        result.Correct = false;
        //        result.ErrorMessage = ex.Message;
        //    }
        //    return result;
        //}

        //3:09
        public static ML.Result Add(ML.Empleado empleado)
        {
            ML.Result result = new ML.Result();
            try
            {
                using(SqlConnection conn =  new SqlConnection(DL.Conexion.Cadena()))
                {
                    string query = "INSERT INTO Empleado (Nombre, ApellidoPaterno, ApellidoMaterno, Edad)VALUES(@Nombre, @ApeliidoPaterno, @ApellidoMaterno,@Edad)";
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        SqlParameter[] parameters = new SqlParameter[4];

                        parameters[0] = new SqlParameter("Nombre", SqlDbType.VarChar);
                        parameters[0].Value = empleado.Nombre;

                        parameters[1] = new SqlParameter("ApellidoPaterno", SqlDbType.VarChar);
                        parameters[1].Value = empleado.ApellidoPaterno;

                        parameters[2] = new SqlParameter("ApellidoMaterno", SqlDbType.VarChar);
                        parameters[2].Value = empleado.ApellidoMaterno;

                        parameters[3] =  new SqlParameter("Edad",SqlDbType.Int);
                        parameters[3].Value = empleado.Edad;

                        command.Connection.Open();
                        command.Parameters.AddRange(parameters);

                        int rowAfectadas = command.ExecuteNonQuery();
                        if(rowAfectadas > 0)
                        {
                            result.Correct = true;
                        }
                        else
                        {
                            result.Correct = false;
                        }
                    }
                }
            }
            catch(Exception ex)
            {
                result.Correct = false;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
    }
}
