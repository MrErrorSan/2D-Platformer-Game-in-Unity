using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantRight : MonoBehaviour
{
    public GameObject itemToShoot;
    public float startDelay = 2f;
    public float spawnInterval = 0.8f;
    [SerializeField] private AudioSource plantShootSoundEffect;


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", startDelay, spawnInterval);

    }
    void Spawn()
    {
        plantShootSoundEffect.Play();
        Instantiate(itemToShoot, (transform.position - new Vector3(-1.38f, -0.2000008f, 0)), itemToShoot.transform.rotation);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            HealthManager.instance.DecreaseHealth();
        }
        else if (collision.gameObject.CompareTag("Ball"))
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
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            HealthManager.instance.DecreaseHealth();
        }
        else if (collision.gameObject.CompareTag("Ball"))
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
}
