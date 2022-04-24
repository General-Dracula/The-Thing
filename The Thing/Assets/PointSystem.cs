using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PointSystem : MonoBehaviour
{

    private int points = 0;

    [SerializeField] private Text pointsTextField;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Points"))
        {
            Destroy(collision.gameObject);
            points++;
            pointsTextField.text = "Points: " + points;
            Debug.Log("New points gathered. Points: " + points);
        }
    }
}
