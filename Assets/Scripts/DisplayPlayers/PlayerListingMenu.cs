using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class PlayerListingMenu : MonoBehaviourPunCallbacks
{
    [SerializeField]
    private Transform content;
    [SerializeField]
    private PlayerList playerList;
    private List<PlayerList> listings = new List<PlayerList>();

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
        PlayerList listing = Instantiate(playerList, content);
        if (listing != null)
        {
            listing.SetPlayerInfo(player);
            listings.Add(listing);
        }
    }

    public override void OnPlayerEnteredRoom(Player newPlayer)
    {
        AddPLayerListing(newPlayer);
    }

    public override void OnPlayerLeftRoom(Player otherPlayer)
    {
        int index = listings.FindIndex(x => x.Player == otherPlayer);
        if (index != -1)
        {
            Destroy(listings[index].gameObject);
            listings.RemoveAt(index);
        }
    }
}
