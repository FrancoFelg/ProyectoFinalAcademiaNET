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
                    SqlCommand cmd = new SqlCommand("GET_OrdenANDEmpleadoANDCLientes", conexionTemp);
                    cmd.CommandType = CommandType.StoredProcedure;

                    using (var lector = cmd.ExecuteReader())
                    {
                        while (lector.Read())
                        {


                            objLista.Add(new Orden()
                            {
                                id = Convert.ToInt32(lector["id"]),
                                vendedor = new Empleado()
                                {
                                    id = Convert.ToInt32(lector["id"]),
                                    docTipo = new DocTipo()
                                    {
                                        id = Convert.ToInt32(lector["id"]),
                                        doc_tipo = Convert.ToString(lector["doc_tipo"]),
                                    },
                                    docNro = Convert.ToInt32(lector["doc_nro"]),
                                    fechaAlta = Convert.ToDateTime(lector["fecha_alta"]),
                                    nombre = Convert.ToString(lector["nombre"]),
                                    apellidoORazonSocial = Convert.ToString(lector["apellido_razsoc"]),
                                },
                                cliente = new Cliente()
                                {
                                    Id = Convert.ToInt32(lector["id"]),
                                    docTipo = new DocTipo()
                                    {
                                        id = Convert.ToInt32(lector["id"]),
                                        doc_tipo = Convert.ToString(lector["doc_tipo"]),
                                    },
                                    docNro = Convert.ToInt32(lector["doc_nro"]),
                                    fechaAlta = Convert.ToDateTime(lector["fecha_alta"]),
                                    nombre = Convert.ToString(lector["nombre"]),
                                    apellido = Convert.ToString(lector["apellido_razsoc"]),
                                    domicilio = Convert.ToString(lector["domicilio"]),
                                    localidad = Convert.ToString(lector["localidad"]),

                                },
                                fechaAlta = DateOnly.FromDateTime(Convert.ToDateTime(lector["fecha_alta"])),
                                fechaEntrega = DateOnly.FromDateTime(Convert.ToDateTime(lector["fecha_entrega"])),
                            });
                        }
                    }

                }
                foreach (var item in objLista)
                {
                    System.Diagnostics.Debug.WriteLine("" + item.vendedor, item.cliente, item.fechaAlta, item.fechaEntrega);
                }
            }
            catch (Exception ex)
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
                SqlCommand cmd = new SqlCommand("GET_OrdenANDEmpleadoANDClienteTOUPD", conexionTemp);

                cmd.Parameters.AddWithValue("id", id);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        objOrden = new Orden()
                        {
                            id = Convert.ToInt32(lector["id"]),
                            vendedor = new Empleado()
                            {
                                id = Convert.ToInt32(lector["id"]),                                
                                nombre = Convert.ToString(lector["nombre_empleado"]),
                                apellidoORazonSocial = Convert.ToString(lector["apellido_razsoc_empleado"]),
                            },
                            cliente = new Cliente()
                            {
                                Id = Convert.ToInt32(lector["id"]),                                
                                nombre = Convert.ToString(lector["nombre_cliente"]),
                                apellido = Convert.ToString(lector["apellido_razsoc_cliente"]),                                
                            },
                            fechaAlta = DateOnly.FromDateTime(Convert.ToDateTime(lector["fecha_alta"])),
                            fechaEntrega = DateOnly.FromDateTime(Convert.ToDateTime(lector["fecha_entrega"]))
                        };
                    }


                    //TODO - No se pueden ver estos datos porque son pertenecientes a tablas intermedias


                }
                return objOrden;
            }
        }




        public bool save(Orden orden)
        {
            bool respuesta;

            try
            {
                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("INS_Orden", conexionTemp);

                    cmd.Parameters.AddWithValue("vendedor", orden.vendedorId);
                    cmd.Parameters.AddWithValue("cliente", orden.clienteId);

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

        public bool edit(Orden orden)
        {
            bool respuesta;
            try
            {
                var conexion = new Conexion();

                using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
                {
                    conexionTemp.Open();
                    SqlCommand cmd = new SqlCommand("UPD_Orden", conexionTemp);


                    cmd.Parameters.AddWithValue("id", orden.id);
                    cmd.Parameters.AddWithValue("vendedor", orden.vendedorId);
                    cmd.Parameters.AddWithValue("cliente", orden.clienteId);
                    //cmd.Parameters.AddWithValue("fechaAlta", orden.fechaAlta);
                    //cmd.Parameters.AddWithValue("fechaEntrega", orden.fechaEntrega);

                    cmd.CommandType = CommandType.StoredProcedure;
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


