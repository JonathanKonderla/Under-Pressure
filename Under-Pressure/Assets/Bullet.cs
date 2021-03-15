using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float lifeSpan = 1.0f;

    //deleted start and update function because I just need a function for when the bullet collides with something
    // useful for damaging whatever the bullet hits because it can access components on the colliding object
    // but this just deletes the bullet for now when it collides
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag != "Player")
            Destroy(gameObject);
    }

    void Update()
    {
        lifeSpan -= Time.deltaTime;
        if(lifeSpan < 0)
        {
            Destroy(gameObject);
        }
    }

}