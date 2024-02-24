
namespace miniproj
public class Monster
{
    public int ID;
    public string MonsterName;
    public int Power = 30
    public int Health = 150;
    public bool Equipped;

    public Monster(string monsterName, bool equipped)
    {
        MonsterName = monsterName;
        Equipped = equipped;
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