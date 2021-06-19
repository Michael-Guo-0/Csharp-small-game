using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    public float speed;
    public Rigidbody2D rb;
    public Vector3 startPosition;

    private float x;
    private float y;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        rb = GetComponent<Rigidbody2D>();
        Lanuch();
    }

    private void Lanuch()
    {
        if(Random.Range(0,2) == 0)
        {
            x = -1;
        }
        else
        {
            x = 1;
        }
        if (Random.Range(0, 2) == 0)
        {
            y = -1;
        }
        else
        {
            y = 1;
        }

        rb.velocity = new Vector2(speed * x, speed * y);
    }

    public void Reset()
    {
        rb.velocity = Vector2.zero;
        transform.position = startPosition;
        Lanuch();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player") && other.GetComponent<PlayerController>().GetInvicible() == false)
        {
            other.GetComponent<PlayerController>().Get_Hit(10);
            other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        }
        other.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
