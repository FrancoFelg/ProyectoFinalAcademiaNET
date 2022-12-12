using MVC004.Models;
using System.Data;
using System.Data.SqlClient;


namespace MVC004.Datos
{
    public class ClienteDatos
    {
        public List<Clientes> ListaCliente(){
            var listaClientes = new List<Clientes>();  
            
            var conexion= new Conexion();   
            using(var conexionTemp=new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd=new SqlCommand("ListaCliente",conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        listaClientes.Add(new Clientes()
                        {
                            Id = Convert.ToInt32(lector["id"]),
                            doc_tipo_id = Convert.ToInt32(lector["doc_tipo_id"]),
                            doc_nro = Convert.ToInt32(lector["doc_nro"]),
                            fecha_alta = Convert.ToString(lector["fecha_alta"]),
                            nombre = Convert.ToString(lector["nombre"]),
                            apellido_razsoc = Convert.ToString(lector["apellido_razsoc"]),
                            domicilio = Convert.ToString(lector["domicilio"]),
                            localidad = Convert.ToString(lector["localidad"]),
                            id_usuario = Convert.ToInt32(lector["id_usuario"]),


                        });
                    }
                }
            }
            return listaClientes;   
        }

        public Clientes ObtenerCliente(int id)
        {
            var obCliente = new Clientes();

            var conexion = new Conexion();

            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("ObtenerCliente", conexionTemp);
                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {

                        obCliente.Id = Convert.ToInt32(lector["id"]);
                        obCliente.doc_tipo_id = Convert.ToInt32(lector["doc_tipo_id"]);
                        obCliente.doc_nro = Convert.ToInt32(lector["doc_nro"]);
                        obCliente.fecha_alta = Convert.ToString(lector["fecha_alta"]);
                        obCliente.nombre = Convert.ToString(lector["nombre"]);
                        obCliente.apellido_razsoc = Convert.ToString(lector["apellido_razsoc"]);
                        obCliente.domicilio = Convert.ToString(lector["domicilio"]);
                        obCliente.localidad = Convert.ToString(lector["localidad"]);
                        obCliente.id_usuario = Convert.ToInt32(lector["id_usuario"]);


                    }
                }
                return obCliente;
            }
        }




    }

}
