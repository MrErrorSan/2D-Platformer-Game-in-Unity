using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ThrowBalls : MonoBehaviour
{
    public static ThrowBalls instance;
    public float speed = 5f;
    public bool moveLeft = false;
    public bool check=false;

    private void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        Destroy(gameObject,1.7f);
    }
    public void setDirection(int i)
    {
        if (!check && i==1)
        {
            moveLeft = true;
            check = true;
        }else if (i != 1 && !check)
        {
            moveLeft=false;
            check = true;
        }
    }


    private void Update()
    {
        // Move the ball horizontally
        if (moveLeft)
        {
            transform.Translate(Vector2.left * speed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector2.right * speed * Time.deltaTime);
        }
    }
}
