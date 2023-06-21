using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class LeaveLobbyButton : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject finalPanel;

    public void OnClick_LeaveRoom()
    {
        PhotonNetwork.LeaveRoom();
        Debug.Log("Left Room");
        if (finalPanel)
        {
            finalPanel.SetActive(false);
        }
    }

    public override void OnLeftRoom()
    {
        PhotonNetwork.LoadLevel(0);
    }
}
