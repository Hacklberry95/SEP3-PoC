package DBServer.networking;

import DBServer.Data.*;
import DBServer.Services.IPoolService;
import SQL.SQLQueryInterpreter;
import com.google.gson.Gson;
import com.google.gson.JsonDeserializer;
import org.eclipse.jetty.util.IO;

import java.io.*;
import java.net.Socket;
import java.sql.SQLException;
import java.util.ArrayList;

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
            try
            {
                String received = rec(inFromClient);
                String[] arr = received.split("@");
                if(arr[0].equals("GetItem"))
                {
                    Gson gson = new Gson();
                    int id = 0;
                    String number = gson.fromJson(arr[1], String.class);
                    id = Integer.parseInt(number);
                    GetItem(id);
                }
                else if(arr[0].equals("EditItem"))
                {
                    Gson gson = new Gson();
                    Item item = gson.fromJson(arr[1], Item.class);
                    EditItem(item);
                }
                else if(arr[0].equals("RemoveItem"))
                {
                    Gson gson = new Gson();
                    int id = 0;
                    String number = gson.fromJson(arr[1], String.class);
                    id = Integer.parseInt(number);
                    RemoveItem(id);
                }
                else if(arr[0].equals("MarkItemAsDamaged"))
                {
                    Gson gson = new Gson();
                    Item item = gson.fromJson(arr[1], Item.class);
                    MarkItemAsDamaged(item);
                }
                else if(arr[0].equals("AddItem"))
                {
                    Gson gson = new Gson();
                    Item item = gson.fromJson(arr[1], Item.class);
                    AddItem(item);
                }
                else if(arr[0].equals("ReturnItems"))
                {
                    Gson gson = new Gson();
                    //figure out list deserialize
                }
                else if(arr[0].equals("GetOrder"))
                {
                    Gson gson = new Gson();
                    int id = 0;
                    String number = gson.fromJson(arr[1], String.class);
                    id = Integer.parseInt(number);
                    GetOrder(id);
                }
                else if(arr[0].equals("FinalizePick"))
                {
                    Gson gson = new Gson();
                    int orderID = gson.fromJson(arr[1], Integer.class);
                    FinalizePick(orderID);
                }
                else if(arr[0].equals("CancelOrder"))
                {
                    Gson gson = new Gson();
                    int orderID = gson.fromJson(arr[1], Integer.class);
                    CancelOrder(orderID);
                }
                else if(arr[0].equals("CutItem"))
                {
                    //write json transform
                    Gson gson = new Gson();
                    //int orderID = gson.fromJson(arr[1], Integer.class);
                    CutItem(0, 0, 0);
                }
                else if(arr[0].equals("AllocPutaway"))
                {
                    //write json transform
                    Gson gson = new Gson();
                    AllocPutaway("", 0);
                }
                else if(arr[0].equals("GetLocation"))
                {
                    Gson gson = new Gson();
                    int id = 0;
                    String number = gson.fromJson(arr[1], String.class);
                    id = Integer.parseInt(number);
                    GetLocation(id);
                }
                else if(arr[0].equals("UpdateLocation"))
                {
                    Gson gson = new Gson();
                    Location loc = gson.fromJson(arr[1], Location.class);
                    UpdateLocation(loc);
                }
                else if(arr[0].equals("DeleteLocation"))
                {
                    Gson gson = new Gson();
                    int id = 0;
                    String number = gson.fromJson(arr[1], String.class);
                    id = Integer.parseInt(number);
                    DeleteLocation(id);
                }
                else if(arr[0].equals("AddLocation"))
                {
                    Gson gson = new Gson();
                    Location loc = gson.fromJson(arr[1], Location.class);
                    AddLocation(loc);
                }

            }
            catch (IOException | SQLException e)
            {
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

    public void GetItem(int id) throws IOException, SQLException
    {
        SQLQueryInterpreter interpreter = new SQLQueryInterpreter();
        Item item = interpreter.getItem(id);
        Gson gson = new Gson();
        String json = gson.toJson(item);
        String transmit = "";
        if(item.getName() != null)
        {
            transmit = "GetItem@" + json;
        }
        trans(transmit, outToClient);
    }

    public void EditItem(Item item) throws SQLException
    {
        SQLQueryInterpreter interpreter = new SQLQueryInterpreter();
        interpreter.updateItem(item);
    }

    public void RemoveItem(int id) throws IOException, SQLException
    {
        SQLQueryInterpreter interpreter = new SQLQueryInterpreter();
        interpreter.removeItem(id);
    }

    public void AddItem(Item item) throws SQLException
    {
        SQLQueryInterpreter interpreter = new SQLQueryInterpreter();
        interpreter.addItem(item);
    }

    public void MarkItemAsDamaged(Item item) throws IOException, SQLException
    {
        SQLQueryInterpreter interpreter = new SQLQueryInterpreter();
        //Removes from the stock table and moves the item to the damaged table
    }

    public void GetOrder(int id) throws IOException, SQLException
    {
        SQLQueryInterpreter interpreter = new SQLQueryInterpreter();
        Order order = interpreter.getOrderById(id);
        Gson gson = new Gson();
        String json = gson.toJson(order);
        String transmit = "";
        if (order.getOrderState() != -1)
        {
            transmit = "GetOrder@" + json;
        }
        trans(transmit, outToClient);
    }

    public void FinalizePick(int orderID) throws SQLException
    {
        SQLQueryInterpreter interpreter = new SQLQueryInterpreter();
        interpreter.finalizePick(orderID);
    }

    public void CancelOrder(int id) throws SQLException
    {
        SQLQueryInterpreter interpreter = new SQLQueryInterpreter();
        interpreter.cancelOrder(id);
    }

    public void CutItem(int id, int itemID, int itemCount) throws SQLException
    {
        SQLQueryInterpreter interpreter = new SQLQueryInterpreter();
        interpreter.cutFromOrder(id, itemID, itemCount);
    }

    public void AllocPutaway(String locationID, int itemID) throws SQLException
    {
        SQLQueryInterpreter interpreter = new SQLQueryInterpreter();
        interpreter.allocPutaway(locationID, itemID);
    }

    private void UpdateLocation(Location loc) throws SQLException
    {
        SQLQueryInterpreter interpreter = new SQLQueryInterpreter();
        interpreter.updateLocation(loc);
    }

    private void DeleteLocation(int id) throws SQLException
    {
        SQLQueryInterpreter interpreter = new SQLQueryInterpreter();
        interpreter.deleteLocation(id);
    }

    private void AddLocation(Location loc) throws SQLException
    {
        SQLQueryInterpreter interpreter = new SQLQueryInterpreter();
        interpreter.addLocation(loc);
    }

    private void GetLocation(int id) throws SQLException, IOException
    {
        SQLQueryInterpreter interpreter = new SQLQueryInterpreter();
        Location loc = interpreter.getLocation(id);
        Gson gson = new Gson();
        String json = gson.toJson(loc);
        String transmit = "";
        if (!loc.getId().equals(""))
        {
            transmit = "GetLocation@" + json;
        }
        trans(transmit, outToClient);
    }
}
