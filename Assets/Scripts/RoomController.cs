using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class RoomController : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private TextMeshProUGUI roomNameField;
    [SerializeField]
    private GameObject masterPanel;
    [SerializeField]

    void Start()
    {
        roomNameField.text = PhotonNetwork.CurrentRoom.Name;
        if (PhotonNetwork.IsMasterClient)
        {
            masterPanel.SetActive(true);
        }
    }


    public void StartGame()
    {
        PhotonNetwork.LoadLevel(2);
    }
}
