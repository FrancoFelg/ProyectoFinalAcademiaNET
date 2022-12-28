using MVC004.Models;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.Metadata.Ecma335;

namespace MVC004.Datos
{
    public class ProveedorDatos
    {

        public List<Proveedores> ListaProv()
        {
            // esta variable recibe la lista de datos
            var listProv=new List<Proveedores>();

            var conexion=new Conexion();
            using(var conexionTemp=new SqlConnection(conexion.getCadenaSQL()))
            {
                //se abre la conexion
                conexionTemp.Open();
                // se instancia un objeto para las querys y se relacionan con el store procedure
                SqlCommand cmd = new SqlCommand("ListaProveedor",conexionTemp );
                cmd.CommandType = CommandType.StoredProcedure;

                //Aqui se realiza la lectura de datos
                using(var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        listProv.Add(new Proveedores()
                        {
                            id = Convert.ToInt32(lector["id"]),
                            nombre = Convert.ToString(lector["nombre"]),
                            ubicacion = Convert.ToString(lector["ubicacion"]),
                            direccion = Convert.ToString(lector["direccion"]),
                            tipo_doc = Convert.ToInt32(lector["tipo_doc"]),
                            nro_doc = (int)Convert.ToInt64(lector["nro_doc"])

                        }) ;

                    }
                }
            }
            return listProv;    
        }

        public Proveedores ObtenerProv(int id)
        {
            var obProveedor=new Proveedores();

            var conexion=new Conexion();
            using( var conexionTemp=new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd=new SqlCommand("GET_Proveedor", conexionTemp);
                cmd.Parameters.AddWithValue("idProv",id);
                cmd.CommandType= CommandType.StoredProcedure;   

                using( var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        obProveedor.id = Convert.ToInt32(lector["id"]);
                        obProveedor.nombre = Convert.ToString(lector["nombre"]);
                        obProveedor.ubicacion = Convert.ToString(lector["ubicacion"]);
                        obProveedor.direccion = Convert.ToString(lector["direccion"]);
                        obProveedor.tipo_doc = Convert.ToInt32(lector["tipo_doc"]);
                        obProveedor.nro_doc = (int)Convert.ToInt64(lector["nro_doc"]);

                    }
                }
            }
            return obProveedor;
        }
        
        public bool AgregarProv(Proveedores obProveedor)
        {
            

            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    // se busca el nombre del sp
                    SqlCommand cmd = new SqlCommand("INS_Proveedor", conexionTemp);
                    // nombre,ubicacion,direccion,tipo_doc,nro_doc
                    cmd.Parameters.AddWithValue("nombre", obProveedor.nombre);
                    cmd.Parameters.AddWithValue("ubicacion", obProveedor.ubicacion);
                    cmd.Parameters.AddWithValue("direccion", obProveedor.direccion);
                    cmd.Parameters.AddWithValue("tipodoc", obProveedor.tipo_doc);
                    cmd.Parameters.AddWithValue("ndoc", obProveedor.nro_doc);
                    
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

        public bool ModificarProv(Proveedores obProveedor)
        {
              bool respuesta;
            try
            {
                var conexion = new Conexion();
                using(var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("UPD_Proveedor", conexionTemp);
                    // sirve para buscar el id a modificar
                    cmd.Parameters.AddWithValue("id", obProveedor.id);
                    // los datos a modificar.
                    cmd.Parameters.AddWithValue("nombre", obProveedor.nombre);
                    cmd.Parameters.AddWithValue("ubicacion", obProveedor.ubicacion);
                    cmd.Parameters.AddWithValue("direccion", obProveedor.direccion);
                    cmd.Parameters.AddWithValue("tipodoc", obProveedor.tipo_doc);
                    cmd.Parameters.AddWithValue("ndoc", obProveedor.nro_doc);

                    cmd.CommandType=CommandType.StoredProcedure;
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

        public bool EliminarProv(int id)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    // busqueda del sp que queremos usar.
                    SqlCommand cmd = new SqlCommand("DEL_Proveedor", conexionTemp);
                    // busqueda del id del registro a eliminar
                    cmd.Parameters.AddWithValue("id",id);


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
