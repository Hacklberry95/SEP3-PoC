using ServerFramework.Data;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using System.Threading.Tasks;

namespace ServerFramework.Services
{
    public class SocketServiceImpl : ISocketService
    {
        /// <summary>
        /// Transmits through sockets and returns a string. 
        /// USAGE: String format: "type@message" (use @ as separator char between type and message). Message is JSON object.
        /// </summary>
        /// <param name="jsonifiedObject">See string format above. The string to be sent to DB server.</param>
        /// <returns>The received string (as a Task, since it is async).</returns>
        public string TransmitAndReturnResponse(string jsonifiedObject)
        {
            string toSend = jsonifiedObject;
            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse("192.168.0.6"), 4343);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverAddress);

            // Sending
            int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
            byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
            byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
            clientSocket.Send(toSendLenBytes);
            clientSocket.Send(toSendBytes);

            // Receiving
            byte[] rcvLenBytes = new byte[4];
            clientSocket.Receive(rcvLenBytes);
            int rcvLen = System.BitConverter.ToInt32(rcvLenBytes, 0);
            byte[] rcvBytes = new byte[rcvLen];
            clientSocket.Receive(rcvBytes);
            String rcv = System.Text.Encoding.ASCII.GetString(rcvBytes);

            Console.WriteLine("Client received: " + rcv);

            clientSocket.Close();
            return rcv;
        }

        /// <summary>
        /// Transmits a message to DB server without returning an item.
        /// USAGE: String format: "type@message" (use @ as separator char between type and message). Message is JSON object.
        /// </summary>
        /// <param name="jsonifiedObject">See string format above. The string to be sent to DB server.</param>
        /// <returns>Returns an empty Task.</returns>
        public void JustTransmit(string jsonifiedObject)
        {
            string toSend = jsonifiedObject;
            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse("192.168.0.6"), 4343);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverAddress);

            // Sending
            int toSendLen = System.Text.Encoding.ASCII.GetByteCount(toSend);
            byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(toSend);
            byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
            clientSocket.Send(toSendLenBytes);
            clientSocket.Send(toSendBytes);
            clientSocket.Close();
        }

        public void AddNewItem(string itemJson)
        {
            string transmit = "NewItem@" + itemJson;
            JustTransmit(transmit);
        }

        public Item GetItem(string jsonId)
        {
            string transmit = "GetItem@" + jsonId;
            string message = TransmitAndReturnResponse(transmit);
            string[] arr = message.Split('@');
            if (arr[0].Equals("GetItem"))
            {
                try
                {
                    Item item = JsonSerializer.Deserialize<Item>(arr[1]);
                    return item;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.StackTrace);
                    return null;
                }
            }
            else return null;
        }

        public void EditItem(string itemJson)
        {
            string transmit = "EditItem@" + itemJson;
            JustTransmit(transmit);
        }

        public void RemoveItem(string jsonId)
        {
            string transmit = "RemoveItem@" + jsonId;
            JustTransmit(transmit);
        }

        public void MarkItemAsDamaged(string jsonId)
        {
            string transmit = "MarkItemAsDamaged@" + jsonId;
            JustTransmit(transmit);
        }
    }
}