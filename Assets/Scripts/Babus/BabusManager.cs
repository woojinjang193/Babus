using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabusManager : MonoBehaviour
{
    private List<BabusStatus> _babuses = new List<BabusStatus>();
    public List<BabusStatus> babuses => _babuses;

    private float _timer;

    public void AddBabus(int id, BabusConfigSO config) //게임매니저가 호출
    {
        var status = new BabusStatus(id, config);
        _babuses.Add(status);
    }
    public void TickAll(int sec)
    {
        for (int i = 0; i < _babuses.Count; i++)
        {
            _babuses[i].Tick(sec);
        }
    }
    private void Update()
    {
        _timer += Time.deltaTime;

        if(_timer >= 1f)
        {
            _timer -= 1f;
            TickAll(1);
        }
    }
}
