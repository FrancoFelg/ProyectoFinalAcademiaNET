using MVC004.Models;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;

namespace MVC004.Datos {
   
    public class ProductoDatos

    {
        public List<Producto> getAllProducts()
        {
            var objLista = new List<Producto>();

            var conexion = new Conexion();
            using( var conexionTemp= new SqlConnection(conexion.getCadenaSQL() ) )
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("Product_GetAll", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;

                using(var lector = cmd.ExecuteReader())
                {
                    while(lector.Read())
                    {
                        objLista.Add(new Producto()
                        {
                            id = Convert.ToInt32(lector["id"]),
                            nombre = Convert.ToString(lector["nombre"]),
                        });
                    }
                }

            }

            return objLista;
        }
        
        public Producto getById(int id)
        {
            var objProducto = new Producto();
            var conexion = new Conexion();

            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("GET_ProductById", conexionTemp);

                cmd.Parameters.AddWithValue( "id", id );
                cmd.CommandType = CommandType.StoredProcedure;

                using(var lector = cmd.ExecuteReader())
                {
                    while(lector.Read())
                    {

                        objProducto.id = Convert.ToInt32(lector["id"]);
                        objProducto.nombre = Convert.ToString(lector["nombre"]);                        
                        
                    }
                }
            }

            return objProducto;
        }

        public bool save(Producto producto) {
            bool respuesta;

            try
            {
                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("Guardar", conexionTemp);

                    
                    cmd.Parameters.AddWithValue("nombre", producto.nombre);
                    

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

        public bool edit(Producto producto)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();
                using(var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("UPD_Product", conexionTemp);

                    cmd.Parameters.AddWithValue("id", producto.id);
                    cmd.Parameters.AddWithValue("nombre", producto.nombre);

                    cmd.CommandType= CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    respuesta = true;
                }
            }catch(Exception e)
            {
                string error = e.Message;
                System.Diagnostics.Debug.WriteLine("UPD_Error:" + e);
                respuesta = false;
            }
            return respuesta;
        }

        public bool deleteById(int id)
        {
            bool respuesta;

            try
            {

                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("DEL_Product", conexionTemp);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                }
                respuesta = true;

            }catch(Exception e)
            {
                string error = e.Message;
                System.Diagnostics.Debug.WriteLine(e);
                respuesta = false;
            }


            return respuesta;
        }
    }
 }
