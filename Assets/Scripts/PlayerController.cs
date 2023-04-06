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
    public void SendPlayerAnswer(string _answer, string _playerID) //Wird beim Master aufgerufen von jedem Spieler
    {
        Debug.Log(_answer + _playerID);
    }

    [PunRPC]
    public void RequestPlayerAnswer() //Wird bei jeden Spieler von Master aufgerufen
    {
        string tst = PhotonNetwork.LocalPlayer.ActorNumber.ToString();
        Debug.Log(tst);
        this.photonView.RPC("SendPlayerAnswer", RpcTarget.MasterClient,answer, tst);
    }

    public void EndOfRound()
    {
        Debug.Log("EIGENSE VIEW ID:" + PhotonNetwork.LocalPlayer.ActorNumber);
        this.photonView.RPC("RequestPlayerAnswer", RpcTarget.Others);
    }

    public void MasterManager()
    {

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
