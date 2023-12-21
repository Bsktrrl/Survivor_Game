using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class DailyTask_SO : ScriptableObject
{
    public List<DailyTask> dailyTaskList = new List<DailyTask>();
}

[Serializable]
public class DailyTask
{
    [Header("General")]
    public string name;
    [TextArea(3, 10)] public string description;

    [Header("Rewards")]
    public Rewards contributorReward;
    public int contributorReward_amount;

    public Rewards generalReward;
    public int generalReward_amount;

    public Rewards punishment;
    public int punishment_amount;

    [Header("RequirementSlot")]
    public RequirementSlotInfoWithoutDescription requirementSlot;
}
