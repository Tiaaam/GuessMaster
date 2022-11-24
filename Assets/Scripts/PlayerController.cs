using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPunCallbacks
{
    private string answer;
    // Start is called before the first frame update
    void Start()
    {
        answer = "this is an answer";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [PunRPC]
    public void SendPlayerAnswer(string _answer, int _playerID) //Wird beim Master aufgerufen von jedem Spieler
    {
        if (!photonView.IsMine) return;
        Debug.Log(_answer + _playerID.ToString());
    }

    [PunRPC]
    public void RequestPlayerAnswer() //Wird bei jeden Spieler von Master aufgerufen
    {
        if (!this.gameObject.GetComponent<PhotonView>().IsMine) Debug.Log("not mine");
        Debug.Log(this.photonView.ViewID);
        this.photonView.RPC("SendPlayerAnswer", RpcTarget.MasterClient,answer, this.gameObject.GetComponent<PhotonView>().ViewID);
    }

    public void EndOfRound()
    {
        this.photonView.RPC("RequestPlayerAnswer", RpcTarget.All);
    }

    //[PunRPC]
    //public void SendDataToServer()
    //{
    //    Debug.Log("test");
    //}

    //public void SendData()
    //{
    //    Debug.Log(this.photonView.ViewID);
    //    this.photonView.RPC("SendDataToServer", RpcTarget.All);
    //}
}
