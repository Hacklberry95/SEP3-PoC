package SQL;

import DBServer.Data.Item;
import DBServer.Data.Order;
import DBServer.Data.User;

import java.sql.SQLException;

public interface ISQLQueryInterpreter {
    void newOrderConfirmQuery(int i) throws SQLException;
    void addItem(Item item) throws SQLException;
    void removeItem(int id) throws SQLException;
    void updateItem(Item item) throws SQLException;
    Item getItem(int id) throws SQLException;
    Order getOrderById(int id) throws SQLException;
    User getUserById(String username) throws SQLException;
}
