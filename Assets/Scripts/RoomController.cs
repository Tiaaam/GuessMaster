using Photon.Pun;
using TMPro;
using UnityEngine;

public class RoomController : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private TextMeshProUGUI roomNameField;
    [SerializeField]
    private GameObject changeSettingsPanel;

    void Start()
    {
        roomNameField.text = PhotonNetwork.CurrentRoom.Name;
        if (PhotonNetwork.IsMasterClient)
        {
            changeSettingsPanel.SetActive(true);
        }
    }
}
