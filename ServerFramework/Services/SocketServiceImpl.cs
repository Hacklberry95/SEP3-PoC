using System.Threading.Tasks;

namespace ServerFramework.Services
{
    public class SocketServiceImpl : ISocketService
    {
        public async Task<string> TransmitAndReturnResponse(string jsonifiedObject)
        {
            return null;
            //throw new System.NotImplementedException();
        }

        public Task JustTransmit(string jsonifiedObject)
        {
            throw new System.NotImplementedException();
        }
    }
}