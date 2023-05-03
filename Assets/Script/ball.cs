using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;
using Photon.Realtime;

public class ball : MonoBehaviour
{
    private GameObject _Player, _Ai;
    public GameObject gooals, orientBall;
    [SerializeField] private TrailRenderer tr;
        public float angleOrienBall = 30;
    private PhotonView photonView;


    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");
        _Ai = GameObject.FindGameObjectWithTag("Ai");
        if (photonView.IsMine)
        {
            GetComponent<Rigidbody2D>().isKinematic = false;
            GetComponent<Rigidbody2D>().gravityScale = 1f;
            GetComponent<PhotonTransformView>().enabled = true;
        }
        // Si este objeto no pertenece al cliente actual, deshabilitar la sincronización de la posición y la rotación
        else
        {
            GetComponent<Rigidbody2D>().isKinematic = true;
            GetComponent<Rigidbody2D>().gravityScale = 0f;
            GetComponent<PhotonTransformView>().enabled = false;
        }
    }

    void Update()
    {
        tr.emitting = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _Player.GetComponent<Player>().canShoot = true;
            
        }
        
        if (collision.gameObject.tag == "Ai")
        {
            _Ai.GetComponent<Ai>().canShootAi = true;
        }
        if (collision.gameObject.tag == "canHeadAi")
        {
            _Ai.GetComponent<Ai>().canHead = true;
        }
        if (collision.gameObject.tag == "GoalsRight")
        {
            if (GamerControler.instance.isScore == false && GamerControler.instance.EndMatch == false)
            {
                Instantiate(gooals, new Vector3(0, -2, 0), Quaternion.identity); Instantiate(gooals, new Vector3(0, -2, 0), Quaternion.identity);
                GamerControler.instance.number_GoalsLeft++;
                GamerControler.instance.isScore = true;
                GamerControler.instance.ContinueMatch(true);
                PhotonNetwork.AutomaticallySyncScene = true;

            }
        }
        if (collision.gameObject.tag == "GoalsLeft")
        {
            {
                if (GamerControler.instance.isScore == false && GamerControler.instance.EndMatch == false)
                {
                    Instantiate(gooals, new Vector3(0, -2, 0), Quaternion.identity);
                    GamerControler.instance.number_GoalsRight++;
                    GamerControler.instance.isScore = true;
                    GamerControler.instance.ContinueMatch(false);
                    PhotonNetwork.AutomaticallySyncScene = true;
                }
            }
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _Player.GetComponent<Player>().canShoot = false;
        }
        if (collision.gameObject.tag == "Ai")
        {
            _Ai.GetComponent<Ai>().canShootAi = false;
        }

        if (collision.gameObject.tag == "canHeadAi")
        {
            _Ai.GetComponent<Ai>().canHead = false;
        }
    }
}