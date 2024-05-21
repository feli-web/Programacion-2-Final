
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpellMenu : MonoBehaviour
{
    public Image spellmenu;
    public Button b1;
    public Button b2;
    public Button b3;
    public Button b4;
    void Start()
    {
        spellmenu.gameObject.SetActive(false);
        Selection1();
        Time.timeScale = 1.0f;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            spellmenu.gameObject.SetActive(true);
            Time.timeScale = 0f;
        }
        if (Input.GetMouseButtonUp(1))
        {
            spellmenu.gameObject.SetActive(false);
            Time.timeScale = 1f;
        }
    }
    public void Selection1()
    {
        b1.image.color = Color.red;
        b2.image.color = Color.white;
        b3.image.color = Color.white;
        b4.image.color = Color.white;
    }public void Selection2()
    {
        b2.image.color = Color.red;
        b1.image.color = Color.white;
        b3.image.color = Color.white;
        b4.image.color = Color.white;
    }public void Selection3()
    {
        b3.image.color = Color.red;
        b2.image.color = Color.white;
        b1.image.color = Color.white;
        b4.image.color = Color.white;
    }public void Selection4()
    {
        b4.image.color = Color.red;
        b2.image.color = Color.white;
        b3.image.color = Color.white;
        b1.image.color = Color.white;
    }
}
