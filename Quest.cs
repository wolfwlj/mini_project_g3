namespace miniproj

public class Quest
{
    public int ID;
    public string QuestDescription;
    public string QuestObjective;

    public Quest(int id, string questDescription, string questObjective)
    {
        ID = id;
        QuestDescription = questDescription;
        QuestObjective = questObjective;
    }

}