using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : Interactable
{
    public override void Interact()
    {
        base.Interact();

        Quest();
    }

    void Quest()
    {
        QuestGiver questGiver = GetComponent<QuestGiver>();
        questGiver.OpenQuestWindow();
    }
}
