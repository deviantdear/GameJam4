using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    #region Singleton

    public static PlayerManager instance;

    void Awake()
    {
        instance = this;
    }

    #endregion

    public GameObject player;
    public GameObject chick;
    public GameObject chicken;
    public GameObject axes;
    public GameObject egg;
    public CharacterStats charStats;
    private int xpPM;
    public TextMeshProUGUI xpUI;

    void Start()
    {
       charStats = player.GetComponent<CharacterStats>();
    }

    void Update()
    {
        xpPM = charStats.xp;
        xpUI.SetText("XP: " + xpPM);
        LevelUp();
    }

    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelUp()
    {
        if(xpPM >= 100)
        {
            chick.SetActive(false);
            chicken.SetActive(true);    
        }
        else if(xpPM >= 500)
        {
            axes.SetActive(true);
        }
        else if(xpPM >= 750) //Win Condition
        {
            //death animation
            Instantiate(egg, chicken.transform);
            chicken.SetActive(false);

        }
    }
}
