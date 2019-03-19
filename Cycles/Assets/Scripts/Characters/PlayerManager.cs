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
    }

    public void KillPlayer()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void LevelUp()
    {
        
    }
}
