using System.Threading.Tasks;
using ServerFramework.Authorization;

namespace ServerFramework.Services
{
    public interface ISocketService
    {
        string TransmitAndReturnResponse(string jsonifiedObject);
        void JustTransmit(string jsonifiedObject);

        User ValidateUser(string username, string password);

    }
}