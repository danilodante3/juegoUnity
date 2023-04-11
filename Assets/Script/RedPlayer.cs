using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class RedPlayer : MonoBehaviour
{
    public MonoBehaviour[] codigosQueIgnorar;

    public PhotonView PhotonView;

    // Start is called before the first frame update
    void Start()
    {
        PhotonView = GetComponent<PhotonView>();
        if (!PhotonView.IsMine)
        {
            foreach (var codigo in codigosQueIgnorar)
            {
                codigo.enabled= false;
            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
