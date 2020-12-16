using System;
using System.Threading.Tasks;
using ClientFramework.Authorization;

namespace ClientFramework.REST
{
    [Obsolete]
    public interface ILoginService
    {
        Task<User> ValidateLogin(string username, string password);
    }
}