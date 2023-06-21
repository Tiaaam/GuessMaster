using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class LeaveLobbyButton : MonoBehaviourPunCallbacks
{
    public void OnClick_LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        Debug.Log("Left Room");
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel(0);
    }


}
