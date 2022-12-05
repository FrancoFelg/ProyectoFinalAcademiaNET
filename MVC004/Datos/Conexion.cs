namespace MVC004.Datos
{
    public class Conexion
    {
        private string cadenaSQL = string.Empty;
        public Conexion()
        {
            //El builder crea todo lo necesario para conectarse a la base de datos
            var builder =
                new ConfigurationBuilder().SetBasePath(
                Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json").Build();

            //Almacena la cadena del builder
            cadenaSQL = builder.GetSection("ConnectionStrings:CadenaSQL").Value;

        }

        public string getCadenaSQL()
        {
            return cadenaSQL;
        }
    }
}
