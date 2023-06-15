using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using TMPro;

public class ResultScore : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private TextMeshProUGUI rank;
    [SerializeField]
    private TextMeshProUGUI playerName;
    [SerializeField]
    private TextMeshProUGUI score;
    public Player player;


    public void Initialize(Player player)
    {
        playerName.text = player.NickName;
        this.player = player;
        int scoreInt = (int)player.CustomProperties["Score"];
        score.text = scoreInt.ToString();
        int rankInt = (int)player.CustomProperties["Rank"];
        rank.text = rankInt.ToString() + ".";
    }
}
