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
        if (value == 1)
        {
            btnMoveRight.transform.localScale = new Vector3(1f, 1f, 1);
            btnMoveRight.GetComponent<Image>().CrossFadeAlpha(1f, 0.1f, true);

        }
        if (value == 1)
        {
            btnMoveLeft.transform.localScale = new Vector3(1f, 1f, 1);
            btnMoveLeft.GetComponent<Image>().CrossFadeAlpha(1f, 0.1f, true);

        }
        if (GamerControler.instance.isScore == false && GamerControler.instance.EndMatch == false)
        {
            horialAxis = value;
        }
    }
    public void StopMove(int value)
    {
        _aniPlayer.SetBool("Move", false);
        horialAxis = 0;

        if (value == 1)
        {
            btnMoveRight.transform.localScale = new Vector3(1f, 1f, 1);
            btnMoveRight.GetComponent<Image>().CrossFadeAlpha(1f, 0.1f, true);

        }
        if (value == 1)
        {
            btnMoveLeft.transform.localScale = new Vector3(1f, 1f, 1);
            btnMoveLeft.GetComponent<Image>().CrossFadeAlpha(1f, 0.1f, true);

        }


    }
    public void Shoot()
    {
        _aniPlayer.SetTrigger("Shoot");
        btnShoot.transform.localScale = new Vector3(1.2f, 1.2f, 1);
        btnShoot.GetComponent<Image>().CrossFadeAlpha(0.4f, 0.1f, true);
        if (canShoot == true)
        {
            _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400, 500));
        }
    }
    public void StopShoot()
    {
        btnShoot.transform.localScale = new Vector3(1f, 1f, 1);
        btnShoot.GetComponent<Image>().CrossFadeAlpha(1f, 0.1f, true);
    }
    

    public void Jump()
    {


        if (grounded == true && GamerControler.instance.isScore == false && GamerControler.instance.EndMatch == false)
        {
            canHead = true;
            rb_player.velocity = new Vector2(rb_player.velocity.x, 15);
            btnJump.transform.localScale = new Vector3(1f, 1f, 1);
            btnJump.GetComponent<Image>().CrossFadeAlpha(1f, 0.1f, true);

        }
    }
    public void StopJump()
    {
        btnJump.transform.localScale = new Vector3(1f, 1f, 1);
        btnJump.GetComponent<Image>().CrossFadeAlpha(1f, 0.1f, true);

    }
}