using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ResultButtonUI : MonoBehaviour
{
    [SerializeField]
    private Button _retryButton;
    [SerializeField]
    private Button _continueButton;

    public TMP_Text Score;
    private void Start()
    {
        _retryButton.onClick.AddListener(OnRetryButtonClicked);
        _continueButton.onClick.AddListener(OnContinueButtonClicked);
        Score.text = "Final Score : " + InGameCommander.score;
    }

    private void OnRetryButtonClicked()
    {
        Managers.Game.setState(GameManager.GameState.InGame);
    }
    private void OnContinueButtonClicked()
    {
        Managers.Game.setState(GameManager.GameState.Title);
    }
}
