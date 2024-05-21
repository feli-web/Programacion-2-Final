using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public int life;
    public int maxlife;
    public Text lifetext;
    public SpriteRenderer sr;
    public PlayerMovement pm;
    public LoseCon lc;
    public Gun gun;
    public Collider2D col;
  

    int dmg;

    void Start()
    {
        
        lifetext.text = "Life: " + life;
    }

    
    void Update()
    {
        lifetext.text = "Hp: " + life;
        
        if (life <= 0)
        {
            lc.Lose();
            life = 0;
            col.enabled = false;
            pm.Dead();
            gun.Dead();
            Invoke("Transport", 2f);
        }

        
    }
  
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            life--;
            sr.color = Color.red;
            StartCoroutine(Damage());

        }
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Punch") || collision.gameObject.CompareTag("EnemyProjectile"))
        {
            life--;
            sr.color = Color.red;
            StartCoroutine(Damage());

        }
        if (collision.gameObject.CompareTag("Health"))
        {
            AddHealth();
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Mana"))
        {
            gun.AddMana();
            Destroy(collision.gameObject);
        }

        if (collision.gameObject.CompareTag("Slime"))
        {
            SlimeDamage();
            sr.color = Color.red;
            StartCoroutine(Damage());
            Destroy(collision.gameObject);
        }
    }
    public void AddHealth()
    {
        int r = Random.Range(0, 6);
        life += r;
    }
    public void SlimeDamage()
    {  
        dmg = Random.Range(1, (life / 2)+1);
        life -= dmg;
    }
    IEnumerator Damage()
    {
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
    }
    public void Transport()
    {
        SceneManager.LoadScene("Menu");
    }
}
