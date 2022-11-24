using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using TMPro;

public class ScoreProperty : MonoBehaviour
{

    public TextMeshProUGUI submitText;

    private ExitGames.Client.Photon.Hashtable _myCustomProperties = new ExitGames.Client.Photon.Hashtable();


    // Start is called before the first frame update
    void Start()
    {
        _myCustomProperties["Score"] = 420;
        PhotonNetwork.LocalPlayer.CustomProperties = _myCustomProperties;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
