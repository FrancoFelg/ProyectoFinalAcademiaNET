namespace MVC004.Models
{
    public class Orden
    {
        public int? id { get; set; }
        public int? vendedor { get; set; }
        public int? cliente { get; set; }
        public DateOnly? fechaAlta { get; set; }
        public DateOnly? fechaEntrega { get; set; }
    }
}
