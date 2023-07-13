using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicacionPruebaTecnica.Models
{
    public class ProductoVariante
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
     
        public string Color { get; set; }

        public float Precio { get; set; }

        [Column("Imagen")] 
        public string ImagenFileName { get; set; }

        [NotMapped]
        public IFormFile ImageFile { get; set; }

        [Required]
        public int ProductoId { get; set; }
        public virtual Producto? Producto { get; set; }


    }
}
