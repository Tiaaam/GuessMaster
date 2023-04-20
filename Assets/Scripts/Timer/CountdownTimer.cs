using System.Collections;
using System.Collections.Generic;
using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CountdownTimer : MonoBehaviour
{
    int currentround = 1;
    int numberofrounds = (int)PhotonNetwork.CurrentRoom.CustomProperties["NumberOfRounds"];
    int questionCount = 0;
    float currentTime = 0f;
    float startingTime = (int)PhotonNetwork.CurrentRoom.CustomProperties["NumberOfSeconds"];
    float answerTime = 5f;

    [SerializeField]
    private TextMeshProUGUI countdownText;
    [SerializeField]
    private TextMeshProUGUI questionText;
    [SerializeField]
    private TextMeshProUGUI answerText;
    [SerializeField]
    private Image uiFill;
    [SerializeField]
    private TextMeshProUGUI roundText;
    [SerializeField]
    private GameObject HideWhenAnswerShows;
    [SerializeField]
    private GameObject HideWhenQuestionShows;

    private List<string> questions;
    private List<string> answers;

    void Start()
    {
        currentTime = startingTime;
        HideWhenQuestionShows.SetActive(false);

        //questions = GetQuestions();
        //answers = GetAnswers();
    }

    void Update()
    {
        if (PhotonNetwork.IsMasterClient) 
        {
            currentTime -= 1 * Time.deltaTime;
            countdownText.text = $"{((int)currentTime / 60).ToString("00")}:{((int)currentTime % 60).ToString("00")}";

            uiFill.fillAmount = Mathf.InverseLerp(0, startingTime, currentTime);

            if (currentTime <= 0 && HideWhenAnswerShows.activeSelf)
            {
                Debug.Log("RESULT SCREEN");
                HideWhenQuestionShows.SetActive(true);
                HideWhenAnswerShows.SetActive(false);
            }

            if (currentTime <= -answerTime)
            {
                Debug.Log("GIVE ANSWER SCREEN");
                this.gameObject.GetComponent<GameSetupController>().NewRound();
                HideWhenQuestionShows.SetActive(false);
                HideWhenAnswerShows.SetActive(true);
                currentround++;
                questionCount++;
                currentTime = startingTime;

            }

            if (questionCount == numberofrounds)
            {
                Debug.Log("ENDE ALLE FRAGEN DURCH");
                questionCount = 0;
                currentround = 1;
            }

            questionText.text = GameSetupController.question;
            answerText.text = GameSetupController.correct_answer;
            roundText.text = $"Round {currentround}/{numberofrounds}";
        }
        else
        {
            if (currentTime >= 0) currentTime -= 1 * Time.deltaTime;
            countdownText.text = $"{((int)currentTime / 60).ToString("00")}:{((int)currentTime % 60).ToString("00")}";

            uiFill.fillAmount = Mathf.InverseLerp(0, startingTime, currentTime);

            if (GameSetupController.roundStatus == 0)
            {
                    Debug.Log("GIVE ANSWER SCREEN");
                    HideWhenQuestionShows.SetActive(false);
                    HideWhenAnswerShows.SetActive(true);
                    currentround++;
                    questionCount++;
                    currentTime = startingTime;
            }
            else if (GameSetupController.roundStatus == 1)
            {
                Debug.Log("RESULT SCREEN");
                HideWhenQuestionShows.SetActive(true);
                HideWhenAnswerShows.SetActive(false);
            }

            questionText.text = GameSetupController.question;
            answerText.text = GameSetupController.correct_answer;
            roundText.text = $"Round {currentround}/{numberofrounds}";
        }





        /*currentTime -= 1 * Time.deltaTime;
            countdownText.text = $"{((int)currentTime / 60).ToString("00")}:{((int)currentTime % 60).ToString("00")}";

            uiFill.fillAmount = Mathf.InverseLerp(0, startingTime, currentTime);

            if (currentTime <= 0 && HideWhenAnswerShows.activeSelf)
            {
                Debug.Log("RESULT SCREEN");
                HideWhenQuestionShows.SetActive(true);
                HideWhenAnswerShows.SetActive(false);
            }

            if (currentTime <= -answerTime)
            {
                Debug.Log("GIVE ANSWER SCREEN");
                HideWhenQuestionShows.SetActive(false);
                HideWhenAnswerShows.SetActive(true);
                currentround++;
                questionCount++;
                currentTime = startingTime;

            }

            if (questionCount == numberofrounds)
            {
                Debug.Log("ENDE ALLE FRAGEN DURCH");
                questionCount = 0;
                currentround = 1;
            }

            questionText.text = GameSetupController.question;
            answerText.text = answers[questionCount];
            roundText.text = $"Round {currentround}/{numberofrounds}";*/
    }



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
