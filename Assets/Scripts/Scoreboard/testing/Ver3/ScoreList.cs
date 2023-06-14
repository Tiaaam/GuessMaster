using UnityEngine;
using TMPro;
using Photon.Realtime;
using Photon.Pun;
using ExitGames.Client.Photon;

public class ScoreList : MonoBehaviourPunCallbacks
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

    void Update()
    {
        var hash = player.CustomProperties;
        score.text = hash["Score"].ToString();
        rank.text = hash["Rank"].ToString() + ".";
    }

}

