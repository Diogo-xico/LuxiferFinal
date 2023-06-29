using Luxifer.Data;
using Luxifer.Models;

namespace Luxifer.Repository
{
    public class GrupoRepo : IGrupoRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public GrupoRepo(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public Grupo ListarPorId(int id)
        {
            return _applicationDbContext.Grupo.FirstOrDefault(x => x.Id == id);
        }

        public List<Grupo> ListarGrupos(int UserId)
        {
            return _applicationDbContext.Grupo.Where(x => x.UserId == UserId).ToList();
        }

        public Grupo Create(Grupo grupo)
        {
            _applicationDbContext.Grupo.Add(grupo);
            _applicationDbContext.SaveChanges();
            return grupo;
        }

        public Grupo Edit(Grupo grupo)
        {
            Grupo grupoDB = ListarPorId(grupo.Id);

            if (grupoDB == null) throw new SystemException("Houve um erro na edição do Grupo");

            grupoDB.Nome = grupo.Nome;
            grupoDB.Cor = grupo.Cor;
            grupoDB.UserId = grupo.UserId;

            _applicationDbContext.Grupo.Update(grupoDB);
            _applicationDbContext.SaveChanges();

            return grupoDB;
        }

        public bool Delete(int id)
        {
            Grupo grupoDB = ListarPorId(id);

            if (grupoDB == null) throw new SystemException("Houve um erro na eliminação da Luminária");

            _applicationDbContext.Grupo.Remove(grupoDB);
            _applicationDbContext.SaveChanges();

            return true;
        }
    }
}