namespace miniproj  

public class Program
{
    public static bool Fight(Player player, Monster monster)
    {
        if (player.HealthPoints =< 0)
        {
            Console.WriteLine("Your journey has come to an end tarnished, you will be relocated at your home where you may start again.");
            return false;
        }
        while (monster.Health > 0 || player.HealthPoints > 0) 
        {
            Console.WriteLine("Choose what to do:\nQ: Attack\nE: Heal");
            char input = Console.ReadLine();
            if (char.ToUpper(input) == 'E')
            {
                if (player.HealthPoints =< 20)
                {
                    player.RecoverHealth(30);
                    Console.WriteLine($"Your health has been increased by 30, that was a close one! Current health: {player.HealthPoints}");
                }
                player.RecoverHealth(10);
                Console.WriteLine($"Your health has been increased by 10. Current health: {player.HealthPoints}")
            }
            else if (char.ToUpper(input) == 'Q')
            {
                Console.WriteLine("You have chosen to attack, bold move...");
                monster.Health -= player.Attack();
                player.HealthPoints -= monster.Attack();
            }
        }
        return true;
    }
}