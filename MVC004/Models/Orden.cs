using System.ComponentModel.DataAnnotations.Schema;

namespace MVC004.Models
{
    public class Orden
    {
        public int? id { get; set; }

        [ForeignKey("vendedor")]
        public int vendedorId { get; set; }
        public virtual Empleado vendedor { get; set; }
        [ForeignKey("cliente")]
        public int clienteId { get; set; }
        public virtual Cliente cliente { get; set; }
        public DateOnly? fechaAlta { get; set; }
        public DateOnly? fechaEntrega { get; set; }
    }
}
