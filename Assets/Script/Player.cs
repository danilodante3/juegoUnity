using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    public float horialAxis, speed;
    public Rigidbody2D rb_player;
    public bool canShoot, grounded, canHead;
    private GameObject _ball;
    public Transform checkGround;
    [SerializeField] public LayerMask ground_Layer;
    public GameObject btnShoot, btnMoveLeft, btnMoveRight, btnJump;
    public int hashShoot, hashMove;
    public Animator _aniPlayer;
    void Start()
    {
        rb_player = GetComponent<Rigidbody2D>();
        _ball = GameObject.FindGameObjectWithTag("ball");
        hashShoot = Animator.StringToHash("Shoot");
        hashShoot = Animator.StringToHash("Move");

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
        _aniPlayer.SetBool("Move", true);
        if (GamerControler.instance.isScore == false && GamerControler.instance.EndMatch == false)
        {
            horialAxis = value;
        }
    }
    public void StopMove(int value)
    {
        _aniPlayer.SetBool("Move", false);
        horialAxis = 0;
        


    }
    public void Shoot()
    {
        _aniPlayer.SetTrigger("Shoot");
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