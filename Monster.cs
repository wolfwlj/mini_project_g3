public class Monster
{
    public int ID;
    public string MonsterName;
    public int Power;
    public Weapon Equipped;

    public Monster(int id, string monsterName, int power, Weapon equipped)
    {
        ID = id;
        MonsterName = monsterName;
        Power = power;
        Equipped = equipped;
    }

}