namespace miniproj

public class Potion
{
    public string PotionType;
    public int HealthGiven;

    public Potion(string potionType, int healthGiven)
    {
        PotionType = potionType;
        HealthGiven = healthGiven;
    }
}