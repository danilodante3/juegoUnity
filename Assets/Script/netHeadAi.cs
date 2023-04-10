using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class netHeadAi : MonoBehaviour
{
    public GameObject _ball;
    void Start()
    {
        _ball = GameObject.FindGameObjectWithTag("ball");
    }
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            _ball.GetComponent<Rigidbody2D>().velocity = new Vector2(30, 0);

            _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(30, 20));

        }
    }
}
