using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Quest_SO : ScriptableObject
{
    public List<Quest> questList = new List<Quest>();
}

[Serializable]
public class Quest
{
    [Header("General")]
    public string name;
    public GamePhases phase;
    [TextArea(5, 10)] public string description;

    [Header("Requirement")]
    public RequirementSlotInfoWithoutDescription requirementSlot;

    [Header("Reward")]
    public Rewards reward;
    public int amount;

    [Header("Height")]
    public float panel_height = 500;
}