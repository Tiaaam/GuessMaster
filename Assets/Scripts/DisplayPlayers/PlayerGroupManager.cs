using UnityEngine;
using TMPro;
using Photon.Pun;

public class PlayerGroupManager : MonoBehaviour
{
    public TextMeshProUGUI namesDisplay;
    public string[] usernames;

    void Update()
    {
        usernames = new string[PhotonNetwork.PlayerList.Length];
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {         
            usernames[i] = PhotonNetwork.PlayerList[i].NickName;
        }
        namesDisplay.text = string.Join("\n", usernames);
    }
}
