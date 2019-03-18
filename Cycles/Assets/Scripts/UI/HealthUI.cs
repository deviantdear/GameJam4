using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{
    // For Health Bar that appears above the object

    public GameObject uiPrefab;
    public Transform target;

    Transform ui;
    Image healthSlider;
    Transform cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main.transform; // references camera in scene

        foreach(Canvas C in FindObjectsOfType<Canvas>())
        {
            if(C.renderMode == RenderMode.WorldSpace)
            {
                ui = Instantiate(uiPrefab, C.transform).transform;
                healthSlider = ui.GetChild(0).GetComponent<Image>(); //Finds image child of prefab
                break;
            }
        }
    }

    // Update is called once per frame
    void LateUpdate()
    {
        ui.position = target.position; //Moves with player
        ui.forward = -cam.forward; //
    }
}
