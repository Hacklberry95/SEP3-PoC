package DBServer.networking;

/**
 * Item class, matches Server's.
 */
public class Item
{
    private int id;
    private String name;
    private float weight;
    private float width;
    private float length;
    private float height;
    private String description;

    public int getId()
    {
        return id;
    }

    public void setId(int id)
    {
        this.id = id;
    }

    public String getName()
    {
        return name;
    }

    public void setName(String name)
    {
        this.name = name;
    }

    public float getWeight()
    {
        return weight;
    }

    public void setWeight(float weight)
    {
        this.weight = weight;
    }

    public float getWidth()
    {
        return width;
    }

    public void setWidth(float width)
    {
        this.width = width;
    }

    public float getLength()
    {
        return length;
    }

    public void setLength(float length)
    {
        this.length = length;
    }

    public float getHeight()
    {
        return height;
    }

    public void setHeight(float height)
    {
        this.height = height;
    }

    public String getDescription()
    {
        return description;
    }

    public void setDescription(String description)
    {
        this.description = description;
    }

    private float Volume()
    {
        return width * length * height;
    }

    public Item(String name, float weight, float width, float length, float height, String description)
    {
        this.name = name;
        this.weight = weight;
        this.width = width;
        this.length = length;
        this.height = height;
        this.description = description;
    }

    /**
     * Finishes setup of the Item class. WARNING: call immediately after server gets the ID for the Item added to the database.
     * @param id The ID from the database.
     */
    public void Setup(int id)
    {
        this.id = id;
    }
}
