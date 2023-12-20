using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class EventCreator : Singleton<EventCreator>
{
    public Event_SO event_SO;

    [SerializeField] TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI description;

    [SerializeField] Image gameStateImage;

    [SerializeField] Sprite tribal_Sprite;
    [SerializeField] Sprite merged_Sprite;

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

        //Set GameStrate Sprite
        if (event_SO.eventList[index].isMerged)
        {
            gameStateImage.sprite = merged_Sprite;
        }
        else
        {
            gameStateImage.sprite = tribal_Sprite;
        }
    }
}
