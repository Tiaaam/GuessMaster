using Photon.Pun;
using TMPro;
using UnityEngine;

public class RoomController : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TextMeshProUGUI roomNameField;
    [SerializeField]
    private TextMeshProUGUI playerCount;
    [SerializeField]
    private TextMeshProUGUI numberOfRounds;
    [SerializeField]
    private TextMeshProUGUI roundTime;
    [SerializeField]
    private GameObject masterPanel;

    void Start()
    {
        roomNameField.text = PhotonNetwork.CurrentRoom.Name;
        playerCount.text = PhotonNetwork.CurrentRoom.MaxPlayers.ToString();
        if (PhotonNetwork.IsMasterClient)
        {
            masterPanel.SetActive(true);
        }
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("NumberOfRounds"))
        {
            numberOfRounds.text = PhotonNetwork.CurrentRoom.CustomProperties["NumberOfRounds"].ToString();
        }

        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("NumberOfSeconds"))
        {
            roundTime.text = PhotonNetwork.CurrentRoom.CustomProperties["NumberOfSeconds"].ToString();
        }
    }

    public void StartGame()
    {
        Debug.Log("Starting Game...");
        PhotonNetwork.LoadLevel(2);
    }
}
