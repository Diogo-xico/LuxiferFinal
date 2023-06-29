using Luxifer.Enums;
using System;
using System.ComponentModel.DataAnnotations;

namespace Luxifer.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Introduza o nome do cliente")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Introduza o email do utilizador")]
        [EmailAddress(ErrorMessage = "O email introduzido é inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Introduza o tipo de perfil do utilizador")]
        public PerfilEnum? Perfil { get; set; }

        [Required(ErrorMessage = "Introduza o tipo de perfil do utilizador")]
        public string Login { get; set; }

        public string Password { get; set; }

        public int Telefone { get; set; }

        public DateTime DataCriacao { get; set; }

        public DateTime? DataEdicao { get; set; }

        public virtual List<Luminaria> Luminarias { get; set; }

        public bool PasswordValida(string password)
        {
            return Password == password;
        }
    }
}
