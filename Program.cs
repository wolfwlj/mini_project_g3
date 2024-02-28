using System;

public class Program
{

    public static void Main()
    {
        bool playing = true;


        Player player1 = new Player("p1");
        Monster monster1 = new Monster(1, "Golem", 1, 4, 4);
        Weapon starterWeapon = new Weapon(1, "rusty sword", 3);
        player1.Inventory.Add(starterWeapon);
        Potion smallPotion = new Potion("A small health potion", 20);
        player1.PotionInventory.Add(smallPotion);
        Potion bigPotion = new Potion("A big health potion. Not easily found", 100);
        player1.PotionInventory.Add(bigPotion);
    //  public Location(int id, string locName, string desc, Quest? quest, Monster? monster)
        World.PopulateLocations();
        
        Map map = new Map();

        Console.WriteLine("Welcome to the game player! You have awoken from a deep slumber in your humble abode, you may move elsewhere or enjoy the calm and peace of your home. (i recommend moving)");
        

        while (playing)
        {
            Console.WriteLine("Enter '1' to move, '2' to view inventory, '3' to view stats, '4' to view map, '5' to quit");
            string input = Console.ReadLine();
            if (input == "1")
            {
                Movement(map);
                map.CheckForQuests(player1);
                // check if the location has a quest



            }
            else if (input == "4")
            {
                Console.WriteLine($"You are here: {World.LocationByID(map.locations[(map.x, map.y)]).LocationName}");
                // tell player what locations are adjacent
                map.ShowDirections();
            
            }
            else if (input == "5")
            {
                playing = false;
            }
            else
            {
                Console.WriteLine("Invalid input, try again.");
            }
        }


        // Fight(player1, monster1);
    }

    public static bool Fight(Player player, Monster monster)
    {
        Console.WriteLine($"You've encountered a {monster.MonsterName}, a powerful foe. Choose your next move wisely tarnished.");
        while (monster.Health > 0 || player.HealthPoints > 0) 
        {
            Console.WriteLine();
            Console.WriteLine("Choose what to do:\nQ: Attack\nE: Heal");
            char input = Console.ReadLine()[0];
            if (char.ToUpper(input) == 'E')
            {
                if (player.PotionInventory.Count >= 1)
                {
                    Potion usedPotion = player.PotionInventory[0];
                    player.HealthPoints += usedPotion.HealthGiven;
                    Console.WriteLine($"You've used a {usedPotion.PotionType} replenishing your health by {usedPotion.HealthGiven}");
                    player.PotionInventory.Remove(usedPotion);
                }
                else
                {
                    Console.WriteLine("You have no potions in your inventory...");
                }
            }
            else if (char.ToUpper(input) == 'Q')
            {
                Console.WriteLine("You have chosen to attack, bold move...");
                Console.WriteLine();
                Console.WriteLine($"You have attacked {monster.MonsterName} for {player.Attack()} damage but beware, as he will strike back.");
                Console.WriteLine($"The {monster.MonsterName} has striked back, dealing a total of {monster.Attack()} damage on you, goddamn.");
                monster.Health -= player.Attack();
                player.HealthPoints -= monster.Attack();
                Console.WriteLine();
                Console.WriteLine($"Your current health stands at {player.HealthPoints}, the monster has {monster.Health} health remaining, interesting...");
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
    public static void Movement(Map map)
    {

            Console.Write("Enter a direction (North, East, South, West) : ");
            string input = Console.ReadLine()!.Trim();
            input = input.ToLower();
            if (input == "north" || input == "south" || input == "east" || input == "west")
            {
                map.Move(input);
            } else
            {
                Console.Write("Invalid input");
            }
    }
}
