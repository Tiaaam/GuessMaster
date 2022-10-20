using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;

public class GameSetupController : MonoBehaviour
{
    void Start()
    {
        Debug.Log("Creating Player");
        PhotonNetwork.Instantiate(Path.Combine("Prefabs", "TestObject"), Vector3.zero, Quaternion.identity);
    }
}
