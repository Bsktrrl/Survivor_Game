using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Challenges_SO : ScriptableObject
{
    public List<Challenge> requirementSlotList = new List<Challenge>();
}

[Serializable]
public class Challenge
{
    public string name;
    public string subName;
    public Sprite ChallengeType_Image;

    public bool isMerged;

    public float spacing = 100;

    public List<RequirementSlotInfo> requirementSlots = new List<RequirementSlotInfo>();
}

[Serializable]
public class RequirementSlotInfo
{
    [TextArea(3, 10)] public string description;

    public dice diceType;
    public List<Stats> stats;
    public int requirement;
    public requirementChange requirementChange;
    public int repeat;

    public float spacing;
}

public enum requirementChange
{
    None,

    Increasing,
    Decreasing
}
