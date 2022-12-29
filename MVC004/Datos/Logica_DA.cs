using System.Security.Cryptography.X509Certificates;
using MVC004.Models;


namespace MVC004.Datos
{
    public class Logica_DA
    {

        public List<User> ListaUsuario()
        {

            return new List<User>()
            {
                new User() { nombreUser = "Franco", emailUser = "franco@gmail.com", contraseniaUser = "1234", Rol = new string[] { "Admin", "User" } },
                new User() { nombreUser = "Lucas", emailUser = "lucas@gmail.com", contraseniaUser = "1234", Rol = new string[] { "Admin", "User" } },
                new User() { nombreUser = "Agustin", emailUser = "cliente1@gmail.com", contraseniaUser = "1234", Rol = new string[] { "Cliente", "User" } },
                new User() { nombreUser = "Carolina", emailUser = "cliente2@gmail.com", contraseniaUser = "1234", Rol = new string[] { "Cliente", "User" } },
                new User() { nombreUser = "Hernán", emailUser = "vendedor1@gmail.com", contraseniaUser = "1234", Rol = new string[] { "Vendedor", "User" } },
                new User() { nombreUser = "Carla", emailUser = "vendedor2@gmail.com", contraseniaUser = "1234", Rol = new string[] { "Vendedor", "User" } }
            };

        }

        public User ValidarUser(string correo, string pass)
        {
            return ListaUsuario().Where(item => item.emailUser == correo && item.contraseniaUser == pass).FirstOrDefault();
        }
    }
}
    
