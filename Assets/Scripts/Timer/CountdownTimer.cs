using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class CountdownTimer : MonoBehaviour
{
    int currentround = 1;
    int numberofrounds = 4;
    int questionCount = 0;
    float currentTime = 0f;
    float startingTime = 11f;
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

    void Start()
    {
        currentTime = startingTime;
        HideWhenQuestionShows.SetActive(false);
    }

    void Update()
    {
        var questions = GetQuestions();
        var answers = GetAnswers();

        currentTime -= 1 * Time.deltaTime;
        countdownText.text = $"{((int)currentTime / 60).ToString("00")}:{((int)currentTime % 60).ToString("00")}";

        uiFill.fillAmount = Mathf.InverseLerp(0, startingTime, currentTime);

        if (currentTime <= 0 && currentTime >= -answerTime)
        {
            HideWhenQuestionShows.SetActive(true);
            HideWhenAnswerShows.SetActive(false);
        }

        if (currentTime <= -answerTime)
        {
            HideWhenQuestionShows.SetActive(false);
            HideWhenAnswerShows.SetActive(true);
            currentround++;
            questionCount++;
            currentTime = startingTime;
        }

        if (questionCount == numberofrounds)
        {
            questionCount = 0;
            currentround = 1;
        }

        questionText.text = questions[questionCount];
        answerText.text = answers[questionCount];
        roundText.text = $"Round {currentround}/{numberofrounds}";
    }

    private static List<string> GetQuestions()
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
    }
}
