using System.Threading.Tasks;

namespace ServerFramework.Services
{
    public interface ISocketService
    {
        string TransmitAndReturnResponse(string jsonifiedObject);
        void JustTransmit(string jsonifiedObject);
    }
}