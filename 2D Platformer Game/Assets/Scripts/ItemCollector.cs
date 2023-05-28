using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    [SerializeField] private AudioSource itemCollectSoundEffect;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("collect"))
        {
            //Destroy(collision.gameObject);
            itemCollectSoundEffect.Play();
            collision.gameObject.SetActive(false);
            ScoreManager.instance.IncreaseScore();
        }
    }
}
