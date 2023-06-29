using Luxifer.Enums;
using System.ComponentModel.DataAnnotations;

namespace Luxifer.Models
{
    public class Grupo
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        //[Required(ErrorMessage = "Introduza uma cor válida")]
        public CoresGruposEnum Cor { get; set; }

        public int? UserId { get; set; }

        public User User { get; set; }
    }
}
