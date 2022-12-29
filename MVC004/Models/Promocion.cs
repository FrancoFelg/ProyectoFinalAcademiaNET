using System.ComponentModel.DataAnnotations.Schema;

namespace MVC004.Models
{
    public class Promocion
    {
        public int? id { get; set; }
        [ForeignKey("producto")]
        public int? productoId { get; set; }

        public virtual Producto? producto { get; set; }
        public float? descuento { get; set; }
        public DateOnly? fechaDesde { get; set; }
        public DateOnly? fechaHasta { get; set; }
        public bool vigencia { get; set; }
    }
}
