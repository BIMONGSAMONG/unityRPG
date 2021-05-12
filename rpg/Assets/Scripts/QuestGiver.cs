using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestGiver : MonoBehaviour
{
    public Quest quest;

    public PlayerStats player;

    public GameObject questWindow;
    public Text titleText;
    public Text descriptionText;
    public Text goldText;

    public GameObject qIcon;
    public GameObject wIcon;

    public GameObject questClearWindow;
    public Text rewardText;

    Transform cam;
    Quaternion rotation;

    private void Start()
    {
        cam = Camera.main.transform;
    }

    private void Update()
    {
        if (quest.isActive == false)
        {
            Vector3 relativePos = wIcon.transform.position - cam.position;
            rotation = Quaternion.LookRotation(-relativePos, Vector3.up);
            wIcon.transform.rotation = rotation;

            wIcon.SetActive(true);
        }
        else
        {
            if (wIcon.activeSelf)
            {
                wIcon.SetActive(false);
            }

            if (!quest.goal.IsReached())
            {
                qIcon.GetComponentInChildren<MeshRenderer>().material.color = Color.gray;
            }
            else
            {
                qIcon.GetComponentInChildren<MeshRenderer>().material.color = Color.yellow;
            }
            

            Vector3 relativePos = qIcon.transform.position - cam.position;
            rotation = Quaternion.LookRotation(-relativePos, Vector3.up);
            qIcon.transform.rotation = rotation;

            qIcon.SetActive(true);
        }
    }

    public void OpenQuestWindow()
    {
        questWindow.SetActive(true);

        titleText.text = quest.title;
        descriptionText.text = quest.description;
        goldText.text = quest.goldReward.ToString();
    }

    public void AcceptQuest()
    {
        questWindow.SetActive(false);
        quest.isActive = true;
        player.quest = quest;
    }

    public void OpenClearQuest()
    {
        questClearWindow.SetActive(true);
        rewardText.text = quest.goldReward.ToString();
    }

    public void ClearQuest()
    {
        questClearWindow.SetActive(false);
        Money.instance.money += quest.goldReward;
        quest.Complete();
        qIcon.SetActive(false);

        Destroy(gameObject.GetComponent<QuestGiver>());
    }
}
