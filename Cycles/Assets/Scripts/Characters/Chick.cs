using UnityEngine.EventSystems;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class Chick : MonoBehaviour
{
    public Interactable focus;

    //Layermask prevents us from targeting objects we don't mean to when moving
    public LayerMask movementMask;

    Camera cam;
    PlayerMover mover;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        mover = GetComponent<PlayerMover>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject()) //Pauses game when player pointer is hovering over UI elements
            return;

        if (Input.GetMouseButtonDown(0))
        {
            TravelToPoint();
        }
        if (Input.GetMouseButtonDown(1))
        {
            isInteractable();
        }
    }

    void TravelToPoint()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //finds mouse click and filters to layer desired
        if (Physics.Raycast(ray, out hit, 100, movementMask))
        {
            Debug.Log("Object hit=" + hit.collider.name + " " + hit.point);
            //Moving player to mouse click location
            mover.MoveToPoint(hit.point);

            removeFocus();

        }
    }

    void isInteractable()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //finds mouse click and filters to layer desired
        if (Physics.Raycast(ray, out hit, 100))
        {
            Debug.Log("Object hit=" + hit.collider.name + " " + hit.point);

           //Check to see if you can interact
           Interactable interactable = hit.collider.GetComponent<Interactable>();

            //set as focus
            if (interactable != null)
            {
                SetFocus(interactable);
            }
        }
    }

    void SetFocus(Interactable newFocus)
    {
        if(newFocus != focus)
        {
            if(focus != null)
                focus.OnDefocused();

            focus = newFocus;
            mover.FollowTarget(newFocus);
        }    
        newFocus.OnFocused(transform); //Sends players transform to Interactable
    }

    void removeFocus()
    {
        if (focus != null)
            focus.OnDefocused();

        focus = null;
        mover.stopFollowing();
    }

}
