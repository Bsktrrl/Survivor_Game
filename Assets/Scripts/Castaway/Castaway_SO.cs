using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Castaway_SO : ScriptableObject
{
    public List<Castaway> character_List = new List<Castaway>();
}

[Serializable]
public class Castaway
{
    public string name;
    public Sprite image;
    public Season season;

    [Space(10)]
    public int popularity;
    public int morale;

    [Space(10)]
    public Tier tier;

    [Space(10)]
    [TextArea(2, 10)] public string ability;

    [Header("Stats")]
    public int Relationship;
    public int Charisma;
    public int Intuision;
    public int Persuation;
    public int Deception;

    [Space(10)]
    public int Dexterity;
    public int Strength;
    public int Puzzle;
    public int Consentration;
    public int Endurance;

    [Space(10)]
    public int Loyality;
    public int Strategic;
    public int SelfControl;
    public int Advantages;
    public int Survival;
}