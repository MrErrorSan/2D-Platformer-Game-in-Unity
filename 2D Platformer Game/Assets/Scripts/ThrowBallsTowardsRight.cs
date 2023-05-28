using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ThrowBallsTowardsRight : MonoBehaviour
{
    public float speed = 4f;
    [SerializeField] private AudioSource plantDeathSoundEffect;

    private void Start()
    {
            Debug.Log("Ball throwed");
        Destroy(gameObject,1.3f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Trap"))
        {
            plantDeathSoundEffect.Play();
            Destroy(collision.gameObject);
            Destroy(gameObject);
            ScoreManager.instance.IncreaseScore();
            Debug.Log("Detecting the tag");
        }
        else if (!collision.gameObject.CompareTag("collect"))
        {
            Destroy(gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            plantDeathSoundEffect.Play();
            Destroy(collision.gameObject);
            Destroy(gameObject);
            ScoreManager.instance.IncreaseScore();
            Debug.Log("Detecting the tag");

        }
        else if (!collision.gameObject.CompareTag("collect"))
        {
            Destroy(gameObject);
        }
    }
    private void Update()
    {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
    }
}
