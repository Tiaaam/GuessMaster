using UnityEngine;
using TMPro;
using Photon.Realtime;

public class ScoreList : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI rank;
    [SerializeField]
    private TextMeshProUGUI playerName;
    [SerializeField]
    private TextMeshProUGUI score;
    public Player Player { get; private set; }

    public void SetPlayerInfo(Player player)
    {
        Player = player;
        playerName.text = player.NickName;
        Debug.Log(player.CustomProperties.ContainsKey("Score"));
        Debug.Log(player.CustomProperties["Score"]);
        int scoreInt = (int)player.CustomProperties["Score"];
        score.text = scoreInt.ToString();
        int rankInt = (int)player.CustomProperties["Rank"];
        rank.text = rankInt.ToString() + ".";
    }
}
