using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class GameSetupController : MonoBehaviour
{

    private GameObject myplayer;
    void Start()
    {
        //Debug.Log("Creating Player");
        //playerAnswer1 = "";
        //myplayer = PhotonNetwork.Instantiate(Path.Combine("Prefabs", "TestObject"), Vector3.zero, Quaternion.identity);
        //myplayer.gameObject.name = "MyPlayerObject";
    }

    public void SendDataToPrefab()
    {
       myplayer.GetComponent<PlayerController>().EndOfRound();
    }


}
