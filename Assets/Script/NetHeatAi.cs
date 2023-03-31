using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NetHeatAi : MonoBehaviour
{
    public GameObject _ball;
    void Start()
    {
        GameObject[] _ball = GameObject.FindGameObjectsWithTag("ball");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "ball")
        {
            _ball.GetComponent<Rigidbody>().velocity = new Vector3(0,0);
            _ball.GetComponent<Rigidbody>().AddForce(new Vector2(300,400));

        };
    }
}
