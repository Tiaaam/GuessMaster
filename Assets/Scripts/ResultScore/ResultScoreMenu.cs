using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Realtime;
using Photon.Pun;
using System.Linq;

public class ResultScoreMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform container;
    [SerializeField]
    private ResultScore itemPrefab;
    List<Player> currentListing = new List<Player>();


    void Update()
    {
        if (GameSetupController.isOver)
        {
            foreach (Player player in PhotonNetwork.PlayerList)
            {
                currentListing.Add(player);
            }

            List<Player> sortedList = currentListing.OrderBy(p => p.CustomProperties["Rank"]).ToList();

            foreach (Player player in sortedList)
            {
                AddScoreboardItem(player);
            }
        }
    }

    void AddScoreboardItem(Player player)
    {
        ResultScore item = Instantiate(itemPrefab, container).GetComponent<ResultScore>();
        item.Initialize(player);
    }
}
