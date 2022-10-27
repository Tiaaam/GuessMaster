using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class RoomController : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private TextMeshProUGUI roomNameField;
    [SerializeField]
    private GameObject changeSettingsPanel;
    [SerializeField]

    void Start()
    {
        roomNameField.text = PhotonNetwork.CurrentRoom.Name;
        if (PhotonNetwork.IsMasterClient)
        {
            changeSettingsPanel.SetActive(true);
        }
    }

    public void ChangeRoomSize()
    {
        //int roomsize = (int) roomSizeSlider.value;
        //Debug.Log(roomsize);
        //roomSizeField.text = roomsize.ToString();
    }

    public void StartGame()
    {
        PhotonNetwork.LoadLevel(2);
    }
}
