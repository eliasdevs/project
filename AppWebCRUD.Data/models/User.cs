using System.ComponentModel.DataAnnotations;

namespace AppWebCRUD.Data.models
{
    public class User
    {
        public User()
        {
            FechaRegistro = DateTimeOffset.Now;
            GuidId = Guid.NewGuid();
        }
        [Required]
        [Key]
        public Guid GuidId { get; set; }
        [Required(ErrorMessage = "Este campo es obligatorio.")]
        [RegularExpression("^[a-zA-ZáéíóúñÑÁÉÍÓÚ ]+$", ErrorMessage = "El nombre debe contener sólo letras")]
        [MinLength(3, ErrorMessage = "El nombre debe tener al menos 3 caracteres")]
        [StringLength(200)]
        public string Name { get; set; } = string.Empty;
        [RegularExpression("^[a-zA-ZáéíóúñÑÁÉÍÓÚ ]+$", ErrorMessage = "El apellido debe contener sólo letras")]
        [MinLength(3, ErrorMessage = "El apellido debe tener al menos 3 caracteres")]
        [Required(ErrorMessage = "Este campo es obligatorio.")]        
        [StringLength(200)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public bool Activo { get; set; } = false;        
        [Required]
        public DateTimeOffset FechaRegistro { get; set; }

    }
}