using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using System;
using System.Threading.Tasks;

public class GameSetupController : MonoBehaviour
{

    private GameObject myplayer;
    void Start()
    {
        //playerAnswer1 = "";
        //myplayer = PhotonNetwork.Instantiate(Path.Combine("Prefabs", "TestObject"), Vector3.zero, Quaternion.identity);
        //myplayer.gameObject.name = "MyPlayerObject";
        RoundManager();
    }

    public void SendDataToPrefab()
    {
       myplayer.GetComponent<PlayerController>().EndOfRound();
    }

    public async void RoundManager()
    {
        Debug.Log("Starting RoundManager");
        if (!PhotonNetwork.IsMasterClient) return;
        Debug.Log("THIS IS THE MASTER --- STARTING ROUND MANAGER!");
        await Task.Delay(TimeSpan.FromSeconds(7));
        Debug.Log("NEXT ROUND!");

    }


}
