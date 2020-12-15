package DBServer.networking;

import DBServer.Services.IPoolService;
import SQL.ISQLQueryInterpreter;
import com.google.gson.Gson;
import org.eclipse.jetty.util.IO;

import java.io.*;
import java.net.Socket;
import java.sql.SQLException;

public class SocketHandler implements Runnable
{
    private Socket socket;
    private ObjectOutputStream outToClient;
    private ObjectInputStream inFromClient;
    private ISQLQueryInterpreter isqlQueryInterpreter;



    public SocketHandler(Socket socket, ISQLQueryInterpreter sqlInterpreter, ConnectionPool connectionPool) {
        this.socket = socket;
        isqlQueryInterpreter = sqlInterpreter;
        try {
            inFromClient = new ObjectInputStream(socket.getInputStream());
            outToClient = new ObjectOutputStream(socket.getOutputStream());
        } catch (IOException e) {
            e.printStackTrace();
        }
        connectionPool.addHandler(this);
    }

    @Override
    public void run()
    {
        Gson gson = new Gson();

        while (true)
        {
            try
            {
                String type = determineType(rec(inFromClient))[0];
                String message = determineType(rec(inFromClient))[1];
                switch (type)
                {
                    case "loginInfo" :
                    {
                        if(isqlQueryInterpreter.getUserBoolean(message))
                        {
                            String returnData = "userInfo" + "@" + gson.toJson(isqlQueryInterpreter.getUserById(message));
                            trans(returnData, outToClient);
                        }
                    }
                }
            } catch (IOException | SQLException e) {
                e.printStackTrace();
            }
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
    private String[] determineType(String msg)
    {
        return msg.split("@");
    }
}
