using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gun : MonoBehaviour
{
    public GameObject[] spell;
    GameObject spawnpoint;
    public float bulletspeed;
    public SpriteRenderer sr;
    public Sprite[] wands;

    bool alive = true;

    int spelltype = 0;

    float shootingTimer = 0f;
    public float shootingInterval = 2f;

    public int mana;
    int manacost;
    public Text manatext;

    void Start()
    {
        manacost = 0;
        spawnpoint = GameObject.FindGameObjectWithTag("Spawnpoint");
        alive = true;
    }

    
    void Update()
    {
        manatext.text = "Mp: " + mana;
        shootingTimer += Time.deltaTime;
        if (Input.GetMouseButtonDown(0) && mana >= manacost && Time.timeScale == 1)
        {
            
            if (shootingTimer >= shootingInterval)
            {
                Shoot();
                shootingTimer = 0f;
                mana -= manacost;
            }
        }
    }
    void Shoot()
    {
        if (alive == true)
        {
            var b = Instantiate(spell[spelltype], spawnpoint.transform.position, spawnpoint.transform.rotation);
            b.GetComponent<Rigidbody2D>().velocity = spawnpoint.transform.right * bulletspeed;
        }
    }
    public void Dead()
    {
        sr.enabled = false;
        alive = false;
    }

    public void AddMana()
    {
        int r = Random.Range(1, 6);
        mana += r;
    }

    public void SpellSelect(int selectspell)
    {
        spelltype = selectspell;
        sr.sprite = wands[selectspell];
        
    }
    public void Cost(int cost)
    {
        manacost = cost;
    }
}
