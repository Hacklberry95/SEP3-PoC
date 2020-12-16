using System;
using System.Net;
using System.Net.Sockets;
using System.Text.Json;
using ClientFramework.Data;

namespace ClientFramework.ClientSocket
{
    [Obsolete]
    public class ClientSocket
    {
        public void Send(Order order)
        {
            string jsonString = "";
            jsonString = JsonSerializer.Serialize(order, order.GetType());
            IPEndPoint serverAddress = new IPEndPoint(IPAddress.Parse("192.168.0.6"), 4343);
            Socket clientSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            clientSocket.Connect(serverAddress);
        
            // Sending
            int toSendLen = System.Text.Encoding.ASCII.GetByteCount(jsonString);
            byte[] toSendBytes = System.Text.Encoding.ASCII.GetBytes(jsonString);
            byte[] toSendLenBytes = System.BitConverter.GetBytes(toSendLen);
            clientSocket.Send(toSendLenBytes);
            clientSocket.Send(toSendBytes);
        }
    }
}