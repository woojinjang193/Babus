using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    [SerializeField] private BabusConfigSO _config;

    private List<BabusStatus> _babuses = new List<BabusStatus>();
    public List<BabusStatus> Babuses => _babuses;

    private UserData _userData;

    protected override void Awake()
    {
        base.Awake();
        LoadGame();
    }
    private void LoadGame()
    {
        _userData = SaveManager.Load(); //세이브데이터 불러옴 
        if (_userData == null)
        {
            _userData = new UserData(); //세이브데이터 없으면 새로 만듬
        }
        _babuses.Clear();

        // 세이브에 있는 바버스들을 BabusStatus로 변환
        if(_userData.HadBabusList != null && _userData.HadBabusList.Count > 0)
        {
            foreach (var save in _userData.HaveBabusList)
            {
                var id = int.TryParse(save.ID, out var parsed) ? parsed : 0;

                var status = new BabusStatus(id, _config);
                status.SetValues(save.Hunger, save.Health, save.Cleanliness, save.Happiness);
                _babuses.Add(status);
            }
        }
        else
        {
            Debug.Log("바버스 세이브 데이터 없음. 생성 해야함");
        }
    }

    public void SaveGame()
    {
        if (_userData.HadBabusList != null && _userData.HadBabusList.Count > 0)
        {
            _userData.HaveBabusList.Clear();

            foreach (var data in _babuses)
            {
                var save = new BabusSaveData();
                save.ID = data.ID.ToString();
                save.Name = data.Name;
                save.Hunger = data.Hunger;
                save.Health = data.Health;
                save.Cleanliness = data.Cleaniness;
                save.Happiness = data.Happiness;
                save.IsSick = data.IsSick;
                save.IsLeft = data.IsLeft;
                // 세이브 해야할 바버스데이터 여기에 추가

                _userData.HaveBabusList.Add(save);
            }
        }
        SaveManager.Save(_userData);
    }
}
