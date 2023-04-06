using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using System;
using System.Threading.Tasks;
using Photon.Pun;

public class GameSetupController : MonoBehaviourPunCallbacks
{

    private GameObject myplayer;
    public string answer;
    void Start()
    {
        answer = "this is an answer";
    }

    public void SendDataToPrefab()
    {
        EndOfRound();
    }

    public async void ShowAnswers()
    {
        Debug.Log("Starting RoundManager");
        if (!PhotonNetwork.IsMasterClient) return;
        Debug.Log("THIS IS THE MASTER --- WAITING 3 SECONDS ---- SHOW LOADING SCREEN");
        await Task.Delay(TimeSpan.FromSeconds(3));
        EndOfRound();

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
        this.photonView.RPC("SendPlayerAnswer", RpcTarget.MasterClient, answer, PhotonNetwork.LocalPlayer.ActorNumber.ToString());
    }

    public void EndOfRound()
    {
        Debug.Log("EIGENSE VIEW ID:" + PhotonNetwork.LocalPlayer.ActorNumber);
        this.photonView.RPC("RequestPlayerAnswer", RpcTarget.Others);
    }

}
