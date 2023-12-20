using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class TribalCard_SO : ScriptableObject
{
    public List<GameChanger> gameChangerList = new List<GameChanger>();
}

[Serializable]
public class GameChanger
{
    public string name;
    public Sprite image;

    [TextArea(5, 10)] public string description;
}
