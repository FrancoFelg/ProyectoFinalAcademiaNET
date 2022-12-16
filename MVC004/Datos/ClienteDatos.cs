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

        public Clientes ObtenerCli(int id)
        {
            var obCliente = new Clientes();

            var conexion = new Conexion();

            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("GET_Cliente", conexionTemp);
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

        public bool AgregarCli(Clientes obCliente)
        {
           
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    // se busca el nombre del sp
                    SqlCommand cmd = new SqlCommand("INS_Cliente", conexionTemp);
                    // nombre,ubicacion,direccion,tipo_doc,nro_doc
                    cmd.Parameters.AddWithValue("tipodoc", obCliente.doc_tipo_id);
                    cmd.Parameters.AddWithValue("numdoc", obCliente.doc_nro);
                    cmd.Parameters.AddWithValue("nombre", obCliente.nombre);
                    cmd.Parameters.AddWithValue("apellido", obCliente.apellido_razsoc);
                    cmd.Parameters.AddWithValue("domicilio", obCliente.domicilio);
                    cmd.Parameters.AddWithValue("localidad", obCliente.localidad);
                    cmd.Parameters.AddWithValue("idusuario", obCliente.id_usuario);
                    cmd.CommandType = CommandType.StoredProcedure;
                    //ejecucion del sp
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
                System.Diagnostics.Debug.WriteLine(e);


            }
            return respuesta;

        }

        public bool ModificarCli(Clientes obCliente)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("UPD_cliente", conexionTemp);
                    // sirve para buscar el id a modificar
                    cmd.Parameters.AddWithValue("id", obCliente.Id);
                    // los datos a modificar.
                    cmd.Parameters.AddWithValue("tipodoc", obCliente.doc_tipo_id);
                    cmd.Parameters.AddWithValue("numdoc", obCliente.doc_nro);
                    cmd.Parameters.AddWithValue("nombre", obCliente.nombre);
                    cmd.Parameters.AddWithValue("apellido", obCliente.apellido_razsoc);
                    cmd.Parameters.AddWithValue("domicilio", obCliente.domicilio);
                    cmd.Parameters.AddWithValue("localidad", obCliente.localidad);
                

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();


                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                System.Diagnostics.Debug.WriteLine(e);
                respuesta = false;
            }
            return respuesta;

        }

        public bool EliminarCli(int id)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    // busqueda del sp que queremos usar.
                    SqlCommand cmd = new SqlCommand("DEL_Cliente", conexionTemp);
                    // busqueda del id del registro a eliminar
                    cmd.Parameters.AddWithValue("id", id);


                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                respuesta = false;
            }
            return respuesta;

        }





    }

}
