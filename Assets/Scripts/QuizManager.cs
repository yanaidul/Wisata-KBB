using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuizManager : Singleton<QuizManager>
{
    [Header("SO")]
    [SerializeField] private PlayerDataScriptableObject _playerData;
    [Header("Variables")]
    [SerializeField] private int _currentScore;
    [SerializeField] private int _correctAnswerScore;
    [SerializeField] private int _incorrectAnswerScore;
    [Header("Questions Gameobject")]
    [SerializeField] private GameObject[] _questions;
    [Header("Result Panel")]
    [SerializeField] private GameObject _resultPanel;
    [SerializeField] private GameObject _totalScoreResultPanel;
    [Header("Pop Up")]
    [SerializeField] private GameObject _correctPopup;
    [SerializeField] private GameObject _incorrectPopup;
    [Header("Events")]
    [SerializeField] private GameEventNoParam _onChangeScoreText;

    private int _currentQuizQuestionIndex;


    #region Properties
    public int CurrentScore
    {
        get => _currentScore;

        set
        {
            _currentScore = value;
            if (_currentScore <= 0)
            {
                _currentScore = 0;
            }
        }
    }
    public int CurrentQuizQuestionIndex
    {
        get => _currentQuizQuestionIndex;

        set
        {
            _currentQuizQuestionIndex = value;
            if (_currentQuizQuestionIndex > _questions.Length)
            {
                _currentQuizQuestionIndex = _questions.Length;
            }
        }
    }
    #endregion

    private void OnEnable()
    {
        if (_playerData.Data.quizTries != 0)
        {
            RestartQuiz();
        }
        else _totalScoreResultPanel.SetActive(true);
    }

    public void RestartQuiz()
    {
        if (_playerData.Data.quizTries != 0)
        {
            _resultPanel.SetActive(false);
            _totalScoreResultPanel.SetActive(false);
            CurrentScore = 0;
            CurrentQuizQuestionIndex = 0;
            UpdateQuizState();
            _onChangeScoreText.Raise();
        }
        else _totalScoreResultPanel.SetActive(true);
    }

    public void OnClickCorrectAnswer()
    {
        CurrentScore += _correctAnswerScore;
        CurrentQuizQuestionIndex++;
        _correctPopup.SetActive(true);
        StartCoroutine(DelayUpdateQuizState(_correctPopup));
    }

    public void OnClickIncorrectAnswer()
    {
        CurrentScore -= _incorrectAnswerScore;
        CurrentQuizQuestionIndex++;
        _incorrectPopup.SetActive(true);
        StartCoroutine(DelayUpdateQuizState(_incorrectPopup));
    }

    private void UpdateQuizState()
    {
        int questionLength = _questions.Length;
        for (int i = 0; i < questionLength; i++)
        {
            if (i == CurrentQuizQuestionIndex)
            {
                _questions[i].SetActive(true);
            }
            else _questions[i].SetActive(false);
        }

        if(CurrentQuizQuestionIndex >= questionLength)
        {
            _playerData.DecreaseQuizTries();
            _playerData.IncreasePlayerTotalScore(_currentScore);
            _resultPanel.SetActive(true);
        }
    }

    IEnumerator DelayUpdateQuizState(GameObject popup)
    {
        yield return new WaitForSeconds(2f);
        popup.SetActive(false);
        UpdateQuizState();
        _onChangeScoreText.Raise();
    }
}
