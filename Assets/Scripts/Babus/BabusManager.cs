using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabusManager : MonoBehaviour
{
    [SerializeField] private GameObject _babusPrefab;

    private List<BabusStatus> _babuses;
    private List<BabusView> _views = new List<BabusView>();

    private float _timer;

    private void Start()
    {
        _babuses = Manager.Game.Babuses;
        SpawnAll();
    }

    private void SpawnAll()
    {
        foreach (var status in _babuses)
        {
            var obj = Instantiate(_babusPrefab, transform);
            var view = obj.GetComponent<BabusView>();
            view.Setup(status);
            _views.Add(view);
        }
    }

    private void Update()
    {
        _timer += Time.deltaTime;

        if (_timer >= 1f)
        {
            _timer -= 1f;
            TickAll(1);
        }
    }

    private void TickAll(int sec)
    {
        for (int i = 0; i < _babuses.Count; i++)
        {
            _babuses[i].Tick(sec);
        }
    }
}
