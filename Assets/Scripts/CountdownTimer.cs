using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{


    int questionCount = 0;

    float currentTime = 0f;
    float startingTime = 10f;

    public TextMeshProUGUI countdownText;

    public TextMeshProUGUI questionText;

    // Start is called before the first frame update
    void Start()
    {
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        

        var questions = new List<string>{
        "How many inhabitants does Germany have?",
        "How many inhabitants under the age of 20 does Germany have?",
        "How many inhabitants does Austria have?",
        "How many people live in Berlin (Germany)?"};


        currentTime -= 1 * Time.deltaTime;
        countdownText.text = currentTime.ToString("0");

        if(currentTime <= 0)
        {
            questionCount++;
            currentTime = 10f;
        }

        if(questionCount == 4)
        {
            questionCount = 0;
        }


        questionText.text = questions[questionCount];
    }
}
