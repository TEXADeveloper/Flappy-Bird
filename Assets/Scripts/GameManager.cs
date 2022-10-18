using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [HideInInspector] public static bool inGame = true;
    [SerializeField] private TMP_Text text;
    [SerializeField] private TMP_Text finalText;
    [SerializeField] private GameObject losePanel;
    int score = 0;

    void Start()
    {
        Player.Point += updateScore;
        Player.Collision += endGame;
    }

    private void updateScore()
    {
        score++;
        text.text = score.ToString();
    }

    private void endGame()
    {
        inGame = false;
        losePanel.SetActive(true);
        finalText.text = "Score: " + score.ToString();
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
