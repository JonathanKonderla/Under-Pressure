using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    //instance of class that initilizes stats once
    public static GameController instance;

    private static int lives = 5;

    private static int maxLives = 5;

    private static float moveSpeed = 5f;

    private static float fireRate = 0.5f;

    public static int Lives { get => lives; set => lives = value; }

    public static int MaxLives { get => maxLives; set => maxLives = value; }

    public static float MoveSpeed { get => moveSpeed; set => moveSpeed = value; }

    public static float FireRate { get => fireRate; set => fireRate = value; }

    //used for Lives UI
    public Text livesText;
    
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //edits the "Lives:" text in the UI
        livesText.text = "Lives: " + lives;

        // using this to test if lives are affected when damage is taken, can delete when we're done
        if (Input.GetKeyDown(KeyCode.T))
        {
            DamagePlayer(1);
        }
        // using this to test if lives are healed when a player heals, can delete when we're done
        if (Input.GetKeyDown(KeyCode.H))
        {
            HealPlayer(1);
        }
    }

    public static void DamagePlayer(int damage)
    {
        lives -= damage;

        if (lives <= 0)
        {
            Die();
        }
    }

    public static void HealPlayer(int healAmount)
    {
        lives = Mathf.Min(maxLives, lives + healAmount);
    }

    private static void Die()
    {
        // fill in here what happens when the player dies
    }

}
