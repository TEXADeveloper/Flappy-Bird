using UnityEngine;

public class InfiniteScroll : MonoBehaviour
{
    [SerializeField, Range(0f, 20f)] private float speed;
    private float width;
    private Vector3 startPos;

    void Start()
    {
        Player.Point += speedUp;

        width = this.GetComponent<BoxCollider>().size.x;
        startPos = this.transform.position;
    }

    void Update()
    {
        if (transform.position.x < startPos.x - width)
        {
            transform.Translate(new Vector3(2*width, 0f, 0f));
        }
        if (GameManager.inGame)
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0f, 0f));
    }

    private void speedUp()
    {
        speed += 0.02f;
    }

    void OnDisable()
    {
        Player.Point -= speedUp;
    }
}
