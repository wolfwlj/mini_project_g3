namespace miniproj  
using System;

namespace miniproj  
{
    public class Program
    {
        Fight(player1, monster1);
    }
    public static bool Fight(Player player, Monster monster)
    {
        while (monster.Health > 0 || player.HealthPoints > 0) 
        {
            Player player1 = new Player("p1");
            Monster monster1 = new Monster("Golem", true);
            Weapon starterWeapon = new Weapon(3, true);
            player1.Inventory.Add(starterWeapon);
            Potion smallPotion = new Potion("A small health potion", 20);
            player1.PotionInventory.Add(smallPotion);
            public static void Main()
            
                Fight(player1, monster1)
        }
            public static bool Fight(Player player, Monster monster)
            {
                while (monster.Health > 0 || player.HealthPoints > 0) 
                {
                    Console.WriteLine("Choose what to do:\nQ: Attack\nE: Heal");
                    char input = Console.ReadLine()[0];
                    if (char.ToUpper(input) == 'E')
                    {
                        if (player.PotionInventory.Count >= 1)
                        {
                            Potion usedPotion = player.PotionInventory[0];
                            player.HealthPoints += usedPotion.HealthGiven;
                            Console.WriteLine($"You've used a {usedPotion.PotionType} replenishing your health by {usedPotion.HealthGiven}");
                        }
                        else
                        {
                            Console.WriteLine("You have no potions in your inventory...");
                        }
                    }
                    else if (char.ToUpper(input) == 'Q')
                    {
                        Console.WriteLine("You have chosen to attack, bold move...");
                        monster.Health -= player.Attack();
                        player.HealthPoints -= monster.Attack();
                        if (player.HealthPoints <= 0)
                        {
                            Console.WriteLine("Your journey has come to an end tarnished, you will be relocated at your home where you may start again.");
                            return false;
                        }
                        else if (monster.Health <= 0)
                        {
                            Console.WriteLine("You have beaten the monster in epic grandeur! Loot his corpse for potential items.");
                            return true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid input tarnished, enter something that i understand.");
                    }
                }
                return true;
            }
        }
    }
}