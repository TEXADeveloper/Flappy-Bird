using UnityEngine;

public class TubeController : MonoBehaviour
{
    [SerializeField] private Transform[] tubes;
    [Range(0f,12f)] private float distance = 6f;
    private int index = -1;

    void Start()
    {
        Player.Point += teleportTube;

        foreach (Transform tube in tubes)
            randomHeight(tube);
    }

    private void teleportTube()
    {
        if (index >= 0)
        {
            tubes[index].position = new Vector3(tubes[index].position.x + 4 * distance, tubes[index].position.y, 0f);
            randomHeight(tubes[index]);
        }
        index = (index < tubes.Length - 1) ? index + 1 : 0;
    }

    private void randomHeight(Transform tube)
    {
        tube.position = new Vector3(tube.position.x, Random.Range(-1.5f, 1.5f), 0f);
    }

    private void OnDisable()
    {
        Player.Point -= teleportTube;
    }
}
