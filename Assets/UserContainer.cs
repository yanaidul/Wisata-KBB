using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UserContainer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _noAbsen;
    [SerializeField] private TextMeshProUGUI _name;
    [SerializeField] private Slider _progress;
    [SerializeField] private TextMeshProUGUI _progressText;
    [SerializeField] private TextMeshProUGUI _time;
    [SerializeField] private TextMeshProUGUI _totalScore;

    public void SetNewDataToUserContainer(int noabsen,string name,int value, string time, int score)
    {
        _noAbsen.text = noabsen.ToString();
        _name.text = name;
        _progress.value = value;
        _progressText.text = $"{_progress.value}%";
        _time.text = time;
        _totalScore.text = score.ToString();
    }
}
