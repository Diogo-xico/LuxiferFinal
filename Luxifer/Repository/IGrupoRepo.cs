using Luxifer.Models;

namespace Luxifer.Repository
{
    public interface IGrupoRepo
    {
        Grupo ListarPorId(int id);
        List<Grupo> ListarGrupos(int UserId);
        Grupo Create(Grupo grupo);
        Grupo Edit(Grupo grupo);
        bool Delete(int id);
    }
}