using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Rankings_SO : ScriptableObject
{
    public List<CharacterSlot> characterRankings_List = new List<CharacterSlot>();
}


[Serializable]
public class CharacterSlot
{
    public string name;
    public int season;
    public CharacterTier tier;
    public int popularity;
}

public enum CharacterTier
{
    None,

    Normal,
    Rare,
    Epic,
    Legendary
}