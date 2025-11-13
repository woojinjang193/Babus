using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : Singleton<SaveManager>
{

    private void OnApplicationQuit()
    {
        Debug.Log("세이브 완료");
    }
}
