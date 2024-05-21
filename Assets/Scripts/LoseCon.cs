using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCon : MonoBehaviour
{
    public GameObject canvas;
    public GameObject losecanvas;
    void Start()
    {
        losecanvas.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Lose()
    {
        losecanvas.gameObject.SetActive(true);
        canvas.gameObject.SetActive(false);
    }
}
