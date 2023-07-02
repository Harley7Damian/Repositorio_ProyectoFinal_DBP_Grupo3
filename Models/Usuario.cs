using System.ComponentModel.DataAnnotations;

namespace ProyectoDesarrollo.B.P.Models
{
    public class Usuario
    {
        [Required(ErrorMessage = "El campo DNI es obligatorio")]
        public string Id { get; set; }
        [Required(ErrorMessage = "El campo del NOMBRES es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo de los APELLIDOS es obligatorio")]
        public string Apellido { get; set; }
        [Required(ErrorMessage = "El campo de EDAD es obligatorio")]
        public string Edad { get; set; }
    }
}
