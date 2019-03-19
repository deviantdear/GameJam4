using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyDescription : MonoBehaviour
{
    
    //String of game object
    public string myString;

    //Text on the UI canvas
    public Text textGameObject;

    //Determines text fade time
    private float fadeTime = 1.0f;

    //Determines if text is shown 
    public bool displayInfo;

    // Use this for initialization
    void Start()
    {
        //Finds text attached to game object hovering over
        textGameObject = GameObject.Find("Text").GetComponent<Text>();
        textGameObject.color = Color.clear;

        //Screen.showCursor = false;
        //Screen.lockCursor = true;
    }
    // Update is called once per frame
    void Update()
    {
        //Fades the text when cursor placed over game object
        FadeTheText();
    }
    void OnMouseOver()
    {
        //Displays info of GameObject
        displayInfo = true;
    }
    void OnMouseExit()
    {
        //Unshow info text pf game object
        displayInfo = false;
    }
    void FadeTheText()
    {
        //DisplayInfo state determines text fading functionality
        if (displayInfo)
        {
            //Set string of game object to be displayed 
            textGameObject.text = myString;
            textGameObject.color = Color.Lerp(textGameObject.color, Color.white, fadeTime * Time.deltaTime);
        }
        else
        {
            //Fades the text of game object out after cursor leaves the game object
            textGameObject.color = Color.Lerp(textGameObject.color, Color.clear, fadeTime * Time.deltaTime);
        }
    }

}
