using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerController : MonoBehaviourPunCallbacks
{
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    [PunRPC]
    public void SendDataToServer()
    {
        Debug.Log("test");
    }

    public void SendData()
    {
        Debug.Log(this.photonView.ViewID);
        this.photonView.RPC("SendDataToServer", RpcTarget.All);
    }
}
