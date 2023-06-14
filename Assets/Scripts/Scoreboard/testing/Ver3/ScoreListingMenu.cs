using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using System.Linq;

public class ScoreListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform container;
    [SerializeField]
    private ScoreList itemPrefab;

    Dictionary<Player, ScoreList> scoreboardItems = new Dictionary<Player, ScoreList>();
    List<Player> currentListing = new List<Player>();

    void Start()
    {
        foreach(Player player in PhotonNetwork.PlayerList)
        {
            AddScoreboardItem(player);
        }
    }

    void AddScoreboardItem(Player player)
    {
        ScoreList item = Instantiate(itemPrefab, container).GetComponent<ScoreList>();
        item.Initialize(player);
        scoreboardItems[player] = item;
        currentListing.Add(player);
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddScoreboardItem(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        RemoveScoreboardItem(otherPlayer);
    }

    void RemoveScoreboardItem(Player player)
    {
        Destroy(scoreboardItems[player].gameObject);
        scoreboardItems.Remove(player);
        currentListing.Remove(player);
    }

    void Update()
    {
        List<Player> sortedList = currentListing.OrderBy(p => p.CustomProperties["Rank"]).ToList();

        if (sortedList != currentListing)
        {
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                RemoveScoreboardItem(player);
            }
            foreach (Player player in sortedList)
            {
                AddScoreboardItem(player);
            }
        }
    }
}
