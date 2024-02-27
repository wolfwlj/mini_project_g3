
namespace miniproj
{
    public class Location
    {
        public int ID;
        public string LocationName;
        public string LocationDescription;
        public Quest QuestAvailableHere;
        public Monster MonsterLivingHere;
        public Location LocationToNorth;
        public Location LocationToSouth;
        public Location LocationToEast;
        public Location LocationToWest;

        public Location(int id, string locName, string desc, Quest? quest, Monster? monster)
        {
            ID = id;
            LocationName = locName;
            LocationDescription = desc;
            QuestAvailableHere = quest!;
            MonsterLivingHere = monster!;
        }


        public void PopulateMap(){}
    }
}