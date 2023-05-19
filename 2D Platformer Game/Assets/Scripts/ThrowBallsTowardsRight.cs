using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ThrowBallsTowardsRight : MonoBehaviour
{
    public float speed = 4f;

    private void Start()
    {
        Destroy(gameObject,1.3f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            ScoreManager.instance.IncreaseScore();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
            ScoreManager.instance.IncreaseScore();
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
