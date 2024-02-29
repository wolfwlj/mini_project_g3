using System;

public class Quest
{
    public int ID;
    public string QuestDescription;
    public string QuestObjective;
    public bool IsCompleted;
    public List<Weapon> Rewards;

    public Quest(int id, string questDescription, string questObjective, bool isCompleted)
    {
        ID = id;
        QuestDescription = questDescription;
        QuestObjective = questObjective;
        IsCompleted = isCompleted;
    }

    public void AddReward(Weapon reward)
    {
        Rewards.Add(reward);
    }

    public List<Weapon> GetRewards()
    {
        return Rewards;
    }

}


