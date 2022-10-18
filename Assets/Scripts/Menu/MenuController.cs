using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private TMP_Text highScoreText; 
    int highScore = 0;

    void Awake()
    {
        GameData data = SaveAndLoad.Load();
        if (data != null)
            highScore = data.highScore;
        highScoreText.text = "HighScore: " + highScore.ToString();
    }

    public void Play()
    {
        SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
