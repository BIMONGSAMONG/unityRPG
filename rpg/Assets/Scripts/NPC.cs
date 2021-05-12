using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{

    public override void Interact()
    {
        base.Interact();

        if (gameObject.GetComponent<QuestGiver>() != null)
        {
            if (!gameObject.GetComponent<QuestGiver>().quest.isActive)
            {
                Quest();
            }
            else if ((gameObject.GetComponent<QuestGiver>().quest.isActive)
                && (gameObject.GetComponent<QuestGiver>().quest.goal.IsReached()))
            {
                Clear();
            }
            else
            {

            }
        }  
    }

    void Quest()
    {
        gameObject.GetComponent<QuestGiver>().OpenQuestWindow();
    }

    void Clear()
    {
        gameObject.GetComponent<QuestGiver>().OpenClearQuest();
    }
}
