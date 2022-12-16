namespace MVC004.Models
{
    public class Empleado
    {
        public int? id { get; set; }

        public  DocTipo? docTipo { get; set; }
        public long? docNro { get; set; }
        public DateTime? fechaAlta { get; set; }
        public string? nombre { get; set; }
        public string?  apellidoORazonSocial { get; set; }

        //id usuario
    }
}
