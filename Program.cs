using System;

public class Program
{
    public static void Main()
    {
        bool playing = true;

        // Monster monster1 = new Monster(1, "Golem", 1, 4, 4);
        Weapon starterWeapon = new Weapon(1, "rusty sword", 3);
        World.PopulateLocations();
        
        Map map = new Map();

        Console.WriteLine("Enter the name you would like to be known as: ");
        string playerName = Console.ReadLine();
        Player player1 = new Player(playerName);
        player1.Inventory.Add(starterWeapon);
        Potion smallPotion = new Potion("A small health potion", 20);
        player1.PotionInventory.Add(smallPotion);

        // veel potions want je kan ze nog niet vinden in de wereld(denk ik)
        Potion bigPotion1 = new Potion("A big health potion.", 100);
        player1.PotionInventory.Add(bigPotion1);

        Potion bigPotion2 = new Potion("A big health potion.", 100);
        player1.PotionInventory.Add(bigPotion2);

        Potion bigPotion3 = new Potion("A big health potion.", 100);
        player1.PotionInventory.Add(bigPotion3);
        
        Potion bigPotion4 = new Potion("A big health potion.", 100);
        player1.PotionInventory.Add(bigPotion4);
        
        Potion bigPotion5 = new Potion("A big health potion.", 100);
        player1.PotionInventory.Add(bigPotion5);
        
        Potion bigPotion6 = new Potion("A big health potion.", 100);
        player1.PotionInventory.Add(bigPotion6);

        Console.WriteLine($"Welcome to the game {playerName}! You have awoken from a deep slumber in your humble abode, you may move elsewhere or enjoy the calm and peace of your home.");
    

        while (playing)
        {
            Console.WriteLine("Enter '1' to move, '2' to view inventory, '3' to view stats, '4' to view map, '5' to quit");
            string input = Console.ReadLine();
            if (input == "1")
            {
                Movement(map);
                // check if the location has a quest
                map.CheckForQuests(player1);
                // check if the location has a monster
                
                for (int i = 0; i < World.Monsters.Count; i++)
                {
                    if (World.Monsters[i].Location == (map.x, map.y))
                    {
                        Monster monster = World.Monsters[i];
                        if (Fight(player1, monster))
                        {
                            player1.WinFight();
                        } 
                        else
                        {
                            map.x = 0;
                            map.y = 0;
                        }
                    }
                }

                if (map.x == 2 && map.y == 2)
                {
                    Console.WriteLine("You are now at the farmer's field.");
                    Console.WriteLine("Quick! Kill the snakes by typing 'kill'.");

                    string action = Console.ReadLine()?.ToLower();

                    if (action == "kill")
                    {
                        Console.WriteLine("You've successfully killed all the snakes in the field!");
                        Console.WriteLine("CONGRATULATIONS, YOU HAVE FINISHED THE GAME!!!");
                        playing = false;
                    }
                    else
                    {
                        Console.WriteLine("Oh no, the snake bit you!");
                        player1.HealthPoints -= 10; // 10 damage from each snake bite
                        if (player1.HealthPoints <= 0)
                        {
                            Console.WriteLine("No health left. Game over :(");
                            playing = false; // This is for the game over (when you have no health left)
                        }
                    }
                }
            }
            else if (input == "2")
            {
                Console.WriteLine("You have the following items in your inventory:");
                foreach (var item in player1.Inventory)
                {
                    Console.WriteLine(item.WeaponType);
                }
                Console.WriteLine("You have the following potions in your inventory:");
                foreach (var item in player1.PotionInventory)
                {
                    Console.WriteLine(item.PotionType);
                }
            }
            else if (input == "3")
            {
                Console.WriteLine($"Your current health is: {player1.HealthPoints}");
                Console.WriteLine($"Your current level is: {player1.PlayerLevel}");
                Console.WriteLine($"Your current XP is: {player1.PlayerXP}");
            }
            else if (input == "4")
            {
                Console.WriteLine($"You are here: {World.LocationByID(map.locations[(map.x, map.y)]).LocationName}");
                // tell player what locations are adjacent
                map.ShowDirections();
            }
            else if (input == "5")
            {
                Console.WriteLine($"Fare thee well {playerName}, and godspeed!");
                playing = false;
            }
            else
            {
                Console.WriteLine("Invalid input, try again.");
            }
        }
    }

    public static bool Fight(Player player, Monster monster)
    {
        Console.WriteLine($"You've encountered a {monster.MonsterName}, a powerful foe. Choose your next move wisely tarnished.");
        Console.WriteLine($"Remember, your current health stands at {player.HealthPoints}");
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
                Console.WriteLine($"The {monster.MonsterName} has striked back, dealing a total of {monster.Attack()} damage on you.");
                monster.Health -= player.Attack();
                player.HealthPoints -= monster.Attack();
                Console.WriteLine();
                if (monster.Health > 0)
                {
                    Console.WriteLine($"Your current health stands at {player.HealthPoints}, the monster has {monster.Health} health remaining, interesting...");
                }
                else if (monster.Health == 0 || player.HealthPoints == 0)
                {
                    Console.WriteLine($"Your current health stands at {player.HealthPoints}, the monster has {monster.Health} health remaining, meaning: ");
                }
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
        } 
        else
        {
            Console.Write("Invalid input");
        }
    }
}
