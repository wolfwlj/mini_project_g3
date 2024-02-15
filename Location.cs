public class Location
{
    public int ID;
    public string locationName;
    public string locationDescription;
    public Quest QuestAvailableHere;
    public Monster MonsterLivingHere;
    public Location LocationToNorth;
    public Location LocationToSouth;
    public Location LocationToEast;
    public Location LocationToWest;

    public void PopulateMap(){}


}