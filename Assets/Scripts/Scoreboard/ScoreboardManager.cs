using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;

public class ScoreboardManager : MonoBehaviour
{


    public TextMeshProUGUI scoreboardText;

    //public TextMeshProUGUI scoreText;
    //public TextMeshProUGUI rankText;
    //public TextMeshProUGUI nameText;


    public string[] usernames;
    int score;
    int rank = 1;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        usernames = new string[PhotonNetwork.PlayerList.Length];
        for (int i = 0; i < PhotonNetwork.PlayerList.Length; i++)
        {
            usernames[i] = PhotonNetwork.PlayerList[i].NickName;

            int score = (int)PhotonNetwork.PlayerList[i].CustomProperties["Score"];

            string a = string.Join("", usernames);
            scoreboardText.text = $"\n {rank.ToString()}.              " + a + $"              {score.ToString()}";

            //rank++;
        }
        rank = 1;
    }
}
