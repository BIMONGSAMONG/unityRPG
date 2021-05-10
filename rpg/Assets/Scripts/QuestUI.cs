using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestUI : MonoBehaviour
{
    public GameObject questUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Quest"))
        {
            OnOff();
        }
    }

    public void OnOff()
    {
        questUI.SetActive(!questUI.activeSelf);
    }
}
