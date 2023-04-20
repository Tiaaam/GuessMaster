using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using System;
using System.Threading.Tasks;
using Photon.Pun;

public class GameSetupController : MonoBehaviourPunCallbacks
{
    public static int roundStatus = 0;
    public static string question = "TestQuestion";
    public static string correct_answer = "AnswerQuestion";
    private GameObject myplayer;
    public string answer;
    void Start()
    {
        answer = "this is an answer";
    }

    public void SendDataToPrefab()
    {
        EndOfRound();
    }

    /*public async void ShowAnswers()
    {
        Debug.Log("Starting RoundManager");
        if (!PhotonNetwork.IsMasterClient) return;
        Debug.Log("THIS IS THE MASTER --- WAITING 3 SECONDS ---- SHOW LOADING SCREEN");
        await Task.Delay(TimeSpan.FromSeconds(3));
        EndOfRound();

    }*/


    [PunRPC]
    public void SendPlayerAnswer(string _answer, string _playerID) //Wird beim Master aufgerufen von jedem Spieler
    {
        Debug.Log(_answer + _playerID);
    }

    [PunRPC]
    public void RequestPlayerAnswer() //Wird bei jeden Spieler von Master aufgerufen
    {
        roundStatus = 1;
        string tst = PhotonNetwork.LocalPlayer.ActorNumber.ToString();
        Debug.Log(tst);
        this.photonView.RPC("SendPlayerAnswer", RpcTarget.MasterClient, answer, PhotonNetwork.LocalPlayer.ActorNumber.ToString());
    }

    public void EndOfRound()
    {
        Debug.Log("EIGENSE VIEW ID:" + PhotonNetwork.LocalPlayer.ActorNumber);
        this.photonView.RPC("RequestPlayerAnswer", RpcTarget.Others);
    }

    [PunRPC]
    public void SendNewRoundData(string _question, string _answer)
    {
        
        question = _question;
        correct_answer = _answer;
        roundStatus = 0;
    }

    public void NewRound()
    {
        int questionID = UnityEngine.Random.Range(0, 4);
        question = QuestionList[questionID];
        correct_answer = AnswerList[questionID];
        this.photonView.RPC("SendNewRoundData", RpcTarget.Others, question, answer);
    }


    List<string> QuestionList = new List<string>{
        "How many inhabitants does Germany have?",
        "How many inhabitants under the age of 20 does Germany have?",
        "How many inhabitants does Austria have?",
        "How many people live in Berlin (Germany)?"};

    List<string> AnswerList = new List<string> {
            "Germany has 83.240.000 inhabitants.",
            "Germany has 15.430.000 inhabitants under the age of 20.",
            "Austria has 9.073.648 inhabitants.",
            "3.677.472 people live in Berlin (Germany)." };

    /*private static List<string> GetQuestions()
    {
        return new List<string>{
        "How many inhabitants does Germany have?",
        "How many inhabitants under the age of 20 does Germany have?",
        "How many inhabitants does Austria have?",
        "How many people live in Berlin (Germany)?"};
    }
    private static List<string> GetAnswers()
    {
        return new List<string> {
            "Germany has 83.240.000 inhabitants.",
            "Germany has 15.430.000 inhabitants under the age of 20.",
            "Austria has 9.073.648 inhabitants.",
            "3.677.472 people live in Berlin (Germany)." };
    }*/
}
