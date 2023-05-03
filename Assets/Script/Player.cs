using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Photon.Realtime;

public class Player : MonoBehaviour
{

    public float horialAxis, speed;
    public Rigidbody2D rb_player;
    public bool canShoot, grounded, canHead;
    private GameObject _ball, _player2;
    public Transform checkGround;
    [SerializeField] public LayerMask ground_Layer;
    public int hashShoot, hashMove;

    void Start()
    {
        rb_player = GetComponent<Rigidbody2D>();
        _ball = GameObject.FindGameObjectWithTag("ball");
        _player2 = GameObject.FindGameObjectWithTag("Player");

    }

    void Update()
    {

    }

    private void FixedUpdate()
    {
        rb_player.velocity = new Vector2(Time.deltaTime * speed * horialAxis, rb_player.velocity.y);
        grounded = Physics2D.OverlapCircle(checkGround.position, 0.2f, ground_Layer);
    }

    public void Move(int value)
    {
        if (GamerControler.instance.isScore == false && GamerControler.instance.EndMatch == false)
        {
            GameObject player2 = GameObject.Find("Player2");
            player2.GetComponent<Player>().horialAxis = value;

        }

    }


    public void StopMove(int value)
    {
        GameObject player2 = GameObject.Find("Player2");
        player2.GetComponent<Player>().Move(0);

    }

    
    public void Move1(int value)
    {

        if (GamerControler.instance.isScore == false && GamerControler.instance.EndMatch == false)
        {
            horialAxis = value;
        }
    }
    public void StopMove1(int value)
    {
        horialAxis = 0;



    }

    public void Shoot()
    {
        if (canShoot == true)
        {
            _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400, 500));
        }
    }

    public void Shoot1()
    {
        if (canShoot)
        {
            GameObject player2 = GameObject.Find("Player2");
            if (player2 != null)
            {
                Vector3 player2Position = player2.transform.position;
                Vector2 forceDirection = new Vector2(player2Position.x - _ball.transform.position.x, player2Position.y - _ball.transform.position.y);
                _ball.GetComponent<Rigidbody2D>().AddForce(forceDirection.normalized * 500f);
            }
            else
            {
                _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400, 500));
            }
        }
    }


    public void StopShoot()
    {

    }

    public void Jump()
    {
        if (grounded == true)
        {
            canHead = true;
            rb_player.velocity = new Vector2(rb_player.velocity.x, 15);

            GameObject player2 = GameObject.Find("Player2");
            if (player2 != null)
            {
                Player player2Script = player2.GetComponent<Player>();
                if (player2Script != null && player2Script != this)
                {
                    player2Script.Jump();
                }
            }
        }
    }
    public void StopJump()
    {

    }
}
