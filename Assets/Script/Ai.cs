using UnityEngine;


public class Ai : MonoBehaviour
{
    public float rangerDenfece, speed;
    public Transform denfece, checkGround;
    public GameObject _ball;
    private Rigidbody2D rb_Ai;
    public bool canShootAi, canHead, grounded;
    public LayerMask ground_Layer;


    void Start()
    {
        _ball = GameObject.FindGameObjectWithTag("ball");
        rb_Ai = GetComponent<Rigidbody2D>();

    }
    public void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(checkGround.position, 0.2f, ground_Layer);
        Vector2 ballPosition = _ball.transform.position;


    }
    void Update()
    {
        if (GamerControler.instance.isScore == false && GamerControler.instance.EndMatch == false)
        {
            Move();
            if (canShootAi == true)
            {
                Shoot();
            }
            if (canHead == true)
            {
                Jump();
            }
        }
    }
    public void Move()
    {
        if (Mathf.Abs(_ball.transform.position.x - transform.position.x) < rangerDenfece)
        {
            if (_ball.transform.position.x > transform.position.x && _ball.transform.position.y > -0)
            {
                rb_Ai.velocity = new Vector2(Time.deltaTime * speed, rb_Ai.velocity.y);
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
    public void Shoot()
    {
        if (canShootAi)
        {
            _ball.GetComponent<Rigidbody2D>().AddForce(new Vector2(30, 50));
        }
    }
    public void Jump()
    {
        if (grounded)
        {
            rb_Ai.velocity = new Vector2(rb_Ai.velocity.x, 20);
        }

    }
}
