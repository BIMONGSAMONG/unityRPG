using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinimapUI : MonoBehaviour
{
    public GameObject minimapUI;

    private void Update()
    {
        if (Input.GetButtonDown("Minimap"))
        {
            OnOff();
        }
    }

    public void OnOff()
    {
        minimapUI.SetActive(!minimapUI.activeSelf);
    }
}
