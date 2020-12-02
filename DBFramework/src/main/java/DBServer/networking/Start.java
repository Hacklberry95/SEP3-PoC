package DBServer.networking;
import java.io.IOException;
import java.net.ServerSocket;
import java.net.Socket;
public class Start
{
    private static final int SERVER_PORT = 9090;

    public void start()
    {
        try
        {
            ServerSocket serverSocket = new ServerSocket(SERVER_PORT);
            while(true)
            {
                System.out.println("[SERVER] Waiting for client connection");
                Socket socket = serverSocket.accept();
                SocketHandler socketHandler = new SocketHandler(socket);
                new Thread(socketHandler).start();
                System.out.println("[SERVER] Connected to client");
            }
        }
        catch (IOException e)
        {
            e.printStackTrace();
        }
    }
}
