using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using TMPro;
using UnityEngine.UI;

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
    private TextMeshProUGUI numberOfPlayers;
    [SerializeField]
    private TextMeshProUGUI numberOfRounds;
    [SerializeField]
    private TextMeshProUGUI numberOfSeconds;
    [SerializeField]
    private Toggle togglePublicGame;
    [SerializeField]
    private GameObject HostingPanel;
    [SerializeField]
    private TextMeshProUGUI PlayerNameInput;
    private ExitGames.Client.Photon.Hashtable myCustomProperties = new ExitGames.Client.Photon.Hashtable();

    private void giveProperties()
    {
        myCustomProperties["Score"] = 0;
        myCustomProperties["Rank"] = 1;
        PhotonNetwork.LocalPlayer.CustomProperties = myCustomProperties;
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
        Debug.Log("Connected to Master!");
    }

    public void JoinRandomRoom()
    {
        generateName();
        giveProperties();
        Debug.Log("JOINED RANDOM ROOM!");
        joinRandomRoomButton.SetActive(false);
        PhotonNetwork.JoinRandomRoom();
    }

    public void JoinSpecificRoom()
    {
        generateName();
        giveProperties();
        Debug.Log("JOINED SPECIFIC ROOM!");
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
        CreateRoom(int.Parse(numberOfPlayers.GetParsedText()),
                   int.Parse(numberOfRounds.GetParsedText()),
                   int.Parse(numberOfSeconds.GetParsedText()),
                   togglePublicGame.isOn);
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join random Room");
        CreateRoom(8, 5, 20, true);
    }

    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        RoomIDLog.text = "Room not found...";
        joinSpecificRoomButton.SetActive(true);
    }

    public void CreateRoom(int roomSize, int rounds, int seconds, bool isPublic)
    {
        Debug.Log("Creating new Room");
        string roomid = generateRoomID();
        RoomOptions roomOps = new RoomOptions() { IsVisible = isPublic, IsOpen = true, MaxPlayers = (byte)roomSize };
        ExitGames.Client.Photon.Hashtable roomProperties = new ExitGames.Client.Photon.Hashtable();
        roomProperties["NumberOfRounds"] = rounds;
        roomProperties["NumberOfSeconds"] = seconds;
        roomOps.CustomRoomProperties = roomProperties;
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
        Debug.Log("Joined Room!");
        generateName();
        giveProperties();
        PhotonNetwork.LoadLevel(1);
    }
}
