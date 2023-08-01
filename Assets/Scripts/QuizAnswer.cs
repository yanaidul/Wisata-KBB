using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum AnswerType
{
    Correct,
    Incorrect
}

[RequireComponent(typeof(Button))]
public class QuizAnswer : MonoBehaviour
{
    [SerializeField] private AnswerType _answerType;

    private Button _button;
    private QuizManager _quizManager;

    private void Awake()
    {
        if (!TryGetComponent<Button>(out Button button)) return;
        _button = button;
    }

    private void Start()
    {
        _quizManager = QuizManager.GetInstance();
        switch(_answerType)
        {
            case AnswerType.Correct:
                _button.onClick.AddListener(_quizManager.OnClickCorrectAnswer);
                break;
            case AnswerType.Incorrect:
                _button.onClick.AddListener(_quizManager.OnClickIncorrectAnswer);
                break;
            default:
                Debug.LogWarning("No Answer Type Found");
                break;
        }
    }
}
