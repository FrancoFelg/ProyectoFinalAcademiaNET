using MVC004.Models;
using System.Data.SqlTypes;
using System.Data.SqlClient;
using System.Data;
using Microsoft.AspNetCore.Mvc;
using System.Reflection.Metadata.Ecma335;
using System.Xml.Linq;

namespace MVC004.Datos

{
    public class PromocionDatos
    {
        public List<Promocion> getAll()
        {
            List<Promocion> list = new List<Promocion>();
            var conexion = new Conexion();

            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("GET_PromocionANDProducto", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        list.Add(new Promocion()
                        {
                            id = Convert.ToInt32(lector["promocion_id"]),
                            producto = new Producto()
                            {
                                id = Convert.ToInt32(lector["id_producto"]),
                                nombre = Convert.ToString(lector["nombre"])
                            },
                            descuento = float.Parse(Convert.ToString(lector["descuento"])),
                            fechaDesde = DateOnly.FromDateTime(Convert.ToDateTime(lector["fecha_desde"])),
                            fechaHasta = DateOnly.FromDateTime(Convert.ToDateTime(lector["fecha_hasta"])),
                            vigencia = Convert.ToBoolean(lector["vigencia"])
                        });
                    }
                }
            }

            return list;
        }

        public Promocion getById(int id)
        {
            var promocion = new Promocion();
            var conexion = new Conexion();

            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("GET_PromocionByIdTOUPD", conexionTemp);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", id);

                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        promocion.id = Convert.ToInt32(lector["promocion_id"]);
                        promocion.productoId = Convert.ToInt32(lector["producto_id"]);
                        promocion.descuento = float.Parse(Convert.ToString(lector["descuento"]));                        
                        promocion.fechaHasta = DateOnly.FromDateTime(Convert.ToDateTime(lector["fecha_hasta"]));
                        promocion.vigencia = Convert.ToBoolean(lector["vigencia"]);
                    }
                }
            }
            return promocion;
        }

        public bool save(Promocion promocion)
        {
            bool rta;
            var conexion = new Conexion();


            try
            {
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("INS_Promocion", conexionTemp);                    
                    cmd.Parameters.AddWithValue("producto_id", promocion.productoId);
                    cmd.Parameters.AddWithValue("descuento", promocion.descuento);                    

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                rta = true;
            }

            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                rta = false;
            }

            return rta;
        }

        public bool edit(Promocion promocion)
        {
            bool rta;
            var conexion = new Conexion();

            System.Diagnostics.Debug.WriteLine("descuento = " + promocion.descuento);
            System.Diagnostics.Debug.WriteLine("vigencia = " + promocion.vigencia);
            System.Diagnostics.Debug.WriteLine("fecha_hasta = " + promocion.fechaHasta);
            promocion.fechaHasta = DateOnly.FromDateTime(DateTime.Today);
            DateTime fecha = new DateTime(2019,05,09,0,0,0,0); //DateTime.Parse(promocion.fechaHasta.ToString());
            System.Diagnostics.Debug.WriteLine("fecha_hasta = " + promocion.fechaHasta);
            System.Diagnostics.Debug.WriteLine("fecha = " + fecha);

            try
            {
                
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("UPD_Promocion", conexionTemp);

                    cmd.Parameters.AddWithValue("id", promocion.id);
                    cmd.Parameters.AddWithValue("id_producto", promocion.productoId);
                    cmd.Parameters.AddWithValue("descuento", promocion.descuento);
                    cmd.Parameters.AddWithValue("fecha_hasta", fecha);
                    cmd.Parameters.AddWithValue("vigencia", promocion.vigencia);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    rta = true;
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                rta = false;
            }

            return rta;
        }

        public bool delete(int id)
        {
            bool rta;
            var conexion = new Conexion();

            try
            {
                
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("DEL_Promocion", conexionTemp);

                    cmd.Parameters.AddWithValue("id", id);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();

                    rta = true;
                }

            }
            catch (Exception e)
            {
                System.Diagnostics.Debug.WriteLine(e);
                rta = false;
            }

            return rta;
        }
    }
}
