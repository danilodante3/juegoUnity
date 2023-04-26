using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;

public class Player : MonoBehaviour
{

    public float horialAxis, speed;
    public Rigidbody2D rb_player;
    public bool canShoot, grounded, canHead;
    private GameObject _ball;
    public Transform checkGround;
    [SerializeField] public LayerMask ground_Layer;
    public int hashShoot, hashMove;
    void Start()
    {
        rb_player = GetComponent<Rigidbody2D>();
        _ball = GameObject.FindGameObjectWithTag("ball");
       

    }

    public class PlayerMove : NetworkBehaviour
    {
       
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
            horialAxis = value;
        }
    }
    public void StopMove(int value)
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
    public void StopShoot()
    {
        
    }
    

    public void Jump()
    {


        if (grounded == true && GamerControler.instance.isScore == false && GamerControler.instance.EndMatch == false)
        {
            canHead = true;
            rb_player.velocity = new Vector2(rb_player.velocity.x, 15);
           

        }
    }
    public void StopJump()
    {
       

    }
}