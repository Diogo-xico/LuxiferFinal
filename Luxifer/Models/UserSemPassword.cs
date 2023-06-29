using Luxifer.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Luxifer.Models
{
    public class UserSemPassword
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Introduza o nome do cliente")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Introduza o nome de utilizador")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Introduza o email do utilizador")]
        [EmailAddress(ErrorMessage = "O email introduzido é inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Introduza o tipo de perfil do utilizador")]
        public PerfilEnum? Perfil { get; set; }

    }
}
