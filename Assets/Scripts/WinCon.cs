using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinCon : MonoBehaviour
{
    public TimeKillsManager tkm;
    bool able;
    int trees = 0;
    void Start()
    {
        able = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (trees >= 5)
        {
            able = true;
        }
    }
    public void AddTrees()
    {
        trees++;
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (able == true)
            {
                SceneManager.LoadScene("Score");
                tkm.WonGame();
            }
        }
    }
}
