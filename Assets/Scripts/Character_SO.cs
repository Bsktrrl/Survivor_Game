using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Character_SO : ScriptableObject
{
    public List<Character> character_List = new List<Character>();
}

[Serializable]
public class Character
{
    public string name;
    public Sprite image;
    public Season season;

    [Space(10)]
    public int popularity;
    public int morale;

    [Space(10)]
    [TextArea(3, 10)] public string ability;

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