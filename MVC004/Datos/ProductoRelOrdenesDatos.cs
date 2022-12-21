using MVC004.Models;
using System.Data.SqlClient;
using System.Data;

namespace MVC004.Datos
{
    public class ProductoRelOrdenesDatos
    {
        public List<ProductoRelOrden> getAllProducts()
        {
            var objLista = new List<ProductoRelOrden>();

            try
            {


                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GET_prodRelOrdenes", conexionTemp);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {

                            objLista.Add(new ProductoRelOrden()
                            {
                                Id = Convert.ToInt32(lector["rel_id"]),

								productoRelProveedor = new ProductoRelProveedor()
                                {
                                    id = Convert.ToInt32(lector["prodRelProv_id"]),
                                    producto = new Producto()
                                    {
                                        id = Convert.ToInt32(lector["prodRelProv_prod_id"]),
                                        nombre = Convert.ToString(lector["nombre"]),
                                    },
                                    precioVenta = Convert.ToInt32(lector["prodRelProv_precio_venta"]),
                                    precioCompra = Convert.ToInt32(lector["prodRelProv_precio_compra"]),
                                    stock = Convert.ToInt32(lector["prodRelProv_stock"])
                                },


                                orden = new Orden()
                                {
                                    id = Convert.ToInt32(lector["ord_id"]),
                                    vendedor = new Empleado()
                                    {
                                        id = Convert.ToInt32(lector["emp_id"]),
                                        nombre = Convert.ToString(lector["emp_nombre"]),
                                        apellidoORazonSocial = Convert.ToString(lector["emp_apellido"]),
                                    },
                                    fechaAlta = DateOnly.FromDateTime(Convert.ToDateTime(lector["ord_fecha_alta"])),
                                    fechaEntrega = DateOnly.FromDateTime(Convert.ToDateTime(lector["ord_fecha_entrega"])),
                                },

                                cantidad = Convert.ToInt32(lector["cantidad"])
                            });

                        }
                    }

                }
            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
            }

            return objLista;
        }
            
        public ProductoRelOrden getProdRelOrdenById(int id)
        {
            var obj = new ProductoRelOrden();
            var conexion = new Conexion();

            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("GET_prodRelOrdenesById", conexionTemp);

                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        {
                            obj.Id = Convert.ToInt32(lector["rel_id"]);

                            obj.productoRelProveedor = new ProductoRelProveedor()
                            {
                                id = Convert.ToInt32(lector["prodRelProv_id"]),
                                producto = new Producto()
                                {
                                    id = Convert.ToInt32(lector["prodRelProv_prod_id"]),
                                    nombre = Convert.ToString(lector["nombre"]),
                                },
                                precioVenta = Convert.ToInt32(lector["prodRelProv_precio_venta"]),
                                precioCompra = Convert.ToInt32(lector["prodRelProv_precio_compra"]),
                                stock = Convert.ToInt32(lector["prodRelProv_stock"])
                            };


                            obj.orden = new Orden()
                            {
                                id = Convert.ToInt32(lector["ord_id"]),
                                vendedor = new Empleado()
                                {
                                    id = Convert.ToInt32(lector["emp_id"]),
                                    nombre = Convert.ToString(lector["emp_nombre"]),
                                    apellidoORazonSocial = Convert.ToString(lector["emp_apellido"]),
                                    docNro = Convert.ToInt32(lector["emp_docNro"])
                                },
                                fechaAlta = DateOnly.FromDateTime(Convert.ToDateTime(lector["ord_fecha_alta"])),
                                fechaEntrega = DateOnly.FromDateTime(Convert.ToDateTime(lector["ord_fecha_entrega"])),
                            };

                            obj.cantidad = Convert.ToInt32(lector["cantidad"]);
                        };
                    }
                }
            }

            return obj;
        }

        public bool save(ProductoRelOrden prod)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("INS_Prod_Rel_Ordenes", conexionTemp);

                    cmd.Parameters.AddWithValue("prodRelProv_id", prod.productoRelProveedor.id);
                    cmd.Parameters.AddWithValue("orden_id", prod.ordenId);                    
                    cmd.Parameters.AddWithValue("cantidad", prod.cantidad);


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
    }


}
