using Microsoft.Data.SqlClient;
using MVC004.Models;
using System.Data;

namespace MVC004.Datos
{
    public class EmpleadoDatos
    {
        public List<Empleados> ListaEmpleados()
        {
            var listaEmpleados = new List<Empleados>();

            var conexion = new Conexion();
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("ListaEmpleados", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        listaEmpleados.Add(new Empleados()
                        {
                            Id = Convert.ToInt32(lector["id"]),
                            doc_tipo_id = Convert.ToInt32(lector["doc_tipo_id"]),
                            doc_nro = Convert.ToInt32(lector["doc_nro"]),
                            fecha_alta = Convert.ToString(lector["fecha_alta"]),
                            nombre = Convert.ToString(lector["nombre"]),
                            apellido_razsoc = Convert.ToString(lector["apellido_razsoc"]),
                            id_usuario = Convert.ToInt32(lector["id_usuario"]),


                        });
                    }
                }
            }
            return listaEmpleados;
        }

        public Proveedores ObtenerEmpleados(int id)
        {
            var obEmpleados = new Proveedores();

            var conexion = new Conexion();
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("ObtenerProvedor", conexionTemp);
                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        obEmpleados.id = Convert.ToInt32(lector["id"]);
                        obEmpleados.nombre = Convert.ToString(lector["nombre"]);
                        obEmpleados.tipo_doc = Convert.ToInt32(lector["tipo_doc"]);
                        obEmpleados.nro_doc = (int)Convert.ToInt64(lector["nro_doc"]);

                    }
                }
            }
            return obEmpleados;
        }




    }
}
