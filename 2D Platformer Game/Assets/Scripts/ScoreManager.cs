using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;
    public int score = 0;
    public Text scoreText;
    public Text highScoreText;
    private int highScore;
    public Text stageText;
    private int stage = 1;

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

    public void IncreaseScore()
    {
        score++;
        UpdateScoreText();
        CheckHighScore();
    }
    public void IncreaseStage()
    {
        stage++;
        UpdateStageText();
    }
    public void ResetStage()
    {
        stage = 0;
        UpdateStageText();
    }

    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
        //Debug.Log("Score : "+score);
    }
    void UpdateStageText()
    {
        stageText.text =stage.ToString();
    }

    public void UpdateHighScoreText()
    {
        highScoreText.text = highScore.ToString();
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