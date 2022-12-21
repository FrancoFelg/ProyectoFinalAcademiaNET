using System.ComponentModel.DataAnnotations.Schema;

namespace MVC004.Models
{
    public class ProductoRelOrden
    {
        public int? Id { get; set; }
        [ForeignKey("producto")]
        public int productoId { get; set; }
        public virtual ProductoRelProveedor? productoRelProveedor { get; set; }
        [ForeignKey("orden")]
        public int? ordenId { get; set; }
        public virtual Orden? orden { get; set; }

        public int? cantidad { get; set; }

    }
}
