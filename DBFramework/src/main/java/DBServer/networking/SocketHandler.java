package DBServer.networking;

import DBServer.Services.IPoolService;
import org.eclipse.jetty.util.IO;

import java.io.*;
import java.net.Socket;

public class SocketHandler implements Runnable
{
    IPoolService poolService;
    private Socket socket;
    private ObjectOutputStream outToClient;
    private ObjectInputStream inFromClient;

    public SocketHandler(Socket socket) {
        this.socket = socket;

        try {
            inFromClient = new ObjectInputStream(socket.getInputStream());
            outToClient = new ObjectOutputStream(socket.getOutputStream());
        } catch (IOException e) {
            e.printStackTrace();
        }
        poolService.addHandler(this);
    }

    @Override
    public void run()
    {
        while (true)
        {
            //call something from dbservice or whatever idc
            //string response = bigMethodFromDBServiceOrWhatever(rec(inFromClient))
            //if(response != null)
            //{
            //    trans(response);
            //}
        }
    }
    private String rec(InputStream is) throws IOException
    {
        //stolen from stack overflow
        //learn how it works
        byte[] lenBytes = new byte[4];
        is.read(lenBytes, 0, 4);
        int len = (((lenBytes[3] & 0xff) << 24) | ((lenBytes[2] & 0xff) << 16) |
                ((lenBytes[1] & 0xff) << 8) | (lenBytes[0] & 0xff));
        byte[] receivedBytes = new byte[len];
        is.read(receivedBytes, 0, len);
        String received = new String(receivedBytes, 0, len);
        return received;
    }
    private void trans(String msg, OutputStream os) throws IOException
    {
        String toSend = msg;
        byte[] toSendBytes = toSend.getBytes();
        int toSendLen = toSendBytes.length;
        byte[] toSendLenBytes = new byte[4];
        toSendLenBytes[0] = (byte)(toSendLen & 0xff);
        toSendLenBytes[1] = (byte)((toSendLen >> 8) & 0xff);
        toSendLenBytes[2] = (byte)((toSendLen >> 16) & 0xff);
        toSendLenBytes[3] = (byte)((toSendLen >> 24) & 0xff);
        os.write(toSendLenBytes);
        os.write(toSendBytes);
    }
}
