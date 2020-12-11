package SQL;

import DBServer.Data.Item;
import DBServer.Data.Order;
import DBServer.Data.User;
import DBServer.networking.SocketHandler;

import java.sql.*;
import java.util.ArrayList;
import java.util.Arrays;

public class SQLQueryInterpreter
{
    private Connection c;
    private ArrayList<Integer> intArr;

    public SQLQueryInterpreter()
    {
        getConnection();
    }

    public void getConnection()
    {
        try
        {
            Class.forName("org.postgresql.Driver");
            c = DriverManager
                    .getConnection("jdbc:postgresql://localhost:5432/SEP3-PoC", "postgres",
                            "Aoe3tadtwc-2000");
        }
        catch (SQLException | ClassNotFoundException e)
        {
            e.printStackTrace();
        }
    }

    public void newOrderConfirmQuery(int i) throws SQLException
    {
        String query = "UPDATE orders SET orderstate = 4 WHERE orderid = " + i + ";";
        Statement st = c.createStatement();
        st.executeUpdate(query);
        st.close();
        c.close();
    }

    public void addItem(Item item) throws SQLException
    {
        //finish INSERT INTO statement
        String query = "INSERT INTO item () VALUES ()" + ";";
        Statement st = c.createStatement();
        st.executeUpdate(query);
        st.close();
        c.close();
    }

    public void removeItem(int id) throws SQLException
    {
        String query = "DELETE FROM item WHERE (id = " + id + ");";
        Statement st = c.createStatement();
        st.executeUpdate(query);
        st.close();
        c.close();
    }

    public void updateItem(Item item) throws SQLException
    {
        String query = "UPDATE item SET " + "WHERE (id = " + item.getId() + ");";
        Statement st = c.createStatement();
        st.executeUpdate(query);
        st.close();
        c.close();
    }

    public Item getItem(int id) throws SQLException
    {
        String query = "SELECT * FROM item WHERE (id = " + id + ");";
        Statement st = c.createStatement();
        ResultSet rs = st.executeQuery(query);
        Item item = new Item(rs.getString("name"), rs.getFloat("weight"), rs.getFloat("width"),
        rs.getFloat("length"), rs.getFloat("height"), rs.getString("description"));
        return item;
    }

    public Order getOrderById(int id) throws SQLException
    {
        String query = "SELECT * FROM order WHERE (id = " + id + ");";
        Statement st = c.createStatement();
        ResultSet rs = st.executeQuery(query);
        Order order = new Order(rs.getInt("orderid"), rs.getInt("orderstate"),
                new ArrayList<Integer>(Arrays.asList((Integer[]) rs.getArray("items").getArray())),
                new ArrayList<Integer>(Arrays.asList((Integer[]) rs.getArray("\"itemCounts\"").getArray())));
        return order;
    }

    public User getUserById(int id, String password) throws SQLException
    {
        String query = "SELECT * FROM user WHERE (id = " + id + ")";
        Statement st = c.createStatement();
        ResultSet rs = st.executeQuery(query);
        User user = new User(rs.getString("username"), rs.getString("password"));
        return user;
    }

}
