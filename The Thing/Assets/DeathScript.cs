using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScript : MonoBehaviour
{

    private Animator animator;
    private Rigidbody2D playerBody;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        playerBody = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Deadly things"))
        {
            PlayerDies();
        }
    }

    private void PlayerDies()
    {
        animator.SetTrigger("Death");
        playerBody.bodyType = RigidbodyType2D.Static;
    }


    private void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
