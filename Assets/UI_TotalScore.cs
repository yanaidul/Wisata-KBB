using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_TotalScore : MonoBehaviour
{
    [SerializeField] private PlayerDataScriptableObject _playerData;
    [SerializeField] private TextMeshProUGUI _totalScoreText;

    private void OnEnable()
    {
        _totalScoreText.text = _playerData.Data.totalScore.ToString();
    }
}
