using ServerFramework.Data;
using System;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text.Json;
using System.Threading.Tasks;
using ServerFramework.Authorization;

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

        public User ValidateUser(string username, string password) 
        {
            string msg = "loginInfo" + "@" + username;
            string responseMsg = TransmitAndReturnResponse(msg);
            string[] responseMsgSplit = responseMsg.Split("@");
            if (responseMsgSplit[0].Equals("userInfo"))
            {
                User tmpUser = JsonSerializer.Deserialize<User>(responseMsgSplit[1]);
                if (tmpUser.Password == password)
                {
                    return tmpUser;
                }
                throw new Exception("Wrong password");
                
            }
            throw new Exception("User not found");
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

        public Location GetLocation(string jsonId)
        {
            string transmit = "GetLocation@" + jsonId;
            string message = TransmitAndReturnResponse(transmit);
            string[] arr = message.Split('@');
            if (arr[0].Equals("GetLocation"))
            {
                try
                {
                    Location location = JsonSerializer.Deserialize<Location>(arr[1]);
                    return location;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.StackTrace);
                    return null;
                }
            }
            else return null;
        }
        
        public void CreateLocation(string jsonId)
        {
            string transmit = "CreateLocation@" + jsonId;
            JustTransmit(transmit);
        }

        public void DeleteLocation(string jsonId)
        {
            string transmit = "DeleteLocation@" + jsonId;
            JustTransmit(transmit);
        }
        
        public void UpdateLocation(string locJson)
        {
            string transmit = "UpdateLocation@" + locJson;
            JustTransmit(transmit);
        }

        public User GetUser(string jsonId)
        {
            string transmit = "GetUser@" + jsonId;
            string message = TransmitAndReturnResponse(transmit);
            string[] arr = message.Split('@');
            if (arr[0].Equals("GetUser"))
            {
                try
                {
                    User user = JsonSerializer.Deserialize<User>(arr[1]);
                    return user;
                }
                catch (Exception e)
                {
                    System.Diagnostics.Debug.WriteLine(e.StackTrace);
                    return null;
                }
            }
            else return null;
        }

        public void AddUser(string userJson)
        {
            string transmit = "AddUser@" + userJson;
            JustTransmit(transmit);
        }
        
        public void RemoveUser(string jsonId)
        {
            string transmit = "RemoveUser@" + jsonId;
            JustTransmit(transmit);
        }
        
        public void UpdateUser(string userJson)
        {
            string transmit = "UpdateUser@" + userJson;
            JustTransmit(transmit);
        }

        public void DeleteOrder(string jsonId)
        {
            string transmit = "DeleteOrder@" + jsonId;
            JustTransmit(transmit);
        }
        
        public void LoadTruckOrder(string jsonId)
        {
            string transmit = "LoadTruckOrder@" + jsonId;
            JustTransmit(transmit);
        }
        
        public void ReturnItems(string jsonId)
        {
            string transmit = "ReturnItems@" + jsonId;
            JustTransmit(transmit);
        }
    }
}