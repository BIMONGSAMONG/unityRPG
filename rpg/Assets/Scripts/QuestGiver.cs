using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;

    public GameObject questWindow;
    public Text titleText;
    public Text descriptionText;
    public Text goldText;

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);

        titleText.text = quest.title;
        descriptionText.text = quest.description;
        goldText.text = quest.goldReward.ToString();
    }
}
