using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public float radius = 3f;
    public Transform interationTransform;

    bool isFocus = false;
    Transform player;

    bool hasInteracted = false;

    public virtual void Interact()
    {
        //Debug.Log("Interactive" + transform.name);
    }

    void Update()
    {
        if (isFocus && !hasInteracted)
        {
            float distance = Vector3.Distance(player.position, interationTransform.position);
            if (distance <= radius)
            {
                Interact();
                //Debug.Log("INTERACT");
                hasInteracted = true;
            }
        }
    }

    public void OnFocused (Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;
        hasInteracted = false;
    }

    public void OnDefocused()
    {
        isFocus = false;
        player = null;
        hasInteracted = false;
    }

    void OnDrawGizmoSelected()
    {
        if (interationTransform == null)
            interationTransform = transform;

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(interationTransform.position, radius);
    }
}
