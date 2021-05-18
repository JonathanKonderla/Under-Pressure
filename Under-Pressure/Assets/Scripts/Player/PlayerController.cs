using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // 
    public float speed;
    // initialized "rigidbody"
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        // assigning "rigidbody" to Rigidbody2D component that I assigned to the player asset in unity by using GetComponent<>()
        rb = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    // Update method
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        // find the velocity in rigidbody assigned earlier and set it to Vector3 that takes in x,y, and z variables
        rb.velocity = new Vector3(horizontal * speed, vertical * speed, 0);
    }
}
