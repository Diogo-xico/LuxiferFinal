using Luxifer.Models;

namespace Luxifer.Repository
{
    public interface IUserRepo
    {
        User ProcurarLogin(string email);
        User ListarPorId(int id);
        List<User> ListarUsers();
        User Create(User user);
        User Edit(User user);
        bool Delete(int id);
    }
}
