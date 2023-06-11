using UnityEngine;
using TMPro;
using Photon.Realtime;

public class PlayerList : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI nametext;
    public Player Player { get; private set; }

    public void SetPlayerInfo(Player player)
    {
        Player = player;
        nametext.text = player.NickName;
    }
}
