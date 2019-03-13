using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    public Vector3 offset;
    public float zoomSpeed = 4f;
    private float currentZoom =10f;
    public float minZoom = 5f;
    public float maxZoom = 15f;

    public float pitch = 2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

     void Update()
    {
        currentZoom -= Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
    }

    // Late Update is called once per frame after all other items in the frame have loaded
    void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch);
    }
}
