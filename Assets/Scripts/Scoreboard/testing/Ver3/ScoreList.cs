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
    public Player player; //{ get; private set; }

    public void SetPlayerInfo(Player player)
    {
        /*
        try
        {
            Debug.Log((int)PhotonNetwork.CurrentRoom.CustomProperties["score" + player.ActorNumber]);
            Debug.Log("B------------------------------------------------------------");
        }
        catch
        {
            Player = player;
            playerName.text = player.NickName;
            Debug.Log("A------------------------------------------------------------");
            Debug.Log("Antworten Vergleich Listenlaenge:" + player.ActorNumber);
            //ebug.Log(player.CustomProperties.ContainsKey("Score"));
            //Debug.Log((int)PhotonNetwork.CurrentRoom.CustomProperties["score" + player.ActorNumber]);
            Debug.Log(PhotonNetwork.CurrentRoom);
            Debug.Log("A------------------------------------------------------------");
            int scoreInt = (int)player.CustomProperties["Score"];
            score.text = scoreInt.ToString();
            int rankInt = (int)player.CustomProperties["Rank"];
            rank.text = rankInt.ToString() + ".";

        }
        */


    }

    public void Initialize(Player player)
    {
        playerName.text = player.NickName;

        this.player = player;


        int scoreInt = (int)player.CustomProperties["Score"];
        score.text = scoreInt.ToString();
        int rankInt = (int)player.CustomProperties["Rank"];
        rank.text = rankInt.ToString() + ".";


        //UpdateStats();
    }

    /*
    public override void OnPlayerPropertiesUpdate(Player targetPlayer, Hashtable changedProps)
    {
        Debug.Log("T------------------------------------------------------------");
        if (targetPlayer == player)
        {
            if (changedProps.ContainsKey("Score"))
            {
                UpdateStats();
            }
        }
    }

    void UpdateStats()
    {
        Debug.Log("O------------------------------------------------------------");
        var hash = player.CustomProperties;
        Debug.Log(hash["Score"].ToString());
        score.text = hash["Score"].ToString();

        
    }
    */

    void Update()
    {
        var hash = player.CustomProperties;
        score.text = hash["Score"].ToString();
        rank.text = hash["Rank"].ToString() + ".";
    }

}

