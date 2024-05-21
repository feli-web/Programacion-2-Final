
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{

    public float speed;
    private float x;
    private float y;
    public Rigidbody2D rb;
    public SpriteRenderer sr;
    public Animator animator;
    bool alive = true;
    void Start()
    {
        alive = true;
    }


    void Update()
    {
        if (alive == true)
        {
            {

            }
            x = Input.GetAxis("Horizontal");
            y = Input.GetAxis("Vertical");

            if (rb.velocity.x < 0)
            {
                sr.flipX = true;
            }
            if (rb.velocity.x > 0)
            {
                sr.flipX = false;
            }
            if (rb.velocity.x != 0 || rb.velocity.y != 0)
            {
                animator.SetFloat("Speed", 0.02f);
            }
            if (rb.velocity.x == 0 && rb.velocity.y == 0)
            {
                animator.SetFloat("Speed", 0f);
            }

            rb.velocity = new Vector2(x * speed * Time.deltaTime, y * speed * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.Escape)) 
            {
                SceneManager.LoadScene("Menu");
            }
        }
    }

    public void Dead()
    {
        alive = false;
        rb.velocity = new Vector2( 0,0); 
        animator.Play("Player_Dead");
    }
}
