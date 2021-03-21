using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxLives = 3;
    // any other class can get this value, but can only set this value within this class
    public int currentLives { get; private set; }

    public Stat playerLives;
    
    public Stat fireRate;

    void Awake ()
    {
        currentLives = maxLives;
    }

    // made this update method to test if when the player "takes damage" (me pressing T) it succesfully decreases the player's lives by 1
    void Update ()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(1);
        }
    }

    public void TakeDamage (int damage)
    {
        //applies damage to a character
        currentLives -= damage;
        // prints what happens in the console
        Debug.Log(transform.name + " takes " + damage + " damage.");

        if (currentLives <= 0)
        {
            Die();
        }
    }

    public virtual void Die()
    {
        // whatever it is Dies in some way
        // this method is meant to be overwritten
        Debug.Log(transform.name + " died.");
    }

}
