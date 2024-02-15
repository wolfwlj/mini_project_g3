public class Player
{
    public string PlayerName;
    public Weapon Equipped;
    public int HealthPoints = 100;
    public int Damage = 10;
    public int PlayerLevel = 1;
    public int PlayerXP = 0;
    public List<Weapon> Inventory;
    public List<Quest> ActiveQuests;

    public Player(string name)
    {
        PlayerName = name;
        Inventory = new List<Weapon>();
        ActiveQuests = new List<Quest>();
    }
}