package SQL;

import DBServer.networking.Item;

import java.sql.*;

public class SQLQueryInterpreter
{
    private Connection c;

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
        //write rs.getObject statements in Item creation
        Item item = new Item();
        return item;
    }
}
