using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class Event_SO : ScriptableObject
{
    public List<Events> eventList = new List<Events>();
}

[Serializable]
public class Events
{
    public string name;
    [TextArea(5, 10)] public string description;

    public bool isMerged;
}
