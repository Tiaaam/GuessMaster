using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;


public class ScoreProperty : MonoBehaviourPunCallbacks
{

    private ExitGames.Client.Photon.Hashtable _myCustomProperties = new ExitGames.Client.Photon.Hashtable();

    private string[] usernames;

    void Start()
    {
        _myCustomProperties["Score"] = 0;
        _myCustomProperties["Rank"] = 1;
        PhotonNetwork.LocalPlayer.CustomProperties = _myCustomProperties;




        Debug.Log("------------");

        //foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        //{
        //    PhotonNetwork.LocalPlayer.CustomProperties = _myCustomProperties;
        //}
        usernames = new string[PhotonNetwork.PlayerList.Length];

        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {

            usernames[i] = PhotonNetwork.PlayerList[i].NickName;
            Debug.Log("AAAAAAAAAAAAAAA");
            Debug.Log(PhotonNetwork.PlayerList[i].NickName);
            Debug.Log((int)PhotonNetwork.PlayerList[i].CustomProperties["Score"]);
            Debug.Log("AAAAAAAAAAAAAAA");

        }
    }
}
