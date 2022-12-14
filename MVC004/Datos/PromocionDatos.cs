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
                SqlCommand cmd = new SqlCommand("GET_Promocion", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        list.Add(new Promocion()
                        {
                            id = Convert.ToInt32(lector["promocion_id"]),
                            //producto = Convert.ToInt32(lector["producto"]),
                            //descuento = float.Parse(Convert.ToString(lector["descuento"])),
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
                SqlCommand cmd = new SqlCommand("GET_PromocionById", conexionTemp);

                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("id", id);

                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        promocion.id = Convert.ToInt32(lector["id"]);
                        promocion.producto = Convert.ToInt32(lector["producto"]);
                        promocion.descuento = float.Parse(Convert.ToString(lector["descuento"]));
                        promocion.fechaDesde = DateOnly.FromDateTime(Convert.ToDateTime(lector["fechaDesde"]));
                        promocion.fechaHasta = DateOnly.FromDateTime(Convert.ToDateTime(lector["fechaHasta"]));
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
                    cmd.Parameters.AddWithValue("producto_id", promocion.producto);
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

            try
            {
                
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("UPD_Promocion", conexionTemp);

                    cmd.Parameters.AddWithValue("id", promocion.id);
                    cmd.Parameters.AddWithValue("producto_id", promocion.producto);
                    cmd.Parameters.AddWithValue("descuento", promocion.descuento);
                    cmd.Parameters.AddWithValue("fechaDesde", promocion.fechaDesde);
                    cmd.Parameters.AddWithValue("fechaHasta", promocion.fechaHasta);

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
