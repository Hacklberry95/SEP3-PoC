package DBServer.Data;

import java.util.ArrayList;
import java.util.List;

public class  Order
{
    private int orderId;
    private int orderState;
    private List<Integer> itemCounts;
    private List<Item> items;

    public Order()
    {
        orderId = -1;
        orderState = 0;
    }

    public Order(int orderId)
    {
        this.orderId = orderId;
        orderState = 0;
    }

    public Order(ArrayList<Item> items, ArrayList<Integer> itemCounts)
    {
        orderId = -1;
        orderState = 0;
        this.items = items;
        this.itemCounts = itemCounts;
    }

    public Order(int orderid, int orderstate, ArrayList<Integer> items, ArrayList<Integer> itemcounts)
    {
        this.orderId = orderid;
        this.orderState = orderstate;
        this.itemCounts = itemcounts;
        for (Integer i: items) {
            //SQL query for individual items based on ID list
        }
    }

    public void setOrderState(int i)
    {
        orderState = i;
    }

    public int getOrderState()
    {
        return orderState;
    }

    public void setOrderId(int id)
    {
        orderId = id;
    }

    public int getOrderId()
    {
        return orderId;
    }
    public List<Integer> getItemCounts()
    {
        return itemCounts;
    }

    public void setItemCounts(List<Integer> itemCounts) {
        this.itemCounts = itemCounts;
    }

    public List<Item> getItems() {
        return items;
    }

    public void setItems(List<Item> items) {
        this.items = items;
    }
}