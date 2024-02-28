using System;

    public class Monster
    {
        public int ID;
        public string MonsterName;
        public int Health = 120;
        public int Damage = 20;
        public bool Equipped;
        public int Num1;
        public int Num2;
        public int Num3;
        public (int, int) Location;

        public Monster(int id, string monsterName, int num1, int num2, int num3, (int, int) location)
        {
            ID = id;
            MonsterName = monsterName;
            Num1 = num1;
            Num2 = num2;
            Num3 = num3;
            Location = location;
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