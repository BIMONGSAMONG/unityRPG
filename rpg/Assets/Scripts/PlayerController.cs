using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(PlayerMotor))]
public class PlayerController : MonoBehaviour
{
    public Interactable focus;
    public LayerMask movementMask;
    public Transform focusPoint;

    GameObject focusObject;
    Camera cam;
    PlayerMotor motor;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        motor = GetComponent<PlayerMotor>();
    }

    // Update is called once per frame
    void Update()
    {
        if (focus != null)
        {
            focusPoint.position = focus.GetComponent<Transform>().position;   
            
            if (focusObject.activeSelf == false)
            {
                focus = null;
            }
        }
        else
        {
            focusPoint.gameObject.SetActive(false);
        }

        if (EventSystem.current.IsPointerOverGameObject())
            return;

        if (focusObject != GameObject.FindGameObjectWithTag("NPC"))
        {

        }
        
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit, 100, movementMask))
            {
                motor.MoveToPoint(hit.point);
                RemovwFocus(); 
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100))
            {
                Interactable interactable = hit.collider.GetComponent<Interactable>();
                focusObject = hit.collider.gameObject;
                if (interactable != null)
                {
                    SetFocus(interactable);
                    focusPoint.gameObject.SetActive(true);
                }
            }
        }

    }

    void SetFocus (Interactable newFocus)
    {
        if (newFocus != focus)
        {
            if (focus != null)
            {
                focus.OnDefocused();
            }

            focus = newFocus;
            motor.FolllowTarget(newFocus);
        }

        focus = newFocus;
        newFocus.OnFocused(transform);
        motor.FolllowTarget(newFocus);
    }

    void RemovwFocus()
    {
        if (focus != null)
            focus.OnDefocused();
        focus = null;
        motor.StopFollowingTarget();
    }
}
