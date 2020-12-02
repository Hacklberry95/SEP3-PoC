package DBServer.Services;

import DBServer.networking.SocketHandler;
import org.springframework.stereotype.Service;

import java.util.ArrayList;
import java.util.List;
@Service
public class PoolService implements IPoolService
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
