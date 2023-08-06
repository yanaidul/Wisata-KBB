using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/// <summary>
/// Script yang diberikan pada text percobaan quiz agar jumlah percobaannya bisa di update sesuai dengan percobaan quiz yang tersisa
/// </summary>
[RequireComponent(typeof(TextMeshProUGUI))]
public class UI_PercobaanQuizText : MonoBehaviour
{
    [SerializeField] private PlayerDataScriptableObject _playerData;

    private TextMeshProUGUI _quizTriesText;

    private void Awake()
    {
        if (!TryGetComponent<TextMeshProUGUI>(out TextMeshProUGUI text)) return;
        _quizTriesText = text;
    }

    private void OnEnable()
    {
        _quizTriesText.text = $"Kamu memiliki {_playerData.Data.quizTries}x Percobaan memainkan quiz.";
    }
}
