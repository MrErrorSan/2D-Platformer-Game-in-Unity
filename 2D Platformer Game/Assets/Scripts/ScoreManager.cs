using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score = 0;
    public Text scoreText;
    public Text highScoreText;
    public Text scoreText_gameOver;
    public Text highScoreText_gameOver;
    public Text scoreText_gameComplete;
    public Text highScoreText_gameComplete;
    private int highScore;
    public Text stageText;
    public int stage = 1;
//    [SerializeField] private AudioSource stageSoundEffect;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreText();
        UpdateHighScoreText();
        UpdateStageText();
    }
    public int getStage()
    {
        return stage;
    }

    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();
        CheckHighScore();
    }
    public void IncreaseStage()
    {
        stage++;
        if(stage == 6)
        {
            stage = 1;
        }
        score += 100; 
        UpdateScoreText();
        UpdateStageText();
    }
    public void ResetStage()
    {
        stage = 1;
        UpdateStageText();
    }

    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
        scoreText_gameOver.text = score.ToString();
        scoreText_gameComplete.text = score.ToString();
        //Debug.Log("Score : "+score);
    }
    void UpdateStageText()
    {
        stageText.text =stage.ToString();
    }

    public void UpdateHighScoreText()
    {
        highScoreText.text = highScore.ToString();
        highScoreText_gameOver.text = highScore.ToString();
        highScoreText_gameComplete.text = highScore.ToString();
    }

    public void CheckHighScore()
    {
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetInt("HighScore", highScore);
            UpdateHighScoreText();
        }
    }
    public void ResetScore()
    {
        score = 0;
        UpdateScoreText();
    }
}