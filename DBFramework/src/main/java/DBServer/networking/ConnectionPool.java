package DBServer.networking;
import java.util.ArrayList;
import java.util.List;
public class ConnectionPool
{
    private List<SocketHandler> connections = new ArrayList<>();

    public synchronized void addHandler(SocketHandler handler)
    {
        connections.add(handler);
    }
    public void removeHandler(SocketHandler handler)
    {
        connections.remove(handler);
    }
}
