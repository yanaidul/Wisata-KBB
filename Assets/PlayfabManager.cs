using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Newtonsoft.Json;
using PlayFab;
using PlayFab.ClientModels;
using System;

public class PlayfabManager : BackendHandler
{
    [Header("PlayerData")]
    [SerializeField] private PlayerDataScriptableObject _playerData;
    [Header("UI")]
    [SerializeField] private TMP_InputField _nameInput;
    [SerializeField] private TMP_InputField _noAbsenInput;
    [Header("Gameobject Reference")]
    [SerializeField] private GameObject _uiLogin;
    [SerializeField] private GameObject _container;
    [Header("Playfab ID Container Prefab")]
    [SerializeField] private GameObject _userPrefab;
    [Header("Playfab ID List")]
    [SerializeField] private List<string> _playFabIdList = new List<String>();

    private List<PlayerDataScriptableObject.PlayerDataStructure> _dataStructList = new List<PlayerDataScriptableObject.PlayerDataStructure>();
    private PlayerDataScriptableObject _tempList;
    private int _noAbsen = 1;

    #region Properties
    public List<PlayerDataScriptableObject.PlayerDataStructure> DataStructList => _dataStructList;
    #endregion


    #region Login/Register
    public void RegisterButton()
    {
        string makeUsernameNoDot = _nameInput.text.Replace(".", "");
        string makeUsernameNoSpace = makeUsernameNoDot.Replace(" ", "");
        string validUsername = CutStringIfLong(makeUsernameNoSpace, 20); ;

        string validPassword = _noAbsenInput.text;
        var request = new RegisterPlayFabUserRequest
        {
            Username = validUsername,
            Password = validPassword,
            RequireBothUsernameAndEmail = false
        };

        PlayFabClientAPI.RegisterPlayFabUser(request, OnRegisterSuccess, OnError);
    }

    public void LoginButton()
    {
        string makeUsernameNoDot = _nameInput.text.Replace(".", "");
        string makeUsernameNoSpace = makeUsernameNoDot.Replace(" ", "");
        string validUsername = CutStringIfLong(makeUsernameNoSpace, 20); ;
        string validPassword = _noAbsenInput.text;
        var request = new LoginWithPlayFabRequest
        {
            Username = validUsername,
            Password = validPassword
        };

        PlayFabClientAPI.LoginWithPlayFab(request, OnLoginSuccess, OnError);
    }

    private void OnRegisterSuccess(RegisterPlayFabUserResult result)
    {
        _playerData.SetPlayerUsername(_nameInput.text);
        _playerData.SetQuizTries(5);
        SavePlayerData();
        Debug.Log("Register success");
    }

    private void OnLoginSuccess(LoginResult result)
    {
        if (_nameInput.text == "adminaccess")
        {
            CanvasManager.GetInstance().SwitchCanvas(CanvasType.Admin);
            GetLeaderboard();
        }
        else
        {
            _playerData.ResetData();
            _playerData.SetPlayerUsername(_nameInput.text);
            _playerData.SetLastTImeLogin(GetCurrentTimeWithFormat());
            LoadPlayerData();
            SendLeaderboard();
            CanvasManager.GetInstance().SwitchCanvas(CanvasType.MainMenu);
            Debug.Log("Login success");
        }

    }
    #endregion

    #region Save/Load Player Data

    private void SavePlayerData()
    {
        Debug.Log("Wait Data Save Start");
        StartCoroutine(WaitForDataSave());
    }
    public void LoadPlayerData()
    {
        Debug.Log("Wait Data Start");
        StartCoroutine(WaitForDataLoad());
    }


    void OnPlayerDataRecieved(GetUserDataResult result)
    {
        OnLoadData(result, out _dataStructList, "Player Data");
        isDataAvailable = true;
        foreach (var item in _dataStructList)
        {
            _playerData.Init(item);
#if UNITY_EDITOR
            Debug.Log(item.username + " " + item.totalScore + " " + item.sejarahProgression + " " +
                item.pengertianProgression + " " + item.wisataAlamProgression + " " + item.wisataBuatanProgression + " " +
                item.wisataSenbudProgression);
#endif
        }
    }

