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
    public string name;
    [TextArea(3, 10)] public string description;
    [TextArea(3, 10)] public string contributorReward;
    [TextArea(3, 10)] public string generalReward;
    [TextArea(3, 10)] public string punishment;

    public RequirementSlotInfo requirementSlot;
}
