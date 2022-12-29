using System.ComponentModel.DataAnnotations.Schema;

namespace MVC004.Models
{
    public class ProductoRelProveedor
    {
        public int? id { get; set; }
        [ForeignKey("producto")]
        public int? productoId { get; set; }
        public Producto? producto { get; set; }

        [ForeignKey("proveedor")]
        public int? proveedorId { get; set; }
        public Proveedores? proveedor  { get; set; }

        public int? stock { get; set; }
        public double? precioCompra { get; set; }
        public double? precioVenta { get; set; }

    }
}