    public void SendLeaderboard()
    {
        var request = new UpdatePlayerStatisticsRequest
        {
            Statistics = new List<StatisticUpdate>
            {
                new StatisticUpdate
                {
                    StatisticName = "PlayerData",
                    Value = 0
                }
            }
        };

        PlayFabClientAPI.UpdatePlayerStatistics(request, OnLeaderboardUpdate, OnError);
    }

    void OnLeaderboardUpdate(UpdatePlayerStatisticsResult result)
    {
#if UNITY_EDITOR
        Debug.Log("Successfull leaderboard sent!");
#endif
        //_scoreManager.scores.Clear();
        //GetLeaderboard(); //ambil data leaderboard di playfab setelah score player update
        //_scoreManager.SortScoresData(); //ambil data leaderboard di playfab setelah score player update
    }

    public void GetLeaderboard()
    {
        var request = new GetLeaderboardRequest
        {
            StatisticName = "PlayerData",
            StartPosition = 0,
            MaxResultsCount = 30
        };
        PlayFabClientAPI.GetLeaderboard(request, OnLeaderboardGet, OnError);
    }

    void OnLeaderboardGet(GetLeaderboardResult result)
    {
        foreach (var item in result.Leaderboard)
        {
#if UNITY_EDITOR
            Debug.Log("All Player ID " + item.PlayFabId);
#endif
            _playFabIdList.Add(item.PlayFabId);
        }

        GetPlayerData();
    }

    private void GetPlayerData()
    {
        _noAbsen = 1;
        for (int i = 0; i < _playFabIdList.Count; i++)
        {
            var request = new GetUserDataRequest
            {
                PlayFabId = _playFabIdList[i],
            };

            //var request = new GetUserDataRequest()

            PlayFabClientAPI.GetUserData(request, OnDataReceived, OnError);
        }

    }

    private void OnDataReceived(GetUserDataResult result)
    {
        OnLoadData(result, out _dataStructList, "Player Data");

        if (result.Data.ContainsKey("Player Data"))
        {
            foreach (var item in _dataStructList)
            {
                GameObject userContainer = Instantiate(_userPrefab, _container.transform);
                int _totalProgression = (item.sejarahProgression + item.pengertianProgression +
                                        item.wisataAlamProgression + item.wisataBuatanProgression +
                                        item.wisataSenbudProgression);
                int _convertToPercentage = (_totalProgression * 100) / (100 * 5);
                userContainer.GetComponent<UserContainer>().SetNewDataToUserContainer(_noAbsen, item.username, _convertToPercentage, item.lastTimeLogin,item.totalScore);
#if UNITY_EDITOR
                Debug.Log(item.username);
#endif
            }
            _noAbsen++;
        }
        else
        {
            Debug.Log("Player data not found for the player.");
        }
    }

    private IEnumerator WaitForDataLoad()
    {
        while (!isDataAvailable)
        {
            Debug.Log("Wait Data On Progress");
            PlayFabClientAPI.GetUserData(new GetUserDataRequest(), OnPlayerDataRecieved, OnError);

            yield return new WaitForSeconds(2f);
        }
    }

    private IEnumerator WaitForDataSave()
    {
        while (!isDataSaved)
        {
            _tempList = _playerData;
            DataStructList.Clear();
            DataStructList.Add(_playerData.Data);
            OnSaveData(DataStructList, "Player Data");
            yield return new WaitForSeconds(2f);
        }
    }
    #endregion

    private void OnApplicationQuit()
    {
        Debug.Log("Player exit the app");
        SavePlayerData();
    }

    string CutStringIfLong(string originalString, int maxLength)
    {
        if (originalString.Length > maxLength)
        {
            return originalString.Substring(0, maxLength);
        }

        return originalString;
    }

    string GetCurrentTimeWithFormat()
    {
        DateTime now = DateTime.Now;
        string currentTime = now.ToString("HH:mm");
        return currentTime;
    }
}
