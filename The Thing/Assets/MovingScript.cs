using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingScript : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;
    private SpriteRenderer sprite;
    [SerializeField] private bool flipingAction = false;

    [SerializeField] private float speed = 2f;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if(Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {
            currentWaypointIndex++;

            if (flipingAction)
            {
                sprite.flipX = true; //flip player in case of direction change
            }

            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
                if(flipingAction)
                {
                    sprite.flipX = false; //flip player in case of direction change
                }    
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
    }
}
