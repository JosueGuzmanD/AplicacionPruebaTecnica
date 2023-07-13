using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacionPruebaTecnica.Models
{
    public class Producto
    {

        public int Id { get; set; }
        [Required]

        public string Nombre { get; set; }

        public string Descripcion { get; set; }
        public float PrecioMinimo { get; set; }
        public float PrecioMaximo { get; set; }
        public virtual ICollection<ProductoVariante>? Variantes { get; set; }

      
    }
}
