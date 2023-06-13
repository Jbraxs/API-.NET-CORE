using System.ComponentModel.DataAnnotations;

namespace CrudRazor.Models
{
    public class Curso
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Nombre del Curso")]
        public string NombreCurso { get; set; }
        [Display(Name = "Cantidad de Clases")]
        public int Cantidad { get; set; }
        public int Precio { get; set; }
    }
}
