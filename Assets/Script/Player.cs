using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Photon.Realtime;
using Photon.Pun;

public class Player : MonoBehaviour
{
  
    public float horialAxis, speed;
    public Rigidbody2D rb_player;
    public bool canShoot, grounded, canHead;
    private GameObject _ball, _player2, _Ai;
    public Transform checkGround;
    [SerializeField] public LayerMask ground_Layer;
    public int hashShoot, hashMove;
   
    public float pushForce = 400f; // Nueva variable pushForce
    public float proximityThreshold = 1.5f;
    public GameObject btnShoot,btnMoveLeft, btnMoveRight, btnJump, btnarriba;
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
            GameObject player = GameObject.Find("Player");
            player.GetComponent<Player>().horialAxis = value;

        }

    }


    public void StopMove(int value)
    {
        GameObject player2 = GameObject.Find("Player");
        player2.GetComponent<Player>().Move(0);

    }

    
    public void Move1(int value)
    {
       if (value == 1)
        {
            btnMoveRight.transform.localScale = new Vector3(3.0375f, 2.175f, 2);
            btnMoveRight.GetComponent<Image>().CrossFadeAlpha(0.4f, 0.1f, true);


        }

        if (value == -1)
        {
            btnMoveLeft.transform.localScale = new Vector3(3.0375f, 2.175f, 2);
            btnMoveLeft.GetComponent<Image>().CrossFadeAlpha(0.4f, 0.1f, true);


        }


        if (GamerControler.instance.isScore == false && GamerControler.instance.EndMatch == false)
        {
            horialAxis = value;
        }
    }
    public void StopMove1(int value)
    {
        horialAxis = 0;

        if (value == 1)
        {
            btnMoveRight.transform.localScale = new Vector3(2.0375f, 1.175f, 1);
            btnMoveRight.GetComponent<Image>().CrossFadeAlpha(0.4f, 0.1f, true);


        }

        if (value == -1)
        {
            btnMoveLeft.transform.localScale = new Vector3(2.0375f, 1.175f, 1);
            btnMoveLeft.GetComponent<Image>().CrossFadeAlpha(0.4f, 0.1f, true);


        }
    }

    public void Shoot()
    {
        btnShoot.transform.localScale = new Vector3(9f, 5f, 2);
        btnShoot.GetComponent<Image>().CrossFadeAlpha(0.4f, 0.1f, true);
        if (canShoot == true)
        {
            _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400, 500));

            // Verificar la distancia entre el AI y el jugador
            float distanceToAi = Vector2.Distance(transform.position, _Ai.transform.position);
            if (distanceToAi < proximityThreshold)
            {
                // Empujar al AI hacia atrás
                Vector2 pushDirection = (_Ai.transform.position - transform.position).normalized;
                _Ai.GetComponent<Ai>().ApplyPush(pushDirection, pushForce);
            }
        }
    }
    public void Shootarriba()
    {
        btnarriba.transform.localScale = new Vector3(9f, 5f, 2);
        btnarriba.GetComponent<Image>().CrossFadeAlpha(0.4f, 0.1f, true);
        if (canShoot == true)
        {
            _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(-400, 500));
        }
    }


    public void ShootA()
    {
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        GameObject ballObject = GameObject.FindGameObjectWithTag("ball");

        if (playerObject != null && ballObject != null)
        {
            CircleCollider2D playerCollider = playerObject.GetComponent<CircleCollider2D>();
            CircleCollider2D ballCollider = ballObject.GetComponent<CircleCollider2D>();
            Rigidbody2D ballRigidbody = ballObject.GetComponent<Rigidbody2D>();

            if (playerCollider != null && ballCollider != null && ballRigidbody != null && playerCollider.Distance(ballCollider).isOverlapped)
            {
                ballRigidbody.AddForce(new Vector2(0, 900));
            }
        }
    }
    
    public void StopShoot()
    {
        btnShoot.transform.localScale = new Vector3(8.9675f, 4.27f, 1);
        btnShoot.GetComponent<Image>().CrossFadeAlpha(2f, 0.2f, true);
    }
    public void StopShootarriba()
    {
        btnarriba.transform.localScale = new Vector3(8.9675f, 4.27f, 1);
        btnarriba.GetComponent<Image>().CrossFadeAlpha(2f, 0.2f, true);
    }
    public void Jump()
    {
     
        if (grounded == true)
        {
            
            canHead = true;
            rb_player.velocity = new Vector2(rb_player.velocity.x, 15);

            GameObject player2 = GameObject.Find("Player");
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
    public void jump1()
    {
        btnJump.transform.localScale = new Vector3(9f, 5f, 2);
        btnJump.GetComponent<Image>().CrossFadeAlpha(0.4f, 0.1f, true);
        if (grounded == true && GamerControler.instance.isScore == false && GamerControler.instance.EndMatch == false)
        {
            canHead = true;
            rb_player.velocity = new Vector2(rb_player.velocity.x, 15);


        }

    }
    public void StopJump()
    {
        btnJump.transform.localScale = new Vector3(8.9675f, 4.27f, 1);
        btnJump.GetComponent<Image>().CrossFadeAlpha(2f, 0.2f, true);

    }




}
