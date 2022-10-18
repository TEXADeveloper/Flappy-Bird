using UnityEngine;
using System;

public class Player : MonoBehaviour
{
    [SerializeField, Range(0f, 20f)] float force = 5f;
    Rigidbody rb;

    public static event Action Point;
    public static event Action Collision;

    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (GameManager.inGame && rb.velocity.y > 0.5f)
            this.transform.rotation = Quaternion.Euler(0f, 180f, -15f);
        else if (GameManager.inGame && rb.velocity.y < -0.5f)
            this.transform.rotation = Quaternion.Euler(0f, 180f, 15f);
        else if (GameManager.inGame)
            this.transform.rotation = Quaternion.Euler(0f, 180f, 0f);
    }

    public void Tap()
    {
        if (GameManager.inGame)
            rb.velocity = new Vector3(0, force, 0);
        else
            GameManager.ReloadScene();
    }

    private void OnCollisionEnter(Collision col)
    {
        if(col.transform.tag.Equals("Tube"))
        {
            Collision?.Invoke();
            rb.freezeRotation = false;
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if(col.tag.Equals("Tube"))
            Point?.Invoke();
    }
}
