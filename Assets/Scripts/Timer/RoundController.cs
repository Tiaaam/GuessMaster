using Photon.Pun;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class RoundController : MonoBehaviour
{
    private int currentround = 1;
    private int numberofrounds = (int)PhotonNetwork.CurrentRoom.CustomProperties["NumberOfRounds"];
    private int questionCount = 0;
    private float currentTime = 0f;
    private float startingTime = (int)PhotonNetwork.CurrentRoom.CustomProperties["NumberOfSeconds"];
    private float answerTime = 5f;

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

    private bool questionScreen_Showed = false;
    private bool answerScreen_Showed = false;

    void Start()
    {
        currentTime = startingTime;
        answerPanel.SetActive(false);
        if (!PhotonNetwork.IsMasterClient) currentround = 0;
        else this.gameObject.GetComponent<GameSetupController>().NewRound(0);
    }

    void Update()
    {
        if (PhotonNetwork.IsMasterClient) 
        {
            currentTime -= 1 * Time.deltaTime;
            updateTimer();

            if (currentTime <= 0 && questionPanel.activeSelf)
            {
                this.gameObject.GetComponent<GameSetupController>().EndOfRound();
                showAnswerPanel();
            }

            if (currentTime <= -answerTime)
            {
                Debug.Log("SHOW QUESTION PANEL" + currentround);
                this.gameObject.GetComponent<GameSetupController>().NewRound(currentround - 1);
                showQuestionPanel();
            }

            if (questionCount == numberofrounds)
            {
                questionCount = 0;
                currentround = 1;
            }
        }
        else
        {
            if (currentTime >= 0) currentTime -= 1 * Time.deltaTime;
            updateTimer();

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
    public void savePlayerData(int actorID, string answer, int score)
    {
        PhotonNetwork.CurrentRoom.CustomProperties["answer" + actorID.ToString()] = answer;
        PhotonNetwork.CurrentRoom.CustomProperties["score" + actorID.ToString()] = score;
    }


    private int getPlayerAnswer(int actorID)
    {
        return (int)PhotonNetwork.CurrentRoom.CustomProperties["score" + actorID.ToString()];
    }

    private string getPlayerScore(int actorID)
    {
        return (string)PhotonNetwork.CurrentRoom.CustomProperties["answer" + actorID.ToString()];
    }
}
