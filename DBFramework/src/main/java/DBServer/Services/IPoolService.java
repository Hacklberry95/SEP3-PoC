package DBServer.Services;

import DBServer.networking.SocketHandler;

public interface IPoolService {
     void addHandler(SocketHandler handler);
    void removeHandler(SocketHandler handler);
}
