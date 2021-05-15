using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class NPC : Interactable
{
    public GameObject[] cm;

    private void Awake()
    {
        cm = GameObject.FindGameObjectsWithTag("CM");
        cm[0].SetActive(false);
    }

    public override void Interact()
    {
        base.Interact();

        if (gameObject.GetComponent<QuestGiver>() != null)
        {
            if (!gameObject.GetComponent<QuestGiver>().quest.isActive)
            {
                Quest();
                cm[1].SetActive(false);
                cm[0].SetActive(true);
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

    public void TurnCM()
    {
        cm[1].SetActive(true);
        cm[0].SetActive(false);
    }
}
