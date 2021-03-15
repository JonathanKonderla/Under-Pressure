using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//shooting is for player shooting
public class Shooting : MonoBehaviour
{
    //deleted start method again

    // references our Player firePoint object
    public Transform firePoint;
    // references our bullet object that was turned into a prefab
    public GameObject bulletPrefab;

    // for force of bullet with a default value of 20
    public float bulletForce = 20f;

    // for held down firing
    public float fireRate = 0.5f;
    private float lastFire = 0.0f;

    // Update is called once per frame
    void Update()
    {
        lastFire += Time.deltaTime;

        // Fire1 is a default input binding in Unity and is linked to Left Mouse click
        if(Input.GetButton("Fire1") && lastFire > fireRate)
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
