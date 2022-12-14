using MVC004.Models;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace MVC004.Datos
{
    public class OrdenDatos
    {
        public List<Orden> getAllOrdenes()
        {
            var objLista = new List<Orden>();

            try
            {
                var conexion = new Conexion();
                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("GET_Ordenes", conexionTemp);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {
                            objLista.Add(new Orden()
                            {
                                id = Convert.ToInt32(lector["id"]),
                                //TODO - No se pueden ver estos datos porque son pertenecientes a tablas intermedias
                                /*
                                vendedor = Convert.ToInt32(lector["vendedor"]),
                                cliente = Convert.ToInt32(lector["cliente"]),
                                fechaAlta = DateOnly.FromDateTime(Convert.ToDateTime(lector["fechaAlta"])),
                                fechaEntrega = DateOnly.FromDateTime(Convert.ToDateTime(lector["fechaEntrega"])),
                                */
                            });
                        }
                    }

                }
                foreach(var item in objLista)
                {
                    System.Diagnostics.Debug.WriteLine("" + item.vendedor, item.cliente, item.fechaAlta, item.fechaEntrega);
                }
            }
            catch(Exception ex)
            {
                string error = ex.Message;
                
                System.Diagnostics.Debug.WriteLine(ex);
            }
            

            return objLista;
        }

        public Orden getById(int id)
        {
            var objOrden = new Orden();
            var conexion = new Conexion();

            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("GET_OrdenById", conexionTemp);

                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        objOrden.id = Convert.ToInt32(lector["id"]);
                        //Toda esta parte no funciona hasta que no se use la tabla intermedia
                        objOrden.vendedor = Convert.ToInt32(lector["vendedor"]);
                        objOrden.cliente = Convert.ToInt32(lector["cliente"]);
                        objOrden.fechaAlta = DateOnly.FromDateTime(Convert.ToDateTime(lector["fechaAlta"]));
                        objOrden.fechaEntrega = DateOnly.FromDateTime(Convert.ToDateTime(lector["fechaEntrega"]));
                        
                    }
                }
            }

            return objOrden;
        }

        public bool save(Orden orden)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();
                
                using(var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("INS_Orden", conexionTemp);

                    cmd.Parameters.AddWithValue("vendedor", orden.vendedor);
                    cmd.Parameters.AddWithValue("cliente", orden.cliente);                                        

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta =  true;

            }catch(Exception e)
            {
                string error = e.Message;
                System.Diagnostics.Debug.WriteLine(e);
                respuesta = false;
            }

            return respuesta;
        }

        public bool edit (Orden orden)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();

                using(var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("UPD_Orden", conexionTemp);


                    cmd.Parameters.AddWithValue("id", orden.id);
                    cmd.Parameters.AddWithValue("vendedor", orden.vendedor);
                    cmd.Parameters.AddWithValue("cliente", orden.cliente);
                    cmd.Parameters.AddWithValue("fechaAlta", orden.fechaAlta);
                    cmd.Parameters.AddWithValue("fechaEntrega", orden.fechaEntrega);

                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }
                respuesta = true;

            }catch(Exception e )
            {
                string error = e.Message;
                respuesta = false;
                System.Diagnostics.Debug.WriteLine(e);
            }

            return respuesta;
        }


        public bool delete(int id)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("DEL_Orden", conexionTemp);
                    cmd.Parameters.AddWithValue("id", id);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.ExecuteNonQuery();
                }

                respuesta = true;
            }
            catch (Exception e)
            {
                String error = e.Message;
                respuesta = false;
                System.Diagnostics.Debug.WriteLine(e);
            }


            return respuesta;
        }

    }

}
