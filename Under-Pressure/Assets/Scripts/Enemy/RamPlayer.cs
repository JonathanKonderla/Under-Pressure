using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamPlayer : MonoBehaviour
{
    // Walk speed that can be set in Inspector
    [SerializeField]
    private float moveSpeed = 2f;
    [SerializeField]
    private float RamSpeed = 8f;
    [SerializeField]
    private float RamDistance = 15f;
    [SerializeField]
    private float RamWait = 1f;
    public enum RamState { READY, RAMMING, RAMMED };
    private RamState state = RamState.READY;
    
    private Vector2 targetPosition;
    private float distance;

    public Transform player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.position);
        Debug.Log(distance);

        if(distance > RamDistance && state == RamState.READY)
        {
            Move();
        }
        else
        {
            StartCoroutine(Ram());
        }
    }

    // Method to make Enemy walk
    private void Move()
    {
        Debug.Log("move");
        // Move Enemy from current postion to the player
        // using MoveTowards method
        transform.position = Vector2.MoveTowards(transform.position,
            player.position,
            moveSpeed * Time.deltaTime);
    }

    // Method to make Enemy ram the player
    IEnumerator Ram()
    {
        //get player position
        if(state == RamState.READY)
        {
            targetPosition = (float)1.5*(Vector2)player.position - (Vector2)transform.position;
            state = RamState.RAMMING;
        }
        else if(state == RamState.RAMMING)
        {
            //wait some
            yield return new WaitForSeconds(RamWait);

            // ram the old position
            // using MoveTowards method
            transform.position = Vector2.MoveTowards(transform.position,
                targetPosition,
                RamSpeed * Time.deltaTime);

            if((Vector2)transform.position == targetPosition)
            {
                state = RamState.RAMMED;
            }
        }
        else if(state == RamState.RAMMED)
        {
            yield return new WaitForSeconds(RamWait);
            state = RamState.READY;
        }
        
    }
}
