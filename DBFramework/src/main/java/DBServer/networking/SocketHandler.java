package DBServer.networking;

import DBServer.Data.Item;
import DBServer.Data.Location;
import DBServer.Data.Order;
import DBServer.Services.IPoolService;
import SQL.ISQLQueryInterpreter;
import SQL.SQLQueryInterpreter;
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



    public SocketHandler(Socket socket, ISQLQueryInterpreter interpreter, ConnectionPool connectionPool)
    {
        this.socket = socket;
        isqlQueryInterpreter = interpreter;
        try
        {
            inFromClient = new ObjectInputStream(socket.getInputStream());
            outToClient = new ObjectOutputStream(socket.getOutputStream());
        }
        catch (IOException e)
        {
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
                    case "GetItem":
                    {
                        int id = 0;
                        String number = gson.fromJson(message, String.class);
                        id = Integer.parseInt(number);
                        Item item = isqlQueryInterpreter.getItem(id);
                        String json = gson.toJson(item);
                        String transmit = "";
                        if(item.getName() != null)
                        {
                            transmit = "GetItem@" + json;
                        }
                        trans(transmit, outToClient);
                    }
                    case "EditItem":
                    {
                        Item item = gson.fromJson(message, Item.class);
                        isqlQueryInterpreter.updateItem(item);

                    }
                    case "RemoveItem":
                    {
                        int id = 0;
                        String number = gson.fromJson(message, String.class);
                        id = Integer.parseInt(number);
                        isqlQueryInterpreter.removeItem(id);
                    }
                    case "MarkItemAsDamaged":
                    {
                        String string = gson.fromJson(message, String.class);
                        String[] split = string.split("#");
                        int id = Integer.parseInt(split[0]);
                        int count = Integer.parseInt(split[1]);
                        isqlQueryInterpreter.MarkItemAsDamaged(id, count);
                    }
                    case "AddItem":
                    {
                        Item item = gson.fromJson(message, Item.class);
                        isqlQueryInterpreter.addItem(item);

                    }
                    case "ReturnItems":
                    {
                        String string = gson.fromJson(message, String.class);
                        String[] split = string.split("#");
                        int id = Integer.parseInt(split[0]);
                        int count = Integer.parseInt(split[1]);
                        isqlQueryInterpreter.returnItem(id, count);
                    }
                    case "GetOrder":
                    {
                        int id = 0;
                        String number = gson.fromJson(message, String.class);
                        id = Integer.parseInt(number);
                        Order order = isqlQueryInterpreter.getOrderById(id);
                        String json = gson.toJson(order);
                        String transmit = "";
                        if (order.getOrderState() != -1)
                        {
                            transmit = "GetOrder@" + json;
                        }
                        trans(transmit, outToClient);
                    }
                    case "FinalizePick":
                    {
                        int orderID = gson.fromJson(message, Integer.class);
                        isqlQueryInterpreter.finalizePick(orderID);
                    }
                    case "CancelOrder" :
                    {
                        int orderID = gson.fromJson(message, Integer.class);
                        isqlQueryInterpreter.cancelOrder(orderID);
                    }
                    case "CutItem":
                    {
                        //nonexistent socket sending
                    }
                    case "AllocPutaway":
                    {
                        Location loc = gson.fromJson(message, Location.class);
                        Location loc2 = isqlQueryInterpreter.getLocation(loc.getId());
                        if(loc2.getItemID() == 0)
                        {
                            isqlQueryInterpreter.updateLocation(loc);
                        }
                    }
                    case "GetLocation":
                    {
                        String number = gson.fromJson(message, String.class);
                        Location loc = isqlQueryInterpreter.getLocation(number);
                        String json = gson.toJson(loc);
                        String transmit = "";
                        if (!loc.getId().equals(""))
                        {
                            transmit = "GetLocation@" + json;
                        }
                        trans(transmit, outToClient);

                    }
                    case "UpdateLocation":
                    {
                        Location loc = gson.fromJson(message, Location.class);
                        isqlQueryInterpreter.updateLocation(loc);
                    }
                    case "DeleteLocation" :
                    {
                        String number = gson.fromJson(message, String.class);
                        isqlQueryInterpreter.deleteLocation(number);
                    }
                    case "AddLocation":
                    {
                        Location loc = gson.fromJson(message, Location.class);
                        isqlQueryInterpreter.addLocation(loc);
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
