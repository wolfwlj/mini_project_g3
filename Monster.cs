
namespace miniproj
public class Monster
{
    public int ID;
    public string MonsterName;
    public int Power = 30
    public int Health = 150;
    public Weapon Equipped;

    public Monster(int id, string monsterName, int power, Weapon equipped, int health)
    {
        ID = id;
        MonsterName = monsterName;
        Power = power;
        Equipped = equipped;
        Health = health;
    }

}