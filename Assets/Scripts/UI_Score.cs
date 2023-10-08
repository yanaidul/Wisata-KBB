using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UI_Score : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _scoreText;

    private QuizManager _quizManager;

    private void Start()
    {
        _quizManager = QuizManager.GetInstance();
    }

    public void OnChangeScoreText()
    {
        if(_quizManager != null) _scoreText.text = _quizManager.CurrentScore.ToString();
        else _scoreText.text = QuizManager.GetInstance().CurrentScore.ToString();
    }
}
