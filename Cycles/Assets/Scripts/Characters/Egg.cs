using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Egg : MonoBehaviour
{
    #region Variables
    public float speed;
    private Rigidbody rb;

    //UI
    private int count;
    private float bonus;

    //Jump
    private float cooldownTime = 2;
    private float nextJumpTime = 0;
    public float jumpPower;

    //Sounds
    public AudioClip eggSound;

    #endregion

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        rb.AddForce(movement * speed);
        if (Time.time > nextJumpTime)
        {
            if (Input.GetKeyDown("space"))
            {
                rb.AddForce(new Vector3(0f, jumpPower, 0f), ForceMode.Impulse);
                nextJumpTime = Time.time + cooldownTime;
                cooldownTime = 1.0f;
            }
        }
    }

    // Grab everything that enters the trigger
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            //Sound Effect
            this.GetComponent<AudioSource>().PlayOneShot(eggSound);
            Debug.Log("Freeeeedoom");

        }

    }
}
