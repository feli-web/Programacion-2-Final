using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Buttons : MonoBehaviour
{
    public Transform rotate;
    public float rotatespeed;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        rotate.transform.Rotate(0, 0, rotatespeed* Time.deltaTime);
    }

    public void Button(string destination)
    {
        SceneManager.LoadScene(destination);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
