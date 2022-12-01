using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPunCallbacks
{
    public string answer;
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
        Debug.Log(_answer + _playerID.ToString());
    }

    [PunRPC]
    public void RequestPlayerAnswer() //Wird bei jeden Spieler von Master aufgerufen
    {
        this.photonView.RPC("SendPlayerAnswer", RpcTarget.MasterClient,answer, 0);
    }

    public void EndOfRound()
    {
        this.photonView.RPC("RequestPlayerAnswer", RpcTarget.Others);
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
