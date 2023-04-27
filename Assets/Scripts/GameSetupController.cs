using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using System;
using System.Threading.Tasks;

public class GameSetupController : MonoBehaviourPunCallbacks
{
    public static int roundStatus = 0;
    public static string question = "TestQuestion";
    public static string correct_answer = "AnswerQuestion";
    private GameObject myplayer;
    public string answer;

    private List<string> answerList;
    //private string[][] answerList;
    void Start()
    {
        answer = "this is an answer";
        //TextAsset csvFile = Resources.Load<TextAsset>("DataTables/german_cities_area_questions_12_01_2022");
        //Debug.Log(csvFile.text);
    }

    public void SendDataToPrefab()
    {
        EndOfRound();
    }

    private void CompareAnswers()
    {
        //Liste sortieren -> ID sagt welcher Spieler welchen Platz hat -> Punkte vergeben
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
        answerList[int.Parse(_playerID)] = _answer;

    }

    [PunRPC]
    public void RequestPlayerAnswer() //Wird bei jeden Spieler von Master aufgerufen
    {
        roundStatus = 1;
        Debug.Log(PhotonNetwork.LocalPlayer.ActorNumber.ToString());
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
        this.photonView.RPC("SendNewRoundData", RpcTarget.Others, question, correct_answer);
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
