using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{

    public Text besttime;
    public Text bestkills;
    public Text currentkills;
    public Text currenttime;

    void Start()
    {
        
    }

    
    void Update()
    {
        currentkills.text = $"Current kills:  {PlayerPrefs.GetInt("Kills", 0)}";
        bestkills.text = $"Best kills:  {PlayerPrefs.GetInt("KillScore", 0)}";
        currenttime.text = $"Current time:  {PlayerPrefs.GetFloat("Time", 0).ToString("F2")}";
        besttime.text = $"Best time:  {PlayerPrefs.GetFloat("TimeScore", 0).ToString("F2")}";
    }
    public void Quit()
    {
        Application.Quit();
    }
    public void Button(string destination)
    {
        SceneManager.LoadScene(destination);
    }
}
