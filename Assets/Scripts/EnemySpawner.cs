using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemySpawner : MonoBehaviour
{
    public SpriteRenderer sr;
    public GameObject[] monsters;
    int random;
    int life = 10;

    float range; 
    GameObject target;

    public WinCon wc;

    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
        InvokeRepeating("Summon", 0, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            Destroy(gameObject);
            wc.AddTrees();
        }

       
    }
    
    public void Summon()
    {
        random = Random.Range(0, monsters.Length);
        Instantiate(monsters[random], this.transform.position, this.transform.rotation);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fireball") || collision.gameObject.CompareTag("Water") || collision.gameObject.CompareTag("Lightning") || collision.gameObject.CompareTag("Basic"))
        {
            if (range < 10f)
            {
                life--;
                StartCoroutine(Damage());
            }
        }
    }
    IEnumerator Damage()
    {
        sr.color = Color.black;
        yield return new WaitForSeconds(0.3f);
        sr.color = Color.white;
    }
}
