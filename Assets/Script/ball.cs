using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using UnityEngine;

public class ball : MonoBehaviour
{
    private GameObject _Player, _Ai;
    public GameObject gooals;
    [SerializeField] private TrailRenderer tr;
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player");
        _Ai = GameObject.FindGameObjectWithTag("Ai");

    }

    void Update()
    {
        tr.emitting = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            _Player.GetComponent<Player>().canShoot= true;
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
            if(GamerControler.instance.isScore == false && GamerControler.instance.EndMatch == false)
                {
                Instantiate(gooals, new Vector3(0, -2, 0), Quaternion.identity);            Instantiate(gooals, new Vector3(0, -2, 0), Quaternion.identity);
                GamerControler.instance.number_GoalsLeft++;
                GamerControler.instance.isScore = true;
                GamerControler.instance.ContinueMatch (true);
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
                    GamerControler.instance.isScore= true;
                    GamerControler.instance.ContinueMatch(false);

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