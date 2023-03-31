using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moviminetoAi : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] float speed = 5f;
    [SerializeField] float followRange = 3f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        
        GameObject balon = GameObject.FindGameObjectWithTag("ball");

        if (balon != null && Vector2.Distance(transform.position, balon.transform.position) <= followRange)
        { // si el jugador está dentro del rango
            Vector2 movement = new Vector2(balon.transform.position.x - transform.position.x, rb.velocity.y);
            movement.Normalize();
            movement *= speed;
            rb.velocity = movement;
        }
        else if (balon != null && Vector2.Distance(transform.position, balon.transform.position) > followRange) {
            Vector2 movement = new Vector2(balon.transform.position.y - transform.position.y, rb.velocity.x);
            movement.Normalize();
            movement *= speed;
            rb.velocity = movement;
        }
    }

}
