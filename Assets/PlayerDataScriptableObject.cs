using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="PlayerData",menuName = "ScriptableObject/PlayerDataScriptableObject")]
[Serializable]
public class PlayerDataScriptableObject : ScriptableObject,IInitializer<PlayerDataScriptableObject.PlayerDataStructure>
{
    [System.Serializable]
    public struct PlayerDataStructure
    {
        public string username;
        public int totalScore;
        public int sejarahProgression;
        public int pengertianProgression;
        public int wisataAlamProgression;
        public int wisataBuatanProgression;
        public int wisataSenbudProgression;
        public int quizTries;
        public string lastTimeLogin;
    }

    [SerializeField] private PlayerDataStructure _data = new PlayerDataStructure();
    public PlayerDataStructure Data => _data;

    public void ResetData()
    {
        _data.username = " ";
        _data.totalScore = 0;
        _data.sejarahProgression = 0;
        _data.pengertianProgression = 0;
        _data.wisataAlamProgression = 0;
        _data.wisataBuatanProgression = 0;
        _data.wisataSenbudProgression = 0;
        _data.quizTries = 5;
        _data.lastTimeLogin = " ";
    }

    public void Init(PlayerDataStructure newData)
    {
        _data = newData;
    }

    public void SetPlayerUsername(string username)
    {
        _data.username = username;
    }

    public void IncreasePlayerTotalScore(int score)
    {
        _data.totalScore += score;
    }

    public void SetPlayerSejarahProgression(int value)
    {
        _data.sejarahProgression = value;
    }
    public void SetPlayerPengertianProgression(int value)
    {
        _data.pengertianProgression = value;
    }
    public void SetPlayerWisataAlamProgression(int value)
    {
        _data.wisataAlamProgression = value;
    }
    public void SetPlayerWisataBuatanProgression(int value)
    {
        _data.wisataBuatanProgression = value;
    }
    public void SetPlayerWisataSenbudProgression(int value)
    {
        _data.wisataSenbudProgression = value;
    }
    public void SetQuizTries(int value)
    {
        _data.quizTries = value;
    }

    public void SetLastTImeLogin(string value)
    {
        _data.lastTimeLogin = value;
    }

    public void DecreaseQuizTries()
    {
        _data.quizTries--;
    }

}
