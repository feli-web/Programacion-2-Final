using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : MonoBehaviour
{
    public int life;
    public Rigidbody2D rb;
    public Animator animator;
    public SpriteRenderer sr;
    public Collider2D col;
    public Collider2D[] punchcol = new Collider2D[2];
    int punchcolnumber;

    bool chase;
    bool alive;
    public GameObject target;
    private float range;
    public float speed;

    TimeKillsManager tkm;

    public GameObject[] drop;

    void Start()
    {
        tkm = GameObject.FindGameObjectWithTag("TimeKills").GetComponent<TimeKillsManager>();
        punchcol[punchcolnumber].enabled = false;
        target = GameObject.FindGameObjectWithTag("Player");
        chase = true;
        alive = true;
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
       
        if(rb.velocity.x < 0)
        {
            sr.flipX = true;
            punchcolnumber = 0;
        }
        if(rb.velocity.x > 0)
        {
            sr.flipX = false;
            punchcolnumber = 1;
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
        Debug.Log("The golem distance from the player is " + range);

        if (range <= 2f)
        {
            chase = false;
            StartCoroutine(Punch());
        }
        if (range > 20f)
        {
            Destroy(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Basic"))
        {
            chase = true;
            sr.color = Color.green;
            StartCoroutine(Damage());
            life--;
        }
        if (collision.gameObject.CompareTag("Fireball"))
        {
            chase = true;
            sr.color = Color.red;
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
        if (collision.gameObject.CompareTag("Water"))
        {
            chase = true;
            sr.color = Color.blue;
            StartCoroutine(Damage());
            life-=5;
        }
    }
    IEnumerator Damage()
    {
        yield return new WaitForSeconds(0.1f);
        sr.color = Color.white;
    }

    IEnumerator Punch()
    {
        alive = false;
        animator.Play("Golem_Attack");
        punchcol[punchcolnumber].enabled = true;
        yield return new WaitForSeconds(0.01f);
        punchcol[punchcolnumber].enabled = false;
        alive = true;
    }

    IEnumerator Death()
    {
        col.enabled = false;    
        yield return new WaitForSeconds(0.1f);
        chase = false;
        alive = false;
        animator.Play("Golem_Death");
        yield return new WaitForSeconds(1f);

        int r = Random.Range(0, 2);
        Instantiate(drop[r], this.transform.position,this.transform.rotation);

        tkm.Addkill();
        Destroy(gameObject);
    }
}
