package DBServer.Data;

public class Location
{
    private String id;
    private int itemID;
    private int checksum;

    public Location(String id, int itemID, int checksum)
    {
        this.id = id;
        this.itemID = itemID;
        this.checksum = checksum;
    }

    public String getId()
    {
        return id;
    }

    public void setId(String id)
    {
        this.id = id;
    }

    public int getItemID()
    {
        return itemID;
    }

    public void setItemID(int itemID)
    {
        this.itemID = itemID;
    }

    public int getChecksum()
    {
        return checksum;
    }

    public void setChecksum(int checksum)
    {
        this.checksum = checksum;
    }
}
