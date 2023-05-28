using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balltoleft : MonoBehaviour
{
    public float speed = 4f;
    [SerializeField] private AudioSource plantDeathSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 1.3f);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            plantDeathSoundEffect.Play();
            Destroy(collision.gameObject);
            Destroy(gameObject);
            ScoreManager.instance.IncreaseScore();
        }
        else if(!collision.gameObject.CompareTag("collect"))
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
        }
        else if (!collision.gameObject.CompareTag("collect"))
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
