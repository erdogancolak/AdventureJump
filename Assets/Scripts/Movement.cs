using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Movement : MonoBehaviour
{
    [Header("References")]

    [SerializeField] private GameObject gameEndCanvas;
    [SerializeField] private Text lastScoreText, scoreText;
    Rigidbody2D rb;
    Animator animator;

    [Header("Values")]

    [SerializeField] private float speed;
    private float sideWalk;


    void Start()
    {
        Time.timeScale = 1.0f;
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    void Update()
    {
        playerMovement();

        gameFinishCheck();    
    }

    private void playerMovement()
    {
        sideWalk = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(sideWalk * speed, rb.velocity.y);
        animator.SetBool("isMoving", true);
        if (sideWalk == 0)
        {
            animator.SetBool("isMoving", false);
        }
        Vector2 newScale = transform.localScale;
        if (sideWalk < 0)
        {
            newScale.x = -3;
        }
        if (sideWalk > 0)
        {
            newScale.x = 3;
        }
        transform.localScale = newScale;
    }

    private void gameFinishCheck()
    {
        if (rb.velocity.y <= -12)
        {
            Time.timeScale = 0;
            gameEndCanvas.SetActive(true);
            lastScoreText.text = scoreText.text;
            scoreText.text = "";
        }
    }
}
