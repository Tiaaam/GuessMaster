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

    public TextMeshProUGUI countdownText;
    public TextMeshProUGUI questionText;
    public Image uiFill;
    public TextMeshProUGUI roundText;

    void Start()
    {
        currentTime = startingTime;
    }

    void Update()
    {
        var questions = GetQuestions();

        currentTime -= 1 * Time.deltaTime;
        countdownText.text = $"{((int)currentTime / 60).ToString("00")}:{((int)currentTime % 60).ToString("00")}";

        uiFill.fillAmount = Mathf.InverseLerp(0, startingTime, currentTime);

        if (currentTime <= 0)
        {
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
}