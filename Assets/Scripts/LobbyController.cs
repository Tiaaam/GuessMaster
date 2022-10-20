using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class LobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject quickStartButton;
    [SerializeField]
    private GameObject quickCancelButton;

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        quickStartButton.SetActive(true);
    }

    public void QuickStart()
    {
        quickStartButton.SetActive(false);
        quickCancelButton.SetActive(true);
        PhotonNetwork.JoinRandomRoom();
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join random Room");
        CreateRoom(4, true);
    }

    public void CreateRoom(int roomSize, bool isPublic)
    {
        Debug.Log("Creating new Room");
        string roomid = generateRoomID();
        RoomOptions roomOps = new RoomOptions() { IsVisible = isPublic, IsOpen = true, MaxPlayers = (byte)roomSize };
        PhotonNetwork.CreateRoom(roomid, roomOps);
        Debug.Log("Room(" + roomid + ") created");
    }

    private string generateRoomID()
    {
        const string glyphs = "abcdefghijklmnopqrstuvwxyz0123456789";
        string myid = "";
        for (int i = 0; i <= 6; i++)
        {
            myid += glyphs[Random.Range(0, glyphs.Length)];
        }
        return myid;
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create room... try again");
    }

    public void QuickCancel()
    {
        quickCancelButton.SetActive(false);
        quickStartButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
}
