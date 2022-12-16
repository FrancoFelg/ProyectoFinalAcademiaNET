namespace MVC004.Models
{
    public class Clientes
    {
        public int Id { get; set; }
        public int  doc_tipo_id { get; set; }
        public int doc_nro  { get; set; }   
        public string? fecha_alta { get; set; }
        public string? nombre { get; set; }
        public string? apellido_razsoc { get; set; }
        public string? domicilio { get; set; }
        public string? localidad { get; set; }  
        public int id_usuario { get; set; }


        
    }
}
