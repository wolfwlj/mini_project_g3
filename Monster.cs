
namespace miniproj
public class Monster
{
    public int ID;
    public string MonsterName;
    public int Power = 30
    public int Health = 150;
    public bool Equipped;

    public Monster(int id, string monsterName, int power, bool equipped, int health)
    {
        ID = id;
        MonsterName = monsterName;
        Power = power;
        Equipped = equipped;
        Health = health;
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