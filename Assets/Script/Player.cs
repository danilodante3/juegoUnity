using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
using Photon.Realtime;
using Photon.Pun;

public class Player : MonoBehaviour
{
    private float lastPushTime = 0f;
    private float pushCooldown = 2f;
    public float horialAxis, speed;
    public Rigidbody2D rb_player;
    public bool canShoot, grounded, canHead;
    private GameObject _ball, _player2, _Ai;
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
    public void PushAi()
    {
        // Verificar si ha pasado suficiente tiempo desde el último uso del botón
        if (Time.time - lastPushTime >= pushCooldown)
        {
            // Actualizar el tiempo del último uso del botón
            lastPushTime = Time.time;

            float distance = Vector2.Distance(transform.position, _ball.transform.position);
            if (distance < 1.5f)
            {
                Vector2 pushDirection = (_Ai.transform.position - _ball.transform.position).normalized;
                ball ballComponent = _ball.GetComponent<ball>();
                if (ballComponent != null)
                {
                    float pushForce = 50f; // Ajusta la fuerza del empuje según tus necesidades
                    ballComponent.ApplyPushAi(pushDirection, pushForce);
                    Debug.Log("¡Botón de empuje funciona correctamente!");
                }
            }
        }
    }

    public void Shoot1()
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
                ballRigidbody.AddForce(new Vector2(-400, 500));
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
    public void StopJump()
    {

    }
    



}
