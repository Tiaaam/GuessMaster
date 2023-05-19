using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using System;
using System.Threading.Tasks;
using UnityEditor;

public class GameSetupController : MonoBehaviourPunCallbacks
{
    public static int roundStatus = 0;
    public static string question = "TestQuestion";
    public static string correct_answer = "AnswerQuestion";
    private GameObject myplayer;
    public string answer;

    //
    private List<string> playerAnswerList;
    List<string> AnswerList = new List<string>();
    List<string> QuestionList = new List<string>();
    private static readonly System.Random rand = new System.Random();



    void Start()
    {
        Debug.Log("EIGENSE VIEW ID:" + PhotonNetwork.LocalPlayer.ActorNumber);
        GenerateQuestionsAndAnswersInhabitants(AnswerList, QuestionList, 5);
        answer = "this is an answer";
        //TextAsset csvFile = Resources.Load<TextAsset>("DataTables/german_cities_area_questions_12_01_2022");
        //Debug.Log(csvFile.text);
    }

    public void SendDataToPrefab()
    {
        EndOfRound();
    }

    public static bool numberExists(int[] arr, int n)
    {
        if (arr.Length == 0)
        {
            return false;
        }

        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == n) return true;
        }

        return false;
    }

    public static void GenerateQuestionsAndAnswersInhabitants(List<string> _l1, List<string> _l2, int _rounds)
    {
        //string path1 = "C:\\Users\\Marius\\Documents\\GitHub\\GuessMaster---Questions\\data\\questions\\german_cities_inhabitants_questions_12_01_2022.csv";
        //string[] lines_inhabitants = File.ReadAllLines(path1);
        TextAsset csvFile = Resources.Load<TextAsset>("DataTables/german_cities_inhabitants_questions_12_01_2022");
        string[] lines_inhabitants = csvFile.text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);
        Debug.Log(lines_inhabitants.Length);
        Debug.Log(lines_inhabitants[0]);
        Debug.Log(lines_inhabitants[5]);

        int row = 0;
        //Both strings have the same amaount of lines
        int max = lines_inhabitants.Length;

        int[] rows1 = new int[_rounds];

        for (int i = 0; i < _rounds; i++)
        {
            row = rand.Next(1, max);

            while (numberExists(rows1, row))
            {
                row = rand.Next(1, max);
            }

            rows1[i] = row;
            string[] splitArray = lines_inhabitants[row].Split(',');
            _l1.Add(splitArray[0]);
            _l2.Add(splitArray[1]);
        }
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
        playerAnswerList[int.Parse(_playerID)] = _answer;

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

    public void NewRound(int roundId)
    {
        question = QuestionList[roundId];
        correct_answer = AnswerList[roundId];
        this.photonView.RPC("SendNewRoundData", RpcTarget.Others, question, correct_answer);
    }


}
