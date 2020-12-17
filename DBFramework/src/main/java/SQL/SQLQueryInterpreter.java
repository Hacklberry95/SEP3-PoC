package SQL;

import DBServer.Data.Item;
import DBServer.Data.Location;
import DBServer.Data.Order;
import DBServer.Data.User;

import java.sql.*;
import java.util.ArrayList;
import java.util.Arrays;

public class SQLQueryInterpreter implements ISQLQueryInterpreter
{
    private Connection c;
    private ArrayList<Integer> intArr;


    public void getConnection() throws SQLException {
        try
        {
            c = DriverManager.getConnection("jdbc:postgresql://localhost:5432/postgres?currentSchema=sep3", "postgres",
                            "0806");
        }
        catch (SQLException e)
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
        String query = "INSERT INTO item (name, weight, width, height, length, description) VALUES " +
                "("+item.getName()+ "," +item.getWeight()+ "," +item.getWidth()+ "," +item.getHeight()+ "," +item.getLength()+ "," +item.getDescription()+");";
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
        //write rs.getObject statements in Item creation
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

    public User getUserById(String username) throws SQLException
    {
        String query = "SELECT * FROM user WHERE (username = " + username + ")";
        Statement st = c.createStatement();
        ResultSet rs = st.executeQuery(query);
        User user = new User(rs.getString("username"), rs.getString("password"));
        return user;
    }

    public boolean getUserBoolean(String username) throws SQLException
    {
        String query = "SELECT * FROM user WHERE (username = " + username + ")";
        Statement st = c.createStatement();
        ResultSet rs = st.executeQuery(query);
        User user = new User(rs.getString("username"), rs.getString("password"));
        if(user.getUsername().equals(""))
        return false;
        else return true;
    }
    public void finalizePick(int id) throws SQLException
    {
        String query = "UPDATE orders SET orderstate = 3 WHERE orderid = " + id + ";";
        Statement st = c.createStatement();
        st.executeUpdate(query);
        st.close();
        c.close();
    }

    public void cancelOrder(int id) throws SQLException
    {
        String query = "DELETE FROM orders WHERE (orderid = " + id + ");";
        Statement st = c.createStatement();
        st.execute(query);
        st.close();
        c.close();
    }

    //nonexistent sockets
    /*public void cutFromOrder(int id, int itemID, int itemCount) throws SQLException
    {
        //write query
        String query = "DELETE FROM orders WHERE (items = " + itemID +");";
        Statement st = c.createStatement();
        st.execute(query);
        st.close();
        c.close();
    }*/

    /*public void allocPutaway(String locationID, int itemID) throws SQLException //deprecated
    {
        String query = "UPDATE locations SET item = "+ itemID  +" WHERE locations = "+ locationID +"";
        Statement st = c.createStatement();
        st.execute(query);
        st.close();
        c.close();
    }*/

    public void updateLocation(Location loc) throws SQLException
    {
        String query = "UPDATE locations SET item = " +loc.getItemID()+ ", checksum = " +loc.getChecksum()+ "";
        Statement st = c.createStatement();
        st.executeUpdate(query);
        st.close();
        c.close();
    }

    public void deleteLocation(String id) throws SQLException
    {
        String query = "DELETE FROM locations WHERE (id = " + id + ");";
        Statement st = c.createStatement();
        st.executeUpdate(query);
        st.close();
        c.close();
    }

    public void addLocation(Location loc) throws SQLException
    {
        String query = "INSERT INTO locations (item, checksum) VALUES ("+ loc.getItemID() + "," + loc.getChecksum() +")";
        Statement st = c.createStatement();
        st.executeUpdate(query);
        st.close();
        c.close();
    }

    public Location getLocation(String id) throws SQLException
    {
        String query = "SELECT * FROM locations WHERE (id = " + id + ")";
        Statement st = c.createStatement();
        ResultSet rs = st.executeQuery(query);
        Location loc = new Location(rs.getString("id"), rs.getInt("item"), rs.getInt("checksum"));
        st.close();
        c.close();
        return loc;
    }

    public void MarkItemAsDamaged(int id, int itemCounts) throws SQLException
    {
        String query = "UPDATE stock SET \"\\\"itemCounts\\\"\" = (SELECT (\"\\\"itemCounts\\\"\" - " + itemCounts + ") FROM stock WHERE item = "+id+")" +
                "WHERE item = "+id+";";
        Statement st = c.createStatement();
        st.executeUpdate(query);
        st.close();
        String query1 = "UPDATE damaged SET \"\\\"itemCounts\\\"\" = (SELECT (\"\\\"itemCounts\\\"\" + " + itemCounts + ") FROM damaged WHERE item = "+id+")" +
                "WHERE item = "+id+";";
        Statement st1 = c.createStatement();
        st1.executeQuery(query1);
        st1.close();
        c.close();
    }
    public void returnItem(int id, int count) throws SQLException
    {
        String query = "UPDATE stock SET \"\\\"itemCounts\\\"\" = (SELECT (\"\\\"itemCounts\\\"\" + " + count + ") FROM stock WHERE item = "+id+")" +
                "WHERE item = "+id+";";
        Statement st = c.createStatement();
        st.executeUpdate(query);
        st.close();
        c.close();
    }


}
