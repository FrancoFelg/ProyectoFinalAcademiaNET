using MVC004.Models;
using System.Data.SqlClient;
using System.Data;

namespace MVC004.Datos
{
    public class ProductoRelProveedoresDatos
    {
        public bool save(ProductoRelProveedor prodRelProv)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("INS_Prod_Rel_Prov", conexionTemp);


                    cmd.Parameters.AddWithValue("producto_id", prodRelProv.productoId);
                    cmd.Parameters.AddWithValue("proveedor_id", prodRelProv.proveedorId);
                    cmd.Parameters.AddWithValue("stock", prodRelProv.stock);
                    cmd.Parameters.AddWithValue("precio_compra", prodRelProv.precioCompra);
                    cmd.Parameters.AddWithValue("precio_venta", prodRelProv.precioVenta);


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
    
        public List<ProductoRelProveedor> getAllProducts()
        {
            var objLista = new List<ProductoRelProveedor>();

            try
            {

                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GET_Prod_Rel_Proveedores", conexionTemp);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {

                            objLista.Add(new ProductoRelProveedor()
                            {
                                id = Convert.ToInt32(lector["prod_rel_prov_id"]),
                                producto = new Producto()
                                {
                                    id = Convert.ToInt32(lector["prod_id"]),
                                    nombre = Convert.ToString(lector["prod_nombre"])
                                },
                                proveedor = new Proveedores()
                                {
                                    id = Convert.ToInt32(lector["prov_id"]),
                                    direccion = Convert.ToString(lector["prov_direccion"]),
                                    ubicacion = Convert.ToString(lector["prov_ubicacion"]),
                                    nro_doc = Convert.ToInt32(lector["prov_nro_doc"]),
                                    nombre = Convert.ToString(lector["prov_nombre"]),
                                },
                                stock = Convert.ToInt32(lector["stock"]),
                                precioCompra = Convert.ToInt32(lector["precio_compra"]),
                                precioVenta = Convert.ToInt32(lector["precio_venta"]),
                            });
                        } 
                    } 
                }

                
            }catch(Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }

            return objLista;
        }

        internal ProductoRelProveedor getById(int id)
        {           
            var obj = new ProductoRelProveedor();
            var conexion = new Conexion();

            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("GET_Prod_Rel_Prov_ById", conexionTemp);

                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        obj = new ProductoRelProveedor()
                        {
                            id = Convert.ToInt32(lector["prod_rel_prov_id"]),
                            
                            producto = new Producto()
                            {
                                id = Convert.ToInt32(lector["prod_id"]),
                                nombre = Convert.ToString(lector["prod_nombre"]),
                            },

                            proveedor = new Proveedores()
                            {
                                id = Convert.ToInt32(lector["prov_id"]),
                                nombre = Convert.ToString(lector["prov_nombre"]),
                                direccion = Convert.ToString(lector["prov_direccion"]),
                                ubicacion = Convert.ToString(lector["prov_ubicacion"]),
                                nro_doc = Convert.ToInt32(lector["prov_nro_doc"])
                            },

                            stock = Convert.ToInt32(lector["prod_rel_prov_stock"]),
                            precioCompra = Convert.ToInt32(lector["prod_rel_prov_precio_compra"]),
                            precioVenta = Convert.ToInt32(lector["prod_rel_prov_precio_venta"]),
                        };
                    }


                    //TODO - No se pueden ver estos datos porque son pertenecientes a tablas intermedias


                }
                return obj;
            }            
        }
    }
}
