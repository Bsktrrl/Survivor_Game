using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

[ExecuteInEditMode]
public class GameChangerCreator : Singleton<GameChangerCreator>
{
    public GameChanger_SO gameChanger_SO;

    [SerializeField] TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI description;

    public bool isScreenshoting;


    //--------------------


    private void Update()
    {
        if (!isScreenshoting)
        {
            BuildEventCard(gameChanger_SO.gameChangerList.Count - 1);
        }
    }


    //--------------------


    public void BuildEventCard(int index)
    {
        //Set Name
        name.text = gameChanger_SO.gameChangerList[index].name;

        //Set Description
        description.text = gameChanger_SO.gameChangerList[index].description;
    }
}
