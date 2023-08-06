using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Script yang diberikan text UI total score di akhir permainan quiz
/// </summary>
public class UI_TotalScore : MonoBehaviour
{
    [SerializeField] private PlayerDataScriptableObject _playerData;
    [SerializeField] private TextMeshProUGUI _totalScoreText;

    private void OnEnable()
    {
        _totalScoreText.text = _playerData.Data.totalScore.ToString();
    }
}
