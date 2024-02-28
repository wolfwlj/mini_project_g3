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

        public Monster(int id, string monsterName, int num1, int num2, int num3)
        {
            ID = id;
            MonsterName = monsterName;
            Num1 = num1;
            Num2 = num2;
            Num3 = num3;
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