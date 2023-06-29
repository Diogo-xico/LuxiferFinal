using System.Reflection.Metadata.Ecma335;

namespace Luxifer.Models
{
    public class Luminaria
    {
        public int Id { get; set; }
        public string Modelo { get; set; }

        public string Pais { get; set; }
        public string Cidade { get; set; }

        public string Latitude { get; set; }
        public string Longitude { get; set; }

        public int? UserId { get; set; }
        public User User{ get; set; }

        public int? GrupoId { get; set; }
        public Grupo Grupo { get; set; }
    }
}
