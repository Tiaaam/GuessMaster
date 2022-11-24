using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;

public class PlayerGroupManager : MonoBehaviour
{
    public TextMeshProUGUI namesDisplay;
    public string[] usernames;

    void Start()
    {
        
    }

    void Update()
    {
        
        usernames = new string[PhotonNetwork.PlayerList.Length];
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            
            usernames[i] = PhotonNetwork.PlayerList[i].NickName;
            //Debug.Log(PhotonNetwork.PlayerList[i].NickName);
            Debug.Log(usernames[i]);
            //Debug.Log(PhotonNetwork.PlayerList.Length);
            //namesDisplay.text = string.Join("\n", usernames);

            //string a = string.Join("", usernames);
            //Debug.Log("Player" + a + "  i:  " + i.ToString());
        }
        //Debug.Log(string.Join("\n", usernames));
        //Debug.Log(usernames);
        namesDisplay.text = string.Join("\n", usernames);
        //int l = PhotonNetwork.PlayerList.Length;
        //usernames[l] = PhotonNetwork.PlayerList[].NickName;
        //namesDisplay.text = string.Join("\n", usernames);
    }
}
