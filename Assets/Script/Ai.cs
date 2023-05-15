using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ai : MonoBehaviour
{
    public float rangerDenfece, speed;
    public Transform denfece, checkGround;
    public GameObject _ball, _player;
    private Rigidbody2D rb_Ai;
    public bool canShootAi, canHead, grounded;
    public LayerMask ground_Layer;
    public float pushForce = 200f;

    private Vector2 ballPosition;

    private void Start()
    {
        _ball = GameObject.FindGameObjectWithTag("ball");
        rb_Ai = GetComponent<Rigidbody2D>();
        _player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update()
    {
        if (GamerControler.instance.isScore || GamerControler.instance.EndMatch)
        {
            return;
        }

        ballPosition = _ball.transform.position;
        Vector2 playerPosition = _player.transform.position;

        // Verificar si el balón se está alejando de la AI
        if (ballPosition.x > transform.position.x && rb_Ai.velocity.x > 0)
        {
            // Mover hacia la posición del balón
            rb_Ai.velocity = new Vector2(Time.deltaTime * speed, rb_Ai.velocity.y);
        }
        else if (ballPosition.x < transform.position.x && rb_Ai.velocity.x < 0)
        {
            // Mover hacia la posición del balón
            rb_Ai.velocity = new Vector2(-Time.deltaTime * speed, rb_Ai.velocity.y);
        }
        else
        {
            // Comprobar la distancia entre el jugador y la AI
            float distanceToPlayer = Mathf.Abs(playerPosition.x - transform.position.x);

            if (distanceToPlayer < 2.4f)
            {
                // Retroceder un poco para evitar quedar demasiado cerca del jugador
                if (playerPosition.x > transform.position.x)
                {
                    rb_Ai.velocity = new Vector2(-Time.deltaTime * speed, rb_Ai.velocity.y);
                }
                else
                {
                    rb_Ai.velocity = new Vector2(Time.deltaTime * speed, rb_Ai.velocity.y);
                }
            }
            else
            {
                // Predecir la posición del jugador en el próximo frame
                Vector2 predictedPlayerPosition = playerPosition + _player.GetComponent<Rigidbody2D>().velocity * Time.deltaTime;

                // Calcular la distancia entre el balón y la posición predicha del jugador
                float distanceToPredictedPlayer = Mathf.Abs(ballPosition.x - predictedPlayerPosition.x);

                if (distanceToPredictedPlayer < rangerDenfece)
                {
                    if (ballPosition.x > transform.position.x && ballPosition.y < -0.5f)
                    {
                        rb_Ai.velocity = new Vector2(Time.deltaTime * speed, rb_Ai.velocity.y);
                    }
                    else if (ballPosition.x >= 0.5f && transform.position.x <= denfece.position.x)
                    {
                        rb_Ai.velocity = new Vector2(0, rb_Ai.velocity.y);
                    }
                    else
                    {
                        rb_Ai.velocity = new Vector2(-Time.deltaTime * speed, rb_Ai.velocity.y);
                    }
                }
                else
                {
                    if (transform.position.x > denfece.position.x)
                    {
                        rb_Ai.velocity = new Vector2(-Time.deltaTime * speed, rb_Ai.velocity.y);
                    }
                    else
                    {
                        rb_Ai.velocity = new Vector2(0, rb_Ai.velocity.y);
                    }
                }
            }
        }

        if (canShootAi)
        {
            Shoot();
        }

        if (canHead && grounded)
        {
            Jump();
        }
    }

    private void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(checkGround.position, 0.2f, ground_Layer);
    }

    private void Move()
    {
        float distanceToBall = Mathf.Abs(ballPosition.x - transform.position.x);

        if (distanceToBall < rangerDenfece)
        {
            if (ballPosition.x > transform.position.x && ballPosition.y < -0.5f)
            {
                rb_Ai.velocity = new Vector2(Time.deltaTime * speed, rb_Ai.velocity.y);
            }
            else if (ballPosition.x >= 0.5f && transform.position.x <= denfece.position.x)
            {
                rb_Ai.velocity = new Vector2(0, rb_Ai.velocity.y);
            }
            else
            {
                rb_Ai.velocity = new Vector2(-Time.deltaTime * speed, rb_Ai.velocity.y);
            }
        }
        else
        {
            if (transform.position.x > denfece.position.x)
            {
                rb_Ai.velocity = new Vector2(-Time.deltaTime * speed, rb_Ai.velocity.y);
            }
            else
            {
                rb_Ai.velocity = new Vector2(0, rb_Ai.velocity.y);
            }
        }
    }

    private void Shoot()
    {
        Vector2 shootDirection = (_player.transform.position - transform.position).normalized;
        _ball.GetComponent<Rigidbody2D>().AddForce(shootDirection * pushForce);
    }

    private void Jump()
    {
        rb_Ai.velocity = new Vector2(rb_Ai.velocity.x, 20);
    }

    public void ApplyPush(Vector2 pushDirection, float pushForce)
    {
        rb_Ai.AddForce(pushDirection * pushForce, ForceMode2D.Impulse);
    }
}
