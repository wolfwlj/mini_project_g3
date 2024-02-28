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
                }
                else
                {
                    Console.WriteLine("You cannot move in that direction.");
                }
            }
            else if (direction == "south")
            {
                if (locations.ContainsKey((x, y - 1)))
                {
                    y--;
                }
                else
                {
                    Console.WriteLine("You cannot move in that direction.");
                }
            }
            else if (direction == "east")
            {
                if (locations.ContainsKey((x + 1, y)))
                {
                    x++;
                }
                else
                {
                    Console.WriteLine("You cannot move in that direction.");
                }
            }
            else if (direction == "west")
            {
                if (locations.ContainsKey((x - 1, y)))
                {
                    x--;
                }
                else
                {
                    Console.WriteLine("You cannot move in that direction.");
                }
            }
        }
}