using UnityEngine;
using TMPro;
using Photon.Realtime;
using Photon.Pun;

public class PlayerList : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TextMeshProUGUI nametext;
    [SerializeField]
    private GameObject kickButton;
    public Player Player;// { get; private set; }

    public void SetPlayerInfo(Player player)
    {
        Player = player;
        nametext.text = player.NickName;
        if (!PhotonNetwork.IsMasterClient)
        {
            kickButton.SetActive(false);
        }
        if (player.IsMasterClient)
        {
            //kickButton.SetActive(false);
        }
    }
    [PunRPC]
    private void Kick_Player()
    {
        PhotonNetwork.LeaveRoom(); // load lobby scene, returns to master server
    }

    public void OnClickKickPlayer()
    {
        PhotonNetwork.EnableCloseConnection = true;
        //PhotonNetwork.CloseConnection(Player);
        
        Debug.Log(Player.NickName);
        Debug.Log("Kicked Player from this Room");

        photonView.RPC("KickPlayer", Player, "kick");
    }




}
