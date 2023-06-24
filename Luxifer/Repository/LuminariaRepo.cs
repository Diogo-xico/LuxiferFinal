using Luxifer.Data;
using Luxifer.Models;

namespace Luxifer.Repository
{
    public class LuminariaRepo : ILuminariaRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public LuminariaRepo(ApplicationDbContext applicationDbContext) {
            _applicationDbContext = applicationDbContext;
        }

        public Luminaria ListarPorId(int id)
        {
            return _applicationDbContext.Luminarias.FirstOrDefault(X => X.Id == id);
        }

        public List<Luminaria> ListarLuminarias()
        {
            return _applicationDbContext.Luminarias.ToList();
        }

        public Luminaria Create(Luminaria luminaria)
        {
            _applicationDbContext.Luminarias.Add(luminaria);
            _applicationDbContext.SaveChanges();
            return luminaria;
        }

        public Luminaria Edit(Luminaria luminaria)
        {
            Luminaria luminariaDB = ListarPorId(luminaria.Id);

            if (luminariaDB == null) throw new SystemException("Houve um erro na edição da Luminária");

            luminariaDB.Modelo = luminaria.Modelo;
            luminariaDB.Pais = luminaria.Pais;
            luminariaDB.Cidade = luminaria.Cidade;
            luminariaDB.Latitude = luminaria.Latitude;
            luminariaDB.Longitude = luminaria.Longitude;

            _applicationDbContext.Luminarias.Update(luminariaDB);
            _applicationDbContext.SaveChanges();
            return luminariaDB;

        }

        public bool Delete(int id) {
            Luminaria luminariaDB = ListarPorId(id);

            if (luminariaDB == null) throw new SystemException("Houve um erro na eliminação da Luminária");

            _applicationDbContext.Luminarias.Remove(luminariaDB);
            _applicationDbContext.SaveChanges();
            return true;
        }
    }
}
