using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;

public class ChatBox : MonoBehaviourPunCallbacks
{
    public GameObject chatPanel, textObject;
    public InputField chatBox;
    public PhotonView PV;

    private void Start()
    {
        chatPanel.SetActive(false);
    }

    public void ToggleChatBox()
    {
        chatPanel.SetActive(!chatPanel.activeSelf);
    }

    public void SendChatMessage()
    {
        string message = PhotonNetwork.LocalPlayer.NickName + ": " + chatBox.text;
        PV.RPC("RPC_SendMessage", RpcTarget.All, message);
        chatBox.text = "";
    }

    [PunRPC]
    void RPC_SendMessage(string message)
    {
        GameObject newMessage = Instantiate(textObject, chatPanel.transform);
        newMessage.GetComponent<Text>().text = message;
    }
}