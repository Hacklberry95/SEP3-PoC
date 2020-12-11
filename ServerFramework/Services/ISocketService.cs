using System.Threading.Tasks;

namespace ServerFramework.Services
{
    public interface ISocketService
    {
        Task<string> TransmitAndReturnResponse(string jsonifiedObject);
        Task JustTransmit(string jsonifiedObject);

        Task ValidateUser(string username, string password);
    }
}