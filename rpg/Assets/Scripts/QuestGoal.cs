﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum GoalType
{
    Kill, Gathering
}

[System.Serializable]
public class QuestGoal
{
    public GoalType goalType;

    public int requiredAmount;
    public int currentAmount;

    public bool IsReached()
    {
        return (currentAmount >= requiredAmount);
    }

    public void EnmeyKilled()
    {
        if(goalType == GoalType.Kill)
            currentAmount++;
    }

    public void ItemColleted()
    {
        if (goalType == GoalType.Gathering)
            currentAmount++;
    }

}
