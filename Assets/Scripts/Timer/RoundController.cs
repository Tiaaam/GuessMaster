using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class RoundController : MonoBehaviour
{
    private int currentround = 1;
    private int numberofrounds = 3;
    private int questionCount = 0;
    private float currentTime = 0f;
    private float startingTime = 10;
    private float answerTime = 5f;
    private bool isOver = false;

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
    private GameObject questionPanel;
    [SerializeField]
    private GameObject answerPanel;
    [SerializeField]
    private GameObject finalPanel;

    private bool questionScreen_Showed = false;
    private bool answerScreen_Showed = false;

    void Start()
    {
        finalPanel.SetActive(false);
        PhotonNetwork.CurrentRoom.IsOpen = false;
        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("NumberOfRounds"))
        {
            numberofrounds = (int)PhotonNetwork.CurrentRoom.CustomProperties["NumberOfRounds"];
        }

        if (PhotonNetwork.CurrentRoom.CustomProperties.ContainsKey("NumberOfSeconds"))
        {
            startingTime = (int)PhotonNetwork.CurrentRoom.CustomProperties["NumberOfSeconds"];
        }
        currentTime = startingTime;
        answerPanel.SetActive(false);
        if (!PhotonNetwork.IsMasterClient) currentround = 0;
        else this.gameObject.GetComponent<GameSetupController>().NewRound(0);
    }

    void Update()
    {
        if (PhotonNetwork.IsMasterClient && !isOver) 
        {
            currentTime -= 1 * Time.deltaTime;
            updateTimer();

            if (currentTime <= 0 && questionPanel.activeSelf)
            {
                this.gameObject.GetComponent<GameSetupController>().EndOfRound();
                showAnswerPanel();
            }

            if (questionCount == numberofrounds)
            {
                questionCount = 0;
                this.gameObject.GetComponent<GameSetupController>().EndOfGame();
                showFinalPanel();
                currentround = 1;
                isOver = true;
            }

            if (currentTime <= -answerTime)
            {
                Debug.Log("SHOW QUESTION PANEL" + currentround);
                this.gameObject.GetComponent<GameSetupController>().NewRound(currentround);
                showQuestionPanel();
            }

            
        }
        else if(!isOver)
        {
            if (currentTime >= 0) currentTime -= 1 * Time.deltaTime;
            updateTimer();
            if (GameSetupController.isOver)
            {
                showFinalPanel();
            }

            if (GameSetupController.roundStatus == 0 && !answerScreen_Showed)
            {
                answerScreen_Showed = true;
                questionScreen_Showed = false;
                showQuestionPanel();
            }
            else if (GameSetupController.roundStatus == 1 && !questionScreen_Showed)
            {
                questionScreen_Showed = true;
                answerScreen_Showed = false;
                showAnswerPanel();
            }
            
        }
        questionText.text = GameSetupController.question;
        answerText.text = GameSetupController.correct_answer;
        roundText.text = $"Round {currentround}/{numberofrounds}";
    }

    private void updateTimer()
    {
        countdownText.text = $"{((int)currentTime / 60).ToString("00")}:{((int)currentTime % 60).ToString("00")}";
        uiFill.fillAmount = Mathf.InverseLerp(0, startingTime, currentTime);
    }

    private void showAnswerPanel()
    {
        answerPanel.SetActive(true);
        questionPanel.SetActive(false);
    }

    private void showQuestionPanel()
    {
        answerPanel.SetActive(false);
        questionPanel.SetActive(true);
        currentround++;
        questionCount++;
        currentTime = startingTime;
    }

    private void showFinalPanel()
    {
        finalPanel.SetActive(true);
        GameSetupController.isOver = false;
    }


}
