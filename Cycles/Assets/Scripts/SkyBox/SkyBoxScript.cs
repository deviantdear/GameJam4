using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxScript : MonoBehaviour
{
    public Material SkyOne;
    public Material SkyTwo;
    public int level3XP = 500;
    public int playerXP;
    public Light lt;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = SkyOne;
        lt = GetComponent<Light>();
    }

    // Update is called once per frame
    void Update()
    {
        if (level3XP==playerXP || Input.GetKeyDown(KeyCode.Space))
        {
            RenderSettings.skybox = SkyTwo;
            lt.color -= (Color.red / 2.0f) * Time.deltaTime;
        }

    }
    //public static void UpdateEnvironment();

}
