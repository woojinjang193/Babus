using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BabusStatus
{
    public int ID { get; private set; }
    public string Name { get; private set; }
    public float Hunger { get; private set; }
    public float Health { get; private set; }
    public float Cleaniness { get; private set; }
    public float Happiness { get; private set; }
    public bool IsSick { get; private set; }

    public Growth growth { get; private set; }

    private BabusConfigSO _config;

    public float LastUpdayeTime;

    public BabusStatus(int id, BabusConfigSO config)
    {
        ID = id;
        _config = config;
    }
    public void Tick(int sec)
    {
        Hunger -= _config.HungerDecreasePerSec * sec;
        Cleaniness -= _config.CleaninessDecreasePersec * sec;

        if(Hunger <= 0)
        {
            Health -= _config.HealthDecreasePerSec * sec;
            Debug.Log($"Ã¼·Â: {Health}");
        }
        Clamp();
    }
    public void IncreaseStat(Stat stat, float value)
    {
        switch (stat)
        {
            case Stat.Health:
                Health += value;
                break;
            case Stat.Cleaniness:
                Cleaniness += value;
                break;
            case Stat.Hunger:
                Hunger += value;
                break;
            case Stat.Happiness:
                Happiness += value;
                break;
        }
        Clamp();
    }
    public void DecreaseStat(Stat stat, float value)
    {
        switch (stat)
        {
            case Stat.Health:
                Health -= value;
                break;
            case Stat.Cleaniness:
                Cleaniness -= value;
                break;
            case Stat.Hunger:
                Hunger -= value;
                break;
            case Stat.Happiness:
                Happiness -= value;
                break;
        }
        Clamp();
    }
    private void Clamp()
    {
        Hunger = Mathf.Clamp(Hunger, 0, 100);
        Health = Mathf.Clamp(Health, 0, 100);
        Cleaniness = Mathf.Clamp(Cleaniness, 0, 100);
        Happiness = Mathf.Clamp(Happiness, 0, 100);
    }
}
