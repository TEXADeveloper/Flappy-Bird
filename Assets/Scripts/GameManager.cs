using UnityEngine;
using TMPro;
using System;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static bool inGame = true;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text finalScoreText;
    [SerializeField] private TMP_Text highScoreText;
    [SerializeField] private GameObject losePanel;
    [SerializeField] private GameObject newRecord;
    [SerializeField] private AudioSource scoreSfx;
    int score = 0;
    int highScore = 0;
    int birdSkin = 0;
    int tubeSkin = 0;

    public int GetHighScore()
    {
        return highScore;
    }
    public int GetBirdSkin()
    {
        return birdSkin;
    }

    public int GetTubeSkin()
    {
        return tubeSkin;
    }

    public void UpdateBirdSkin(int num)
    {
        birdSkin = num;
        SaveAndLoad.Save(this);
    }

    public void UpdateTubeSkin(int num)
    {
        tubeSkin = num;
        SaveAndLoad.Save(this);
    }

    void Awake()
    {
        GameData data = SaveAndLoad.Load();
        if (data != null)
        {
            highScore = data.highScore;
            birdSkin = data.birdSkin;
            tubeSkin = data.tubeSkin;
        }
    }

    void Start()
    {
        Player.Point += updateScore;
        Player.Collision += endGame;
    }

    private void updateScore()
    {
        score++;
        scoreText.text = score.ToString();
        scoreSfx.Play();
    }

    private void endGame()
    {
        inGame = false;
        losePanel.SetActive(true);
        if (highScore < score)
        {
            highScore = score;
            SaveAndLoad.Save(this);
            newRecord.SetActive(true);
        }
        finalScoreText.text = "Score: " + score.ToString();
        highScoreText.text = "HighScore: " + highScore.ToString();
    }

    public static void ReloadScene()
    {
        inGame = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    void OnDisable()
    {
        Player.Point -= updateScore;
        Player.Collision -= endGame;
    }
}
