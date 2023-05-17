using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrophyCollision : MonoBehaviour
{
    public Vector3 [] playerPositionChange;
    public float[] cameraPositionChange;
    public GameObject Player;
    public GameObject Camera;
    public int index = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
            MovePlayer();
            MoveCamera();
        ScoreManager.instance.IncreaseStage();
    }
    private void MovePlayer()
    {
        // Check if index is within bounds
        if (index >= 0 && index < playerPositionChange.Length)
        {
            Player.transform.position = playerPositionChange[index];
        }
    }

    private void MoveCamera()
    {
        // Check if index is within bounds
        if (index >= 0 && index < cameraPositionChange.Length)
        {
            float cameraXChange = cameraPositionChange[index];
            Vector3 cameraPosition = Camera.transform.position;
            cameraPosition.x = cameraXChange;
            Camera.transform.position = cameraPosition;
        }
    }
}