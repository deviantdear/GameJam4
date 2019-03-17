using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkyBoxScript : MonoBehaviour
{
    public Material SkyOne;
    public Material SkyTwo;
    public int level3XP = 500;
    public int playerXP;

    // Start is called before the first frame update
    void Start()
    {
        RenderSettings.skybox = SkyOne; 
    }

    // Update is called once per frame
    void Update()
    {
        if (level3XP==playerXP || Input.GetKeyDown(KeyCode.Space))
        {
            RenderSettings.skybox = SkyTwo;
        }

    }
    //public static void UpdateEnvironment();

}
