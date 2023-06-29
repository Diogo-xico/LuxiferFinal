using Luxifer.Models;

namespace Luxifer.Repository
{
    public interface ILuminariaRepo
    {
        Luminaria ListarPorId(int id);
        List<Luminaria> ListarLuminariasPorGrupoId(int GrupoId);
        List<Luminaria> ListarLuminarias(int UserId);
        Luminaria Create(Luminaria luminaria);
        Luminaria Edit(Luminaria luminaria);
        bool Delete(int id);
    }
}
