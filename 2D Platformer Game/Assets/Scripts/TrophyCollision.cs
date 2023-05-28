using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrophyCollision : MonoBehaviour
{
    public float  nextPlayerPosition;
    public float  nextCameraPosition;
    public GameObject Player;
    public GameObject Camera;
    public GameObject gameCompleteScreen;
    public GameObject gameStartScreen;
    public GameObject gamePlayScreen;
    //public GameObject currentStageEnemies;
    public GameObject currentStageCollecables;
    //public GameObject nextStageEnemies;
    public GameObject nextStageCollecables;
    public GameObject firstStageCollecables;
    public int isLastStage = 0;
    Rigidbody2D rb;
    [SerializeField] private AudioSource stageSoundEffect;

    public void Start()
    {
        rb= Player.GetComponent<Rigidbody2D>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        stageSoundEffect.Play();
            disableCurrentStage();
            enableNextStage();
            Player.transform.position = new Vector3(nextPlayerPosition, -41.04f, 0);
            Camera.transform.position = new Vector3(nextCameraPosition, Camera.transform.position.y, Camera.transform.position.z);
            ScoreManager.instance.IncreaseStage();
        if (isLastStage == 1)
        {
            
            gamePlayScreen.SetActive(false);
            rb.bodyType = RigidbodyType2D.Static;
            gameCompleteScreen.SetActive(true);
        }
    }
 
        public void enableNextStage()
        {
            nextStageCollecables.SetActive(true);
            foreach (Transform child in nextStageCollecables.transform)
            {
                if (!child.gameObject.activeSelf)
                    child.gameObject.SetActive(true);
            }
            //nextStageEnemies.SetActive(true);
            //foreach (Transform child1 in nextStageEnemies.transform)
            //{
            //    if (!child1.gameObject.activeSelf)
            //        child1.gameObject.SetActive(true);
            //}
         }
        public void enableFirstStage()
        {
            firstStageCollecables.SetActive(true);
            foreach (Transform child in firstStageCollecables.transform)
            {
                if (!child.gameObject.activeSelf)
                    child.gameObject.SetActive(true);
            }
         }
        public void disableCurrentStage()
        {
            foreach (Transform child in currentStageCollecables.transform)
            {
                if (child.gameObject.activeSelf)
                    child.gameObject.SetActive(false);
            }
        nextStageCollecables.SetActive(false);
        //foreach (Transform child1 in currentStageEnemies.transform)
        //{
        //    if (child1.gameObject.activeSelf)
        //         child1.gameObject.SetActive(false);
        //}
        //nextStageEnemies.SetActive(true);
    }
    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        PlayerMovement.instance.Play();
        //ScoreManager.instance.ResetScore();
        //ScoreManager.instance.ResetStage();
        //HealthManager.instance.ResetHealth();
        //enableFirstStage();
        //HealthManager.instance.gameOverScreen.SetActive(false);
        //disableCurrentStage();
        //if (Player.GetComponent<SpriteRenderer>().flipX)
        //    Player.GetComponent<SpriteRenderer>().flipX = false;
        //gameCompleteScreen.SetActive(false);
        //gamePlayScreen.SetActive(true);
        //rb.bodyType = RigidbodyType2D.Dynamic;
    }
    public void Exit()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        //ScoreManager.instance.ResetScore();
        //ScoreManager.instance.ResetStage();
        //HealthManager.instance.ResetHealth();
        //enableFirstStage();
        //HealthManager.instance.gameOverScreen.SetActive(false);
        //if (Player.GetComponent<SpriteRenderer>().flipX)
        //    Player.GetComponent<SpriteRenderer>().flipX = false;
        //disableCurrentStage();
        //gameCompleteScreen.SetActive(false);
        //gameStartScreen.SetActive(true);
        //rb.bodyType = RigidbodyType2D.Static;
    }
}