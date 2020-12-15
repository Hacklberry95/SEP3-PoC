using System.Threading.Tasks;
using ClientFramework.Authorization;

namespace ClientFramework.REST
{
    public interface ILoginService
    {
        Task<User> ValidateLogin(string username, string password);
    }
}