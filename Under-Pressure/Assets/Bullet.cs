using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    //deleted start and update function because I just need a function for when the bullet collides with something
    // useful for damaging whatever the bullet hits because it can access components on the colliding object
    // but this just deletes the bullet for now when it collides
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

}