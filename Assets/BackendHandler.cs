using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PlayFab;
using PlayFab.ClientModels;
using Newtonsoft.Json;

public class BackendHandler : MonoBehaviour
{

    protected bool isDataAvailable = false;
    protected bool isDataSaved = false;
    protected string savedData = "";

    private void Awake()
    {
        isDataSaved = false;
    }

    public virtual void OnError(PlayFabError error)
    {
#if UNITY_EDITOR
        Debug.Log(error.GenerateErrorReport());
#endif
    }

    protected void OnSavedDataSend(UpdateUserDataResult result)
    {
#if UNITY_EDITOR
        Debug.Log("Succesful data send!");
#endif
        isDataAvailable = false;
        isDataSaved = true;
    }

    public void OnSaveData<T>(List<T> data, string dataTypeInString) where T:struct
    {
        var request = new UpdateUserDataRequest
        {
            Data = new Dictionary<string, string> {
                            { dataTypeInString, JsonConvert.SerializeObject(data) }
                        },
            Permission = UserDataPermission.Public
        };
        PlayFabClientAPI.UpdateUserData(request, OnSavedDataSend, OnError);
    }

    public void OnLoadData<T>(GetUserDataResult result, out List<T> data, string dataTypeInString) where T:struct
    {
        data = JsonConvert.DeserializeObject<List<T>>(result.Data[dataTypeInString].Value);
    }

}
