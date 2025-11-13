using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Babus/BabusConfig")]
public class BabusConfigSO : ScriptableObject
{
    [Header("지속 초당 감소 수치")]
    [SerializeField] public float HungerDecreasePerSec;
    [SerializeField] public float CleaninessDecreasePersec;

    [Header("체력 초당 감소 수치")]
    [SerializeField] public float HealthDecreasePerSec;
}
