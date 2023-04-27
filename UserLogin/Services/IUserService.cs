using UserLogin.Entities;

namespace UserLogin.Services
{
    public interface IUserService
    {
        User AuthenticateUser(string username, string password);
    }

    public class UserService : IUserService
    {
        private readonly List<User> Users = new List<User>
        {
            new User
            {
                Id=1,
                Name="Deniz",
                Surname="Demirdöven",
                Username = "deniz",
                Password="test"
            }
        };
        public User AuthenticateUser(string username, string password)
        {
            return Users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
