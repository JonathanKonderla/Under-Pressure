using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{    
    public float lifeSpan = 1.0f;

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Player")
        {
            Destroy(gameObject);
            //LifeSystem.TakeDamage(1); (new line of code im trying to make work)
            GameController.DamagePlayer(1); //(old line of code used)
        }
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
