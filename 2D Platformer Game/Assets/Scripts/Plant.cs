using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Plant : MonoBehaviour
{
    public GameObject itemToShoot;
    public float startDelay =0;
    public float spawnInterval =0;
    [SerializeField] private AudioSource plantShootSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", startDelay, spawnInterval);
    }
    void Spawn()
    {
        plantShootSoundEffect.Play();
        Instantiate(itemToShoot, (transform.position - new Vector3(1.450037f, -0.2000008f, 0)), itemToShoot.transform.rotation);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Destroy(gameObject);
            HealthManager.instance.DecreaseHealth();
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
        else
        {
            Destroy(gameObject);
        }
    }
}
