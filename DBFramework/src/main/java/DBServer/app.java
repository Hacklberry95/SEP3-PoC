package DBServer;

import DBServer.Services.DBService;
import DBServer.Services.IDBService;
import SQL.SQLQueryInterpreter;
//import sun.rmi.transport.Endpoint;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
//import javax.xml.ws.Endpoint;
import java.sql.SQLException;

@SpringBootApplication
public class app
{
    public static void main(String[] args) throws SQLException, InterruptedException
    {
        /*IDBService service = new DBService();
        String address = "http://localhost:9000/dbServer";
        Endpoint.publish(address, service);

        System.out.println("The Server is ready ...");
        Thread.sleep(120 * 60 * 1000);
        System.out.println("Exiting the Server");
        System.exit(0);*/
        SpringApplication.run(app.class, args);
    }
}
