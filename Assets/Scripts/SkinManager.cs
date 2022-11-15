using UnityEngine;

public class SkinManager : MonoBehaviour
{
    [SerializeField] private GameObject[] birdObjects;
    [SerializeField] private GameObject[] tubeObjects;
    [SerializeField] private GameManager gM;
    [HideInInspector] public int birdSkin = 0;
    [HideInInspector] public int tubeSkin = 0;

    void Awake()
    {
        GameData data = SaveAndLoad.Load();
        if (data != null)
        {
            birdSkin = data.birdSkin;
            tubeSkin = data.tubeSkin;
        }
        if (birdObjects.Length != 0)
            birdObjects[birdSkin]?.SetActive(true);
        if (tubeObjects.Length != 0)
            tubeObjects[tubeSkin]?.SetActive(true);
    }

    public void ChangeBirdSkin(int direction)
    {
        birdObjects[birdSkin]?.SetActive(false);
        if (birdSkin + direction < 0)
            birdSkin = birdObjects.Length - 1;
        else if (birdSkin + direction >= birdObjects.Length)
            birdSkin = 0;
        else
            birdSkin += direction;
        birdObjects[birdSkin]?.SetActive(true);
        gM.UpdateBirdSkin(birdSkin);
    }

    public void ChangeTubeSkin(int direction)
    {
        tubeObjects[tubeSkin]?.SetActive(false);
        if (tubeSkin + direction < 0)
            tubeSkin = tubeObjects.Length - 1;
        else if (tubeSkin + direction >= tubeObjects.Length)
            tubeSkin = 0;
        else
            tubeSkin += direction;
        tubeObjects[tubeSkin]?.SetActive(true);
        gM.UpdateTubeSkin(tubeSkin);
    }
}
