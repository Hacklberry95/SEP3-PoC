using System.Net.Http;
using System.Threading.Tasks;
using ClientFramework.Authorization;

namespace ClientFramework.REST
{
    public interface ICustomHttp
    {
        Task<User> ValidateLogin(string username, string password);
        Task<HttpResponseMessage> PostConfirmation(int orderID);
        Task<HttpResponseMessage> PostAddMoreItem(int id, int count);  
    }
}