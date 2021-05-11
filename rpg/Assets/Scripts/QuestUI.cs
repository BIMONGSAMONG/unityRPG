using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestUI : MonoBehaviour
{
    public GameObject questUI;
    public GameObject questTitle;
    public GameObject questStory;

    public Text title;
    public Text story;
    public Text cAmount;
    public Text rAmount;
   
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Quest"))
        {
            OnOff();
        }

        if ((gameObject.activeSelf)
            &&(player.GetComponent<PlayerStats>().quest.isActive))
        {
            OnQuest();
        }
    }

    public void OnOff()
    {
        questUI.SetActive(!questUI.activeSelf);
    }

    void OnQuest ()
    {
        if (!questTitle.activeSelf)
        {
            questTitle.SetActive(true);
        }

        title.text = player.GetComponent<PlayerStats>().quest.title;
        story.text = player.GetComponent<PlayerStats>().quest.description;
        cAmount.text = player.GetComponent<PlayerStats>().quest.goal.currentAmount.ToString();
        rAmount.text = player.GetComponent<PlayerStats>().quest.goal.requiredAmount.ToString();
    }
}
