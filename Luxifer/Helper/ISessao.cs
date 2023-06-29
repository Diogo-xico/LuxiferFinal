using Luxifer.Models;

namespace Luxifer.Helper
{
    public interface ISessao
    {
        void CriarSessaoUser(User user);
        void SairSessaoUser();
        User ProcurarSessaoUser();
    }
}
