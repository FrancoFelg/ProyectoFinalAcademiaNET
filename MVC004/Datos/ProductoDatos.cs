using MVC004.Models;
using System.Data;
using System.Data.SqlClient;

namespace MVC004.Datos
{

    public class ProductoDatos
    {
        public List<Producto> getAllProducts()
        {
            var objLista = new List<Producto>();

            var conexion = new Conexion();
            using (var conexionTemp = new SqlConnection(conexion.getCadenaSQL()))
            {
                conexionTemp.Open();
                SqlCommand cmd = new SqlCommand("Product_GetAll", conexionTemp);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var lector = cmd.ExecuteReader())
                {
                    while (lector.Read())
                    {
                        objLista.Add(new Producto()
                        {
                            id = Convert.ToInt32(lector["id"]),
                            nombre = Convert.ToString(lector["nombre"]),
                            promocion_id = Convert.ToInt32(lector["promocion_id"]),
                        });
                    }
                }

            }

            return objLista;
        }


    }
}
