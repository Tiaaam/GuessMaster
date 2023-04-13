using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SettingsSlider : MonoBehaviour
{

    [SerializeField] private Slider playerSlider;
    [SerializeField] private Slider roundSlider;
    [SerializeField] private TextMeshProUGUI numberOfPlayers;
    [SerializeField] private TextMeshProUGUI numberOfRounds;

    void Start()
    {
        playerSlider.onValueChanged.AddListener((number) => {
            numberOfPlayers.text = number.ToString("0");
        });

        roundSlider.onValueChanged.AddListener((number) => {
            numberOfRounds.text = number.ToString("0");
        });
    }
}
