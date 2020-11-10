package DBServer.Services;

import SQL.SQLQueryInterpreter;

import javax.jws.WebParam;
import javax.jws.WebService;
import java.sql.SQLException;

@WebService(endpointInterface = "DBServer.Services.IDBService", serviceName = "DatabaseService")
public class DBService implements IDBService
{
    public void ConfirmOrder(@WebParam(name = "id") int id) throws SQLException
    {
        SQLQueryInterpreter interpreter = new SQLQueryInterpreter();
        interpreter.newOrderConfirmQuery(id);

    }
}
