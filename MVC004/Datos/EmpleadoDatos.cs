using Microsoft.Data.SqlClient;
using MVC004.Models;
using System.Data;

namespace MVC004.Datos
{
    public class EmpleadoDatos
    {
        public List<Empleados> ListaEmpleados()
        {
            var lista = new List<Empleados>();  
            var conexion=new Conexion();

            using (var conexionTemp=new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd=new SqlCommand("ListaEmpleados",conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var lector =cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        lista.Add(new Empleados()
                        {
                            Id = Convert.ToInt32(lector["id"]),
                            doc_tipo_id = Convert.ToInt32(lector["doc_tipo_id"]),
                            doc_nro = Convert.ToInt32(lector["doc_nro"]),
                            fecha_alta = Convert.ToString(lector["fecha_alta"]),
                            nombre = Convert.ToString(lector["nombre"]),
                            apellido_razsoc = Convert.ToString(lector["apellido_razsoc"]),
                            id_usuario = Convert.ToInt32(lector["id_usuario"]),






                        }); ; 

                    }

                }
                return lista;

            }
        }

       




    }
}
