using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PointSystem : MonoBehaviour
{

    private static int points = 0;
    private int level = 1;
    private int lastLevelPoints = 0;

    [SerializeField] private Text pointsTextField;

    [SerializeField] private AudioSource collectSound;

    private void Update()
    {
        level = SceneManager.GetActiveScene().buildIndex;
        if (level != 1)
        {
            pointsTextField.text = "Points: " + points + "\n Level: " + level;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Points"))
        {
            collectSound.Play();
            Destroy(collision.gameObject);
            points++;
            pointsTextField.text = "Points: " + points + "\n Level: " + level;
            Debug.Log("New points gathered. Points: " + points + "\n Level: " + level);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Deadly things"))
        {
            points = lastLevelPoints;
        }

        if (collision.gameObject.CompareTag("FinishLine"))
        {
            lastLevelPoints = points;
        }
    }

}
