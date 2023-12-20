using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class EventCreator : Singleton<EventCreator>
{
    public Event_SO event_SO;

    [SerializeField] TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI description;

    public bool isScreenshoting;


    //--------------------


    private void Update()
    {
        if (!isScreenshoting)
        {
            BuildEventCard(event_SO.eventList.Count - 1);
        }
    }


    //--------------------


    public void BuildEventCard(int index)
    {
        //Set Name
        name.text = event_SO.eventList[index].name;

        //Set Description
        description.text = event_SO.eventList[index].description;
    }
}
