public class Quest
{
    public int ID;
    public string QuestDescription;
    public string QuestObjective;
    public int GivenXP;
    public int GivenGold;

    public Quest(int id, string questDescription, string questObjective, int givenXP, int givenGold)
    {
        ID = id;
        QuestDescription = questDescription;
        QuestObjective = questObjective;
        GivenXP = givenXP;
        GivenGold = givenGold;
    }

}