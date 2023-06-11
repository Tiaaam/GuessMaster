using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsSlider : MonoBehaviour
{
    [SerializeField] private Slider playerSlider;
    [SerializeField] private Slider roundSlider;
    [SerializeField] private Slider timeSlider;
    [SerializeField] private TextMeshProUGUI numberOfPlayers;
    [SerializeField] private TextMeshProUGUI numberOfRounds;
    [SerializeField] private TextMeshProUGUI numberOfSeconds;

    void Start()
    {
        playerSlider.onValueChanged.AddListener((number) => {
            numberOfPlayers.text = number.ToString("0");
        });
        roundSlider.onValueChanged.AddListener((number) => {
            numberOfRounds.text = number.ToString("0");
        });
        timeSlider.onValueChanged.AddListener((number) => {
            numberOfSeconds.text = (number*5).ToString("0");
        });
    }
}
