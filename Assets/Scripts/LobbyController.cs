using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UIElements;

public class LobbyController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private GameObject joinRandomRoomButton;
    [SerializeField]
    private GameObject joinSpecificRoomButton;
    [SerializeField]
    private GameObject HostRoomButton;
    [SerializeField]
    private TextMeshProUGUI RoomIDInput;
    [SerializeField]
    private TextMeshProUGUI RoomIDLog;


    [SerializeField]
    private GameObject HostingPanel;

    [SerializeField]
    private TextMeshProUGUI PlayerNameInput;

    private ExitGames.Client.Photon.Hashtable _myCustomProperties = new ExitGames.Client.Photon.Hashtable();

    private void giveProperties()
    {
        _myCustomProperties["Score"] = 0;
        _myCustomProperties["Rank"] = 1;
        PhotonNetwork.LocalPlayer.CustomProperties = _myCustomProperties;
    }
    private void generateName()
    {
        string playername = PlayerNameInput.text;
        if (playername.Length > 1 && playername.Length < 12)
        {
            playername = playername.Substring(0, playername.Length - 1);
        }
        else
        {
            playername = "Player";
        }
        PhotonNetwork.NickName = playername;
    }

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        joinRandomRoomButton.SetActive(true);
        joinSpecificRoomButton.SetActive(true);
        HostRoomButton.SetActive(true); 
    }

    public void JoinRandomRoom()
    {
        generateName();
        giveProperties();
        joinRandomRoomButton.SetActive(false);
        PhotonNetwork.JoinRandomRoom();
    }

    public void JoinSpecificRoom()
    {
        generateName();
        giveProperties();
        joinSpecificRoomButton.SetActive(false);
        RoomIDLog.text = "";
        string roomID = RoomIDInput.text.Substring(0,6);
        PhotonNetwork.JoinRoom(roomID);
    }

    public void OpenHostPanel()
    {
        HostingPanel.SetActive(true);
    }

    public void CloseHostPanel()
    {
        HostingPanel.SetActive(false);
    }


    public void StartHosting()
    {
        CreateRoom(5, true);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join random Room");
        CreateRoom(8, true);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        RoomIDLog.text = "Room not found...";
        joinSpecificRoomButton.SetActive(true);
    }

    public void CreateRoom(int roomSize, bool isPublic)
    {
        Debug.Log("Creating new Room");
        string roomid = generateRoomID();
        RoomOptions roomOps = new RoomOptions() { IsVisible = isPublic, IsOpen = true, MaxPlayers = (byte)roomSize };
        PhotonNetwork.CreateRoom(roomid, roomOps, TypedLobby.Default);
        Debug.Log("Room(" + roomid + ") created");
    }

    private string generateRoomID()
    {
        const string glyphs = "ABCDEFGHJKLMNPQRSTUVWXYZ123456789";
        string myid = "";
        for (int i = 0; i < 6; i++)
        {
            myid += glyphs[Random.Range(0, glyphs.Length)];
        }
        return myid;
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create room... try again");
    }

    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public override void OnJoinedRoom()
    {
        Debug.Log("Joined Room");
        generateName();
        giveProperties();
        PhotonNetwork.LoadLevel(1);
    }
}
