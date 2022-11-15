using UnityEngine;

public class TubeController : MonoBehaviour
{
    [SerializeField] private Transform[] tubes;
    [SerializeField, Range(0f,12f)] private float distance = 6f;
    [SerializeField] int tubeGap = 2;
    private int index;

    void Start()
    {
        Player.Point += teleportTube;

        index = -1 * tubeGap;
        foreach (Transform tube in tubes)
            randomHeight(tube);
    }

    private void teleportTube()
    {
        if (index >= 0)
        {
            tubes[index].position = new Vector3(tubes[index].position.x + tubes.Length * distance, tubes[index].position.y, 0f);
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
