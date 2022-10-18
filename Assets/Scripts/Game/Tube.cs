using UnityEngine;

public class Tube : MonoBehaviour
{
    [SerializeField, Range(0f,10f)] private float speed = 15f;

    private bool collisioned = false;

    void Start()
    {  
        Player.Collision += collision;
        Player.Point += speedUp;
    }

    void Update()
    {
        if (!collisioned)
            this.transform.Translate(new Vector3(speed * Time.deltaTime * -1, 0f, 0f));
    }

    private void collision()
    {
        collisioned = true;
    }

    private void speedUp()
    {
        speed += 0.02f;
    }

    void OnDisable()
    {
        Player.Collision -= collision;
        Player.Point -= speedUp;
    }
}
