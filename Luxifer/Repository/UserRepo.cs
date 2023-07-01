using Luxifer.Data;
using Luxifer.Models;

namespace Luxifer.Repository
{
    public class UserRepo : IUserRepo
    {
        private readonly ApplicationDbContext _applicationDbContext;
        public UserRepo(ApplicationDbContext applicationDbContext) {
            _applicationDbContext = applicationDbContext;
        }

        public User ProcurarLogin(string email)
        {
            return _applicationDbContext.Users.FirstOrDefault(X => X.Email == email);
        }
        public User ListarPorId(int id)
        {
            return _applicationDbContext.Users.FirstOrDefault(X => X.Id == id);
        }

        public List<User> ListarUsers()
        {
            return _applicationDbContext.Users.ToList();
        }


        public User Create(User user)
        {
            user.DataCriacao = DateTime.Now;
            _applicationDbContext.Users.Add(user);
            _applicationDbContext.SaveChanges();
            return user;
        }

        public User Edit(User user)
        {
            User userDB = ListarPorId(user.Id);

            if (userDB == null) throw new SystemException("Houve um erro na edição do Cliente!");

            userDB.Nome = user.Nome;
            userDB.Email = user.Email;
            userDB.Login = user.Login;
            userDB.Perfil = user.Perfil;
            userDB.DataEdicao = DateTime.Now;

            _applicationDbContext.Users.Update(userDB);
            _applicationDbContext.SaveChanges();
            return userDB;

        }

        public bool Delete(int id) {
            User userDB = ListarPorId(id);

            if (userDB == null) throw new SystemException("Houve um erro na eliminação do Cliente");

            _applicationDbContext.Users.Remove(userDB);
            _applicationDbContext.SaveChanges();
            return true;
        }

        public List<User> ListarLuminarias()
        {
            throw new NotImplementedException();
        }

    }
}
