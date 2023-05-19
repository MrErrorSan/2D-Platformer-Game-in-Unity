using UnityEngine;
using UnityEngine.UI;

public class HealthManager : MonoBehaviour
{
    private Animator anim;
    private Rigidbody2D rb;
    public static HealthManager instance;
    public int health = 3;
    public Text healthText;
    public Vector3[] Respawn = {  new Vector3(1f, 1f, 1f), new Vector3(1f, 1f, 1f), new Vector3(1f, 1f, 1f), new Vector3(1f, 1f, 1f), new Vector3(1f, 1f, 1f) }; 
    public GameObject gameOverScreen;
    public GameObject gamePlayScreen;
    public GameObject Camra;
   // public GameObject firstStageCollecables;
    //public GameObject firstStageTraps;

    private void Awake()
    {
        instance = this;
        gameOverScreen.SetActive(false);
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        UpdateHealthText();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trap"))
        {
            DecreaseHealth();
        }
    }

    void UpdateHealthText()
    {
        healthText.text =  health.ToString();
    }
    public int getHealth()
    {
        return health;
    } 
    public void ResetHealth()
    {
        health = 3;
    }

    public void DecreaseHealth()
    {
        health--;
        UpdateHealthText();
        transform.position= Respawn[ScoreManager.instance.getStage()-1];
        if (health <= 0)
        {
            GameOver();
        }
    }
    //public void enableFirstStage()
    //{
    //    firstStageCollecables.SetActive(true);
    //    foreach (Transform child in firstStageCollecables.transform)
    //    {
    //        if (!child.gameObject.activeSelf)
    //            child.gameObject.SetActive(true);
    //    }
    //    firstStageTraps.SetActive(true);
    //    foreach (Transform child1 in firstStageTraps.transform)
    //    {
    //        if (!child1.gameObject.activeSelf)
    //            child1.gameObject.SetActive(true);
    //    }
    //}
    void GameOver()
    {
        transform.position = new Vector3(-11.11f,-38.8f,1f);
        Camra.transform.position = new Vector3(7.4f, -32f, -1f);
        rb.bodyType = RigidbodyType2D.Static;
        //enableFirstStage();
        gameOverScreen.SetActive(true);
    }
}