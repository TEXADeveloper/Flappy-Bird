using UnityEngine;

[System.Serializable] public class GameData
{
    public int highScore;

    public GameData(GameManager gM)
    {
        highScore = gM.GetHighScore();
    }
}
