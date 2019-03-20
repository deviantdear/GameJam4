using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.AI;

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
    public GameObject monster;
    public GameObject egg;
    public CharacterStats charStats;
    private int xpPM;
    public TextMeshProUGUI xpUI;
    public GameObject winText;
    public NavMeshAgent navAgent;

    void Start()
    {
       charStats = player.GetComponent<CharacterStats>();
        navAgent = player.GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        xpPM = charStats.xp;
        xpUI.SetText("XP: " + xpPM);
        LevelUp();
    }

    public void KillPlayer()
    {
        SceneManager.LoadScene("ChickenCoop");
    }

    public void LevelUp()
    {
        if(xpPM >= 100)
        {
            chick.SetActive(false);
            chicken.SetActive(true);
            charStats.armor.AddModifier(1);
            charStats.damage.AddModifier(5);
        }
        if(xpPM >= 500)
        {
            monster.SetActive(true);
            chicken.SetActive(false);
            charStats.armor.AddModifier(2);
            charStats.damage.AddModifier(5);
        }
        if(xpPM >= 750) //Win Condition
        {
            //death animation
            egg.SetActive(true);
            monster.SetActive(false);
            winText.SetActive(true);
            Time.timeScale = 0;

        }
    }
}
