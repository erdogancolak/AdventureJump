using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platforms : MonoBehaviour
{
    [Header("Values")]

    [SerializeField] private float jumpPower;
    public static int score;
    public int scoreCount;
    private bool isPoint = false;
    void Start()
    {
        Destroy(gameObject,120f);
    }


    void Update()
    {
        
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        Rigidbody2D rb = collision.collider.GetComponent<Rigidbody2D>();
        if (rb != null && rb.velocity.y <= 0 )
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            if (isPoint == false)
            {
                score = score + scoreCount;
                isPoint = true;
            }
            Destroy(gameObject, 3);
        }         
    }
}
