using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantScript : MonoBehaviour
{
    public GameObject fireballPrefab;
    //private Animator animator;
    //private void Start()
    //{
    //    animator = GetComponent<Animator>();
    //}
    //public void PlayFireAnimation()
    //{
    //    // Play the fire animation
    //    animator.SetTrigger("Fire");
    //}

    // Method to be called from an animation event
    public void Fire()
    {
        // Instantiate a fireball at a slight offset from the plant
       // Vector3 SpawnVector = transform.position+ new Vector3(-8.21f,-30.05f,0);
        Vector3 SpawnVector = new Vector3(transform.position.x-8.21f, -40.18956f, transform.position.y);
        Vector3 spawnPosition = SpawnVector + transform.up;
        Instantiate(fireballPrefab, spawnPosition, Quaternion.identity);
    }
}

