using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Slime : MonoBehaviour
{
    public float life;
    public float speed;
    public Animator animator;
    public SpriteRenderer sr;
    public Rigidbody2D rb;
    GameObject target;
    float range;

    TimeKillsManager tkm;

    public GameObject[] drop;

    void Start()
    {
        tkm = GameObject.FindGameObjectWithTag("TimeKills").GetComponent<TimeKillsManager>();

        target = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (rb.velocity.x != 0 || rb.velocity.y != 0)
        {
            animator.SetFloat("Speed", 1f);
        }
        if (rb.velocity.x == 0 && rb.velocity.y == 0)
        {
            animator.SetFloat("Speed", 0f);
        }

        if (rb.velocity.x < 0)
        {
            sr.flipX = true;

        }
        if (rb.velocity.x > 0)
        {
            sr.flipX = false;

        }

        range = Vector2.Distance(transform.position, target.transform.position);

        Vector2 direction = (target.transform.position - transform.position).normalized;
        rb.velocity = direction * speed * Time.deltaTime;

        if (range > 20f)
        {
            Destroy(gameObject);
        }
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Basic"))
        {
            sr.color = Color.green;
            StartCoroutine(Damage());
            life--;
        }
        if (collision.gameObject.CompareTag("Water"))
        {
            sr.color = Color.blue;
            StartCoroutine(Damage());
            life-=2;
        }
        if (collision.gameObject.CompareTag("Fireball"))
        {
            sr.color = Color.red;
            StartCoroutine(Damage());
            life-=2;
        }
        if (collision.gameObject.CompareTag("Lightning"))
        {
            sr.color = Color.yellow;
            StartCoroutine(Damage());
            life-=5;
        }
    }
    IEnumerator Damage()
    {
        if (life>0)
        {
            yield return new WaitForSeconds(0.1f);
            sr.color = Color.white;
        }
        
        if (life<= 0)
        {
            yield return new WaitForSeconds(0.1f);
            sr.color = Color.white;
            yield return new WaitForSeconds(0.1f);

            int r = Random.Range(0, 2);
            Instantiate(drop[r], this.transform.position, this.transform.rotation);

            tkm.Addkill();
            Destroy(gameObject);
        }
    }
}
