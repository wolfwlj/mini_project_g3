using System;

public class Map
{
    
    private Dictionary<(int, int), int> questLocations;

    private int x;
    private int y;
    private Dictionary<(int, int), int> locations;
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

        public void Move(string direction)
        {
            switch (direction.ToLower())
            {
                case "north":
                    if (x == 0 && y == 3)
                    {
                        Console.WriteLine("You cannot go further north, pick a different direction");
                        break;
                    }
                    else
                    {
                        y++;
                    }
            }
        }

    }
}