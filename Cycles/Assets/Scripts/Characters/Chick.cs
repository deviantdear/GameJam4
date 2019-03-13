using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerMover))]
public class Chick : MonoBehaviour
{
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
        if (Input.GetMouseButtonDown(0))
        {
            TravelToPoint();
        }
        if (Input.GetMouseButtonDown(1))
        {
            FocusOnObject();
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

            //Stop focusing any objects

        }
    }

    void FocusOnObject()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        //finds mouse click and filters to layer desired
        if (Physics.Raycast(ray, out hit, 100, movementMask))
        {
            //Check to see if you can interact
            //set as focus

        }
    }
}
