using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class ScoreListingMenu : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private Transform _content;
    [SerializeField]
    private ScoreList _scoreList;

    private List<ScoreList> _listings = new List<ScoreList>();

    private void Awake()
    {
        GetCurrentPlayers();
    }
    private void GetCurrentPlayers()
    {
        foreach (KeyValuePair<int, Player> playerInfo in PhotonNetwork.CurrentRoom.Players)
        {
            AddPLayerListing(playerInfo.Value);
        }
    }

    private void AddPLayerListing(Player player)
    {
        Debug.Log("AddPlay");
        ScoreList listing = Instantiate(_scoreList, _content);
        if (listing != null)
        {
            listing.SetPlayerInfo(player);
            _listings.Add(listing);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        Debug.Log("I entereddddd");
        AddPLayerListing(newPlayer);

    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = _listings.FindIndex(x => x.Player == otherPlayer);
        if (index != -1)
        {
            Destroy(_listings[index].gameObject);
            _listings.RemoveAt(index);
        }
    }
}
