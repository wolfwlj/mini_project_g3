using System;
using System.Collections.Generic;

namespace miniproj
{
    public class Player
    {
        public string PlayerName;
        public bool Equipped;
        public int HealthPoints = 100;
        public int Damage = 10;
        public int PlayerLevel = 1;
        public int PlayerXP = 1;
        public List<Weapon> Inventory;
        public List<Potion> PotionInventory;
        public List<Quest> ActiveQuests;

        public Player(string name)
        {
            PlayerName = name;
            Inventory = new List<Weapon>();
            ActiveQuests = new List<Quest>();
            PotionInventory = new List<Potion>();
        }

        public string GetXP(int xp)
        {
            int nextLevel = PlayerLevel * 50;
            PlayerXP += xp;
            if (PlayerXP >= nextLevel)
            {
                PlayerLevel++;
                PlayerXP -= nextLevel;
                return $"You have leveled up! Your current level is {PlayerLevel}";
            }
            return $"EXP gained: {xp}/{nextLevel}";
        }

        public string RecoverHealth(int hp)
        {
            if (HealthPoints == 100)
            {
                return "You are already at full health, no need to heal!";
            }
            HealthPoints += hp;
            return $"Good healing! Your are now at {HealthPoints} HP";
        }

        public void CompleteQuest(Quest completeQuest)
        {
            foreach (var item in completeQuest.Rewards)
            {
                if (item is Weapon weapon)
                {
                    Inventory.Add(weapon);
                }
            }
            ActiveQuests.Remove(completeQuest);
        }

        public void WinFight()
        {
            Random random = new Random();
            int randomPower = random.Next(5, 20);
            Weapon randomWeapon = new Weapon(randomPower, false);
            Inventory.Add(randomWeapon);
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
}
