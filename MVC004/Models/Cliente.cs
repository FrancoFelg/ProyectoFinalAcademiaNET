namespace MVC004.Models
{
    public class Cliente
    {
        public int Id { get; set; }

        public DocTipo? docTipo { get; set; }
        public long? docNro { get; set; }
        public DateTime? fechaAlta { get; set; }
        public string nombre { get; set; }
        public string apellido { get; set; }
        public string domicilio { get; set; }
        public string localidad { get; set; }

        //id usuario
    }
}
