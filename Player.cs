
namespace miniproj
public class Player
{
    public string PlayerName;
    public bool Equipped;
    public int HealthPoints = 100;
    public int Damage = 10;
    public int PlayerLevel = 1;
    public int PlayerXP = 1;
    public List<Weapon> Inventory;
    public List<Quest> ActiveQuests;

    public Player(string name)
    {
        PlayerName = name;
        Inventory = new List<Weapon>();
        ActiveQuests = new List<Quest>();
    }


    public string GetXP(int xp)
    {
        int nextLevel = PlayerXP * 50;
        PlayerXP += xp;
        if (PlayerXP >= nextLevel)
        {
            PlayerLevel++;
            PlayerXP = xp - nextLevel;
            return $"You have leveled up! Your current level is {PlayerLevel}";
        }
        return $"EXP gained: {xp}/{nextLevel}";
    }

    public string RecoverHealth(int hp)
    {
        if (HealthPoints == 100;)
        {
            return "You are already at full health, no need to heal!";
        }
        HealthPoints += hp;
        return $"Good healing! Your are now at {HealthPoints} HP";
    }

    public int Attack()
    {
        if (Equipped)
        {
            return Damage * 2;
        }
        return Damage;
    }
}