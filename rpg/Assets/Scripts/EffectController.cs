using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectController : MonoBehaviour
{
    Interactable focus;

    // Start is called before the first frame update
    void Update()
    {
        focus = GetComponentInParent<PlayerController>().focus;   
    }

    public void AttackCalculate()
    {
        if (focus == null)
        {
            return;
        }

        focus.GetComponent<EnemyController>().ShowHitEffect();
    }
}
