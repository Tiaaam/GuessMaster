using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using System.IO;
using System;
using System.Threading.Tasks;
using UnityEditor;
using System.Linq;
using UnityEngine.UI;
using TMPro;
using Photon.Realtime;
using ExitGames.Client.Photon;

public class GameSetupController : MonoBehaviourPunCallbacks
{
    public static int roundStatus = 0;
    public static bool isOver = false;
    public static string question = "TestQuestion";
    public static string correct_answer = "AnswerQuestion";
    [SerializeField]
    private TMP_InputField AnswerField;
    [SerializeField]
    private TextMeshProUGUI SubmittedAnswerField;
    private float answer;


    //
    private List<float> playerAnswerList = new List<float>();
    private List<int> playerAnswerOrder = new List<int>();
    List<string> AnswerList = new List<string>();
    List<string> QuestionList = new List<string>();
    private static readonly System.Random rand = new System.Random();



    void Start()
    {
        Debug.Log("EIGENSE VIEW ID:" + PhotonNetwork.LocalPlayer.ActorNumber);
        GenerateQuestionsAndAnswersInhabitants(AnswerList, QuestionList, 5);
        answer = 100000000;
        SubmittedAnswerField.text = "";
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
        TextAsset csvFile = Resources.Load<TextAsset>("DataTables/german_cities_inhabitants_questions_12_01_2022");
        string[] lines_inhabitants = csvFile.text.Split(new string[] { Environment.NewLine }, StringSplitOptions.None);

        int row = 0;
        int max = lines_inhabitants.Length;

        int[] rows1 = new int[_rounds+1];

        for (int i = 0; i < _rounds+1; i++)
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

        Debug.Log(_l2[0] + " " + _l2[1] );
    }
    void CompareAnswers()
    {
        //Liste sortieren -> ID sagt welcher Spieler welchen Platz hat -> Punkte vergeben
        int list_len = playerAnswerList.Count;
        Debug.Log("Antworten Vergleich Listenlaenge:" + playerAnswerList.Count);
        //playerAnswerList.Sort();
        //Debug.Log("Sorted List:" + playerAnswerList);
        for (int i = 0; i < list_len;  i++)
        {
            float max = playerAnswerList[0];
            int index = 0;
            for (int j = 1; j < playerAnswerList.Count; j++)
            {
                if(max <= playerAnswerList[j])
                {
                    max = playerAnswerList[j];
                    index = j;
                }
            }

            Debug.Log("SpielerIndex: " + playerAnswerOrder[index] + " bekommt " + i+1 + " Punkte.");

            //Spieler playerAnswerOrder[index] bekommt i punkte
            savePlayerData(playerAnswerOrder[index], playerAnswerList[index].ToString(), i+1);


            playerAnswerList.RemoveAt(index);
            playerAnswerOrder.RemoveAt(index);
        }
        givePlayerRanking();
    }


    [PunRPC]
    public void SendPlayerAnswer(float _answer, int _playerID) //Wird beim Master aufgerufen von jedem Spieler
    {
        Debug.Log(_answer + _playerID);
        //playerAnswerList[int.Parse(_playerID)] = _answer;
        playerAnswerOrder.Add(_playerID);
        playerAnswerList.Add(_answer);
    }

    [PunRPC]
    public void RequestPlayerAnswer() //Wird bei jeden Spieler von Master aufgerufen
    {
        roundStatus = 1;
        Debug.Log(PhotonNetwork.LocalPlayer.ActorNumber.ToString());
        this.photonView.RPC("SendPlayerAnswer", RpcTarget.MasterClient, answer, PhotonNetwork.LocalPlayer.ActorNumber);
    }

    public void EndOfRound()
    {
        //Debug.Log("EIGENSE VIEW ID:" + PhotonNetwork.LocalPlayer.ActorNumber);
        playerAnswerOrder.Add(PhotonNetwork.LocalPlayer.ActorNumber);
        playerAnswerList.Add(answer);
        this.photonView.RPC("RequestPlayerAnswer", RpcTarget.Others);
        Debug.Log("Kurze Pause");
        Invoke("CompareAnswers", 2.0f); //Wartet 2 Sekunden bevor Funktion aufgerufen wird
    }

    [PunRPC]
    public void SendNewRoundData(string _question, string _answer)
    {
        question = _question;
        correct_answer = _answer;
        answer = 100000000;
        SubmittedAnswerField.text = "";
        roundStatus = 0;
    }

    public void EndOfGame()
    {
        this.photonView.RPC("showFinalScreen", RpcTarget.Others);
        
    }

    [PunRPC]
    public void showFinalScreen()
    {
        isOver = true;
    }


    public void NewRound(int roundId)
    {
        Debug.Log(roundId + "NEW ROUND ID");
        question = QuestionList[roundId];
        correct_answer = AnswerList[roundId];
        playerAnswerOrder.Clear();
        playerAnswerList.Clear();
        answer = 100000000;
        SubmittedAnswerField.text = "";
        this.photonView.RPC("SendNewRoundData", RpcTarget.Others, question, correct_answer);
    }

    public void SubmitAnswer()
    {
        string input = AnswerField.text;
        try
        {
            answer = Math.Abs(float.Parse(correct_answer) - float.Parse(input));
            Debug.Log("Answer Submitted Successfully: " + input);
            SubmittedAnswerField.text = "Your Guess: " + input;
        }
        catch (Exception e)
        {
            Debug.Log("Invalid Input");
        }
        AnswerField.text = "";
        
    }

    public void savePlayerData(int actorID, string answer, int score)
    {
        foreach (Player player in PhotonNetwork.PlayerList)
        {
            if(player.ActorNumber == actorID)
            {
                var hash = player.CustomProperties;
                hash["Score"] = score + (int)hash["Score"];
                hash["Answer"] = answer;
                player.SetCustomProperties(hash);
            }
        }
    }

    public void givePlayerRanking()
    {
        int previousScore = 0;
        int rank = 1;
        List<Player> listing = new List<Player>();


        foreach (Player player in PhotonNetwork.PlayerList)
        {
            listing.Add(player);
        }


        List<Player> sortedList = listing.OrderBy(p => p.CustomProperties["Score"]).ToList();
        sortedList.Reverse();

        foreach (Player player in sortedList)
        {
            var hash = player.CustomProperties;
            hash["Rank"] = rank;
            if(previousScore != (int)hash["Score"])
            {
                rank++;
            }
            player.SetCustomProperties(hash);
        }
    }
}
