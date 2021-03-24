using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public Transform player;
    public Transform firePoint;
    public GameObject bulletPrefab;

    public float bulletForce = 20f;

    //AI firerate
    public float fireRate = 1f;
    private float lastFire = 0.0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        lastFire += Time.deltaTime;

        // Determine which direction to rotate towards
        Vector3 targetDirection = player.position - transform.position;

        Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, bulletForce, 0.0f);

        // Draw a ray pointing at our target in
        Debug.DrawRay(transform.position, newDirection, Color.red);
        
        float angle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        Quaternion q = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.RotateTowards(transform.rotation, q, bulletForce);

        // Fire1 is a default input binding in Unity and is linked to Left Mouse click
        if(lastFire > fireRate)
        {
            Shoot();
            lastFire = 0.0f;
        }
    }

    // this function will create bullet at firepoint then apply force to bullet
    void Shoot()
    {
        // this function creates the bullet with parameters (prefab, position, rotation)
        // and name it "bullet" by assigning it to bullet
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        // accesses the rigidbody2D component of the bullet
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();
        // then uses it to access AddForce function, "Impulse" is so it adds a force instantly
        rigidbody.AddForce(firePoint.up * bulletForce, ForceMode2D.Impulse);
    }
}
