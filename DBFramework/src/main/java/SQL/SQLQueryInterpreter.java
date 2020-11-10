package SQL;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;
import java.sql.Statement;

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
        String query = "UPDATE \"Orders\" SET state = 4 WHERE id = " + i + ";";
        Statement st = c.createStatement();
        st.executeUpdate(query);
        st.close();
        c.close();
    }
}
