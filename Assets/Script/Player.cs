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

    public GameObject btnShoot, btnMoveLeft, btnMoveRight, btnJump, btnarriba;
    public Button btnPosicionX2;
    public Text posicionX2Text;
    private int posicionX2Count = 8;
    private bool isUsingPosicionX2 = false;
    private float posicionX2Timer = 0f;
    private float posicionX2Duration = 4f;
    public float pushForce; // Declaración de la variable pushForce como pública

    void Start()
    {
        rb_player = GetComponent<Rigidbody2D>();
        _ball = GameObject.FindGameObjectWithTag("ball");
        _player2 = GameObject.FindGameObjectWithTag("Player");

        btnPosicionX2.onClick.AddListener(ActivatePosicionX2);
        UpdatePosicionX2Text();
    }
    void SomeMethod()
    {
        // Uso de la variable pushForce
        float result = pushForce * 2;
        Debug.Log("Result: " + result);
    }
    void Update()
    {
        if (isUsingPosicionX2)
        {
            posicionX2Timer += Time.deltaTime;

            if (posicionX2Timer >= posicionX2Duration)
            {
                isUsingPosicionX2 = false;
                posicionX2Timer = 0f;
                ResetJumpHeight();
                UpdatePosicionX2Text();
            }
        }
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
            if (isUsingPosicionX2)
            {
                horialAxis = value * 1.5f;
            }
            else
            {
                horialAxis = value;
            }
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

            PushAi(); // Llamar al método para empujar a la AI si está muy cerca

        }
    }
    public void PushAi()
    {
        GameObject aiObject = GameObject.FindGameObjectWithTag("Ai");
        GameObject ballObject = GameObject.FindGameObjectWithTag("ball");

        if (aiObject != null && ballObject != null)
        {
            CircleCollider2D aiCollider = aiObject.GetComponent<CircleCollider2D>();
            CircleCollider2D ballCollider = ballObject.GetComponent<CircleCollider2D>();
            Rigidbody2D ballRigidbody = ballObject.GetComponent<Rigidbody2D>();

            if (aiCollider != null && ballCollider != null && ballRigidbody != null && aiCollider.Distance(ballCollider).isOverlapped)
            {
                // Empujar a la AI hacia atrás
                ballRigidbody.AddForce((aiObject.transform.position - ballObject.transform.position).normalized * pushForce);
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

            float jumpHeight = isUsingPosicionX2 ? 30f : 15f;

            rb_player.velocity = new Vector2(rb_player.velocity.x, jumpHeight);

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

            float jumpHeight = isUsingPosicionX2 ? 20f : 15f;

            rb_player.velocity = new Vector2(rb_player.velocity.x, jumpHeight);
        }
    }

    public void StopJump()
    {
        btnJump.transform.localScale = new Vector3(8.9675f, 4.27f, 1);
        btnJump.GetComponent<Image>().CrossFadeAlpha(2f, 0.2f, true);
    }

    private void ActivatePosicionX2()
    {
        if (posicionX2Count > 0 && !isUsingPosicionX2)
        {
            posicionX2Count--;
            isUsingPosicionX2 = true;
            posicionX2Timer = 0f;
            UpdatePosicionX2Text();
        }
    }

    private void ResetJumpHeight()
    {
        rb_player.velocity = new Vector2(rb_player.velocity.x, 15f);
    }

    private void UpdatePosicionX2Text()
    {
        posicionX2Text.text = "PowerMX " + posicionX2Count;
    }
}



