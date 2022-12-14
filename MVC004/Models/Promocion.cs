namespace MVC004.Models
{
    public class Promocion
    {
        public int? id { get; set; }
        public int? producto { get; set; }
        public float? descuento { get; set; }
        public DateOnly? fechaDesde { get; set; }
        public DateOnly? fechaHasta { get; set; }
        public bool vigencia { get; set; }
    }
}
