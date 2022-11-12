using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{


    int questionCount = 0;

    float currentTime = 0f;
    float startingTime = 63f;

    public TextMeshProUGUI countdownText;

    public TextMeshProUGUI questionText;

    public Image uiFill;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {


        var questions = GetQuestions();


        currentTime -= 1 * Time.deltaTime;
        // countdownText.text = currentTime.ToString("0");
        countdownText.text = $"{((int)currentTime / 60).ToString("00")}:{((int)currentTime % 60).ToString("00")}";

        uiFill.fillAmount = Mathf.InverseLerp(0, startingTime, currentTime);

        if (currentTime <= 0)
        {
            questionCount++;
            currentTime = startingTime;
        }

        if (questionCount == 4)
        {
            questionCount = 0;
        }


        questionText.text = questions[questionCount];
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
