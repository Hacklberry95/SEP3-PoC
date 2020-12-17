package SQL;

import DBServer.Data.Item;
import DBServer.Data.Location;
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
    boolean getUserBoolean(String username) throws SQLException;
    void finalizePick(int id) throws SQLException;
    void cancelOrder(int id) throws SQLException;
    void cutFromOrder(int id, int itemID, int itemCount) throws SQLException;
    void allocPutaway(String locationID, int itemID) throws SQLException;
    void updateLocation(Location loc) throws SQLException;
    void deleteLocation(String id) throws SQLException;
    void addLocation(Location loc) throws SQLException;
    Location getLocation(String id) throws SQLException;
    void MarkItemAsDamaged(int id, int itemCounts) throws SQLException;
    void returnItem(int id, int count) throws SQLException;
}
