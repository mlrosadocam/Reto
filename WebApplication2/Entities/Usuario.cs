
using System.ComponentModel.DataAnnotations;


namespace WebApplication2.Entities
{
    public class Usuario
    {
        public int UsuarioId { get; set; }

        [MaxLength(50)]
        public string Nombres { get; set; }

        [MaxLength(50)]
        public string Apellidos { get; set; }

        [Range(0, 100)]
        public int Edad { get; set; }

        [Range(100000000, 999999999)]
        public int Telefono { get; set; }

    }

}
