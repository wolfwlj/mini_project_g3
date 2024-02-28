using System;

public class Map
{
    
    public Dictionary<(int, int), int> questLocations;

    public int x;
    public int y;
    public Dictionary<(int, int), int> locations;
    public Map()
    {
        x = 0;
        y = 0;
        locations = new Dictionary<(int, int), int>
        {
            {(0, 0), World.LOCATION_ID_HOME},
            {(0, 1), World.LOCATION_ID_TOWN_SQUARE},
            {(0, 2), World.LOCATION_ID_GUARD_POST},
            {(0, 3), World.LOCATION_ID_ALCHEMIST_HUT},
            {(1, 1), World.LOCATION_ID_ALCHEMISTS_GARDEN},
            {(2, 1), World.LOCATION_ID_FARMHOUSE},
            {(3, 1), World.LOCATION_ID_FARM_FIELD},
            {(-1, 1), World.LOCATION_ID_BRIDGE},
            {(-2, 1), World.LOCATION_ID_SPIDER_FIELD},
        };
        questLocations = new Dictionary<(int, int), int>
        {
            {(0, 3), World.QUEST_ID_CLEAR_ALCHEMIST_GARDEN},
            {(-2, 1), World.QUEST_ID_CLEAR_FARMERS_FIELD}, 
            {(3, 1), World.QUEST_ID_COLLECT_SPIDER_SILK}
        };
    }
        public void Move(string direction)
        {
            if (direction == "north")
            {
                // check if the location is valid
                if (locations.ContainsKey((x, y + 1)))
                {
                    y++;
                    Console.WriteLine("You moved north, you are now at " + World.LocationByID(locations[(x, y)]).LocationName);
                }
                else
                {
                    Console.WriteLine("You cannot move in that direction.");
                }
            }
            else if (direction == "south")
            {
                // check if the location is valid

                if (locations.ContainsKey((x, y - 1)))
                {
                    y--;
                    Console.WriteLine("You moved south, you are now at " + World.LocationByID(locations[(x, y)]).LocationName);
                }
                else
                {
                    Console.WriteLine("You cannot move in that direction.");
                }
            }
            else if (direction == "east")
            {
                // check if the location is valid

                if (locations.ContainsKey((x + 1, y)))
                {
                    x++;
                    Console.WriteLine("You moved east");
                    Console.WriteLine("You are now at " + World.LocationByID(locations[(x, y)]).LocationName);

                }
                else
                {
                    Console.WriteLine("You cannot move in that direction.");
                }
            }
            else if (direction == "west")
            {
                // check if the location is valid

                if (locations.ContainsKey((x - 1, y)))
                {
                    x--;
                    Console.WriteLine("You moved west");
                    Console.WriteLine("You are now at " + World.LocationByID(locations[(x, y)]).LocationName);
                }
                else
                {
                    Console.WriteLine("You cannot move in that direction.");
                }
            }
        }

        public void ShowDirections(){
            if (locations.ContainsKey((x, y + 1)))
            {
                Console.WriteLine("To your North is: " + World.LocationByID(locations[(x, y + 1)]).LocationName);
            } else {
                Console.WriteLine("There is nothing to the North");
            }
            if (locations.ContainsKey((x, y - 1)))
            {
                Console.WriteLine("To your South is: " + World.LocationByID(locations[(x, y - 1)]).LocationName);
            } else {
                Console.WriteLine("There is nothing to the South");
            }

            if (locations.ContainsKey((x + 1, y)))
            {
                Console.WriteLine("To your East is: " + World.LocationByID(locations[(x + 1, y)]).LocationName);
            } else {
                Console.WriteLine("There is nothing to the East");
            }
            if (locations.ContainsKey((x - 1, y)))
            {
                Console.WriteLine("To your West is: " + World.LocationByID(locations[(x - 1, y)]).LocationName);
            } else {
                Console.WriteLine("There is nothing to the West");
            }
        }
        public void CheckForQuests(Player player){
            if (questLocations.ContainsKey((x, y)))
            {
                int questID = questLocations[(x, y)];
                Quest quest = World.QuestByID(questID);
                if (quest != null && !quest.IsCompleted)
                {
                    Console.WriteLine($"You've found a quest: {quest.QuestDescription}");
                    Console.WriteLine("Press 'Y' to accept the quest, 'N' to decline");
                    char accept = Console.ReadLine()[0];
                    if (char.ToUpper(accept) == 'Y')
                    {
                        Console.WriteLine($"You've accepted the quest: {quest.QuestDescription}");
                        player.ActiveQuests.Add(quest);
                    }
                    else
                    {
                        Console.WriteLine("You've declined the quest.");
                    }
                }
            }
        }

}