using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wanderer : MonoBehaviour
{
    public int life;
    public float speed;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator animator;
    public float shootrange;
    public float bulletspeed;
    bool chase;
    bool alive;
    public Transform spawnspell1;
    public Transform spawnspell2;
    public Transform spawnspell3;
    public Transform spawnspell4;
    public GameObject spell;
    GameObject target;
    private float range;

    float shootingTimer = 0f;
    float shootingInterval = 2f;

    TimeKillsManager tkm;

    public GameObject[] drop;

    void Start()
    {
        tkm = GameObject.FindGameObjectWithTag("TimeKills").GetComponent<TimeKillsManager>();

        alive = true;
        chase = true;
        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (alive == true)
        {
            if (rb.velocity.x != 0 || rb.velocity.y != 0)
            {
                animator.SetFloat("Speed", 1f);
            }
            if (rb.velocity.x == 0 && rb.velocity.y == 0)
            {
                animator.SetFloat("Speed", 0f);
            }
        }

        if (rb.velocity.x < 0)
        {
            sr.flipX = true;
       
        }
        if (rb.velocity.x > 0)
        {
            sr.flipX = false;
          
        }
        if (life <= 0)
        {
            StartCoroutine(Death());
        }

        range = Vector2.Distance(transform.position, target.transform.position);

        if (chase == true)
        {
            Vector2 direction = (target.transform.position - transform.position).normalized;
            rb.velocity = direction * speed * Time.deltaTime;
        }
        Debug.Log("The wanderer distance from the player is " + range);

        
        if (range <= shootrange)
        {
            chase = false;

            shootingTimer += Time.deltaTime;
            if (shootingTimer >= shootingInterval)
            {
                Shooting();
                shootingTimer = 0f;
            }
        }
        if (range > shootrange)
        {
            chase = true;
        }
        if (range > 20f)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fireball"))
        {
            chase = true;
            sr.color = Color.red;
            StartCoroutine(Damage());
            life-=5;
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            chase = true;
            sr.color = Color.blue;
            StartCoroutine(Damage());
            life-=2;
        }
        if (collision.gameObject.CompareTag("Lightning"))
        {
            chase = true;
            sr.color = Color.yellow;
            StartCoroutine(Damage());
            life-=2;
        }
        if (collision.gameObject.CompareTag("Basic"))
        {
            chase = true;
            sr.color = Color.green;
            StartCoroutine(Damage());
            life--;
        }
    }


    void ShootSpell(Vector3 spawnPosition, Vector3 direction)
    {
        var spellInstance = Instantiate(spell, spawnPosition, Quaternion.identity);
        spellInstance.GetComponent<Rigidbody2D>().velocity = direction * bulletspeed;
    }

    public void Shooting()
    {
        ShootSpell(spawnspell1.position, spawnspell1.up);
        ShootSpell(spawnspell2.position, -spawnspell2.up);
        ShootSpell(spawnspell3.position, spawnspell3.right);
        ShootSpell(spawnspell4.position, -spawnspell4.right);
    }


    IEnumerator Damage()
    {
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
    }
    IEnumerator Death()
    {
        yield return new WaitForSeconds(0.1f);
        chase = false;
        alive = false;
        animator.Play("Wanderer_Death");
        yield return new WaitForSeconds(1f);

        int r = Random.Range(0, 2);
        Instantiate(drop[r], this.transform.position, this.transform.rotation);

        tkm.Addkill();
        Destroy(gameObject);
    }
}
