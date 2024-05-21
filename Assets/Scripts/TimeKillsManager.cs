using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeKillsManager : MonoBehaviour
{
    float time = 0;
    int kills = 0;
    public Text timetext;
    public Text killstext;

    void Start()
    {
        
    }

   
    void Update()
    {
        timetext.text = "Time: " + time.ToString("F2");
        killstext.text = "Kills: " + kills;

        time += Time.deltaTime;

        PlayerPrefs.SetFloat("Time", time);
        PlayerPrefs.SetInt("Kills", kills);
    }

    public void Addkill()
    {
        kills++;
    }


    void CheckKillScore()
    {
        if (kills > PlayerPrefs.GetInt("KillScore", 0))
        {
            PlayerPrefs.SetInt("KillScore", kills);
        }
    }
    void CheckTimeScore()
    {
        if (PlayerPrefs.GetFloat("TimeScore") ==  0)
        {
            PlayerPrefs.SetFloat("TimeScore", time);
        }
        if (time < PlayerPrefs.GetFloat("TimeScore"))
        {
            PlayerPrefs.SetFloat("TimeScore", time);
        }
    }
    public void WonGame()
    {
        CheckKillScore();
        CheckTimeScore();
    }
}
