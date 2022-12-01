using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class LeaveLobbyButton : MonoBehaviour
{
    public void OnClick_LeaveRoom()
    {
        //(Player player)
        PhotonNetwork.LeaveRoom(true);
        //PhotonNetwork.DestroyPlayerObjects(PhotonNetwork.player);
        Debug.Log("Leave");
        //SceneManager.LoadScene("MainMenuScene");
       
    }

}
