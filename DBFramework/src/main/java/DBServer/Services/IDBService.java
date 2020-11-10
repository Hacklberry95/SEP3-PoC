package DBServer.Services;

import javax.jws.WebParam;
import java.sql.SQLException;

public interface IDBService
{
    void ConfirmOrder(@WebParam(name = "id") int id) throws SQLException;
}
