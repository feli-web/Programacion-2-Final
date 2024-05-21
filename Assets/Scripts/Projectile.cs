using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float dietime;
    void Start()
    {
        Invoke("Die",dietime);
    }

    
    public void Die()
    {
        Destroy(gameObject);
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject)
        {
            Destroy(gameObject);
        }
    }
}
