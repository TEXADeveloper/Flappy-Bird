using UnityEngine;

[System.Serializable] public class GameData
{
    public int highScore;
    public int birdSkin;
    public int tubeSkin;

    public GameData(GameManager gM)
    {
        highScore = gM.GetHighScore();
        birdSkin = gM.GetBirdSkin();
        tubeSkin = gM.GetTubeSkin();
    }
}
