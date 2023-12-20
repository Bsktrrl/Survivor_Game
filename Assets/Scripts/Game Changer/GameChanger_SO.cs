using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class GameChanger_SO : ScriptableObject
{
    public List<GameChanger> gameChangerList = new List<GameChanger>();
}

[Serializable]
public class GameChanger
{
    public string name;
    [TextArea(5, 10)] public string description;
}
