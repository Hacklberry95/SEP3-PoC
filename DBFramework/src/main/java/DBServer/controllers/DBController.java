package DBServer.controllers;

import DBServer.Services.IDBService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.web.bind.annotation.*;

import java.sql.SQLException;

@RestController
@RequestMapping("/team")
public class DBController
{
    @Autowired
    IDBService idbService;
    //
    //  TeamService service;

    @PostMapping("/WOrder")
    public void writeOrder(@RequestBody final int id)
    {
        System.out.println("WriteOrderPostMap");
        try {
            idbService.ConfirmOrder(id);
        }
        catch (SQLException e)
        {
            e.printStackTrace();
        }
    }





}
