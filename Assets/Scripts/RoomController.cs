using System.Collections.Generic;
using Photon.Pun;
using Photon.Realtime;
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
        PhotonNetwork.NickName += "#" + CreatePlayerHashtag();


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

    public string CreatePlayerHashtag()
    {
        bool isFree = false;
        string randomHashtag ="";

        while (!isFree)
        {
            isFree = true;
            randomHashtag = Random.Range(100, 1000).ToString();
            foreach (Player player in PhotonNetwork.PlayerListOthers)
            {
                if(randomHashtag == player.NickName.Substring(player.NickName.Length - 3))
                {
                    isFree = false;
                    break;
                }
            }
        }
        return randomHashtag;

    }

}
