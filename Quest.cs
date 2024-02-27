using System;

public class Quest
{
    public int ID;
    public string QuestDescription;
    public string QuestObjective;
    public List<Weapon> Rewards;

    public Quest(int id, string questDescription, string questObjective)
    {
        ID = id;
        QuestDescription = questDescription;
        QuestObjective = questObjective;
        Rewards = new List<Weapon>();
    }

    public void AddReward(Weapon reward)
    {
        Rewards.Add(reward);
    }

}