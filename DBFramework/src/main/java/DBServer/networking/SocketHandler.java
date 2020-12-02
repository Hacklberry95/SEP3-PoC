package DBServer.networking;

public class SocketHandler implements Runnable
{
    private ConnectionPool connectionPool;

    public SocketHandler(ConnectionPool connectionPool)
    {
        this.connectionPool = connectionPool;
    }

    @Override
    public void run()
    {

    }
}
