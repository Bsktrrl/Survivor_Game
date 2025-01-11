using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : Singleton<ControlPanel>
{
    [Header("Settings")]
    public int activeCard;


    //--------------------


    public void SetDataObjectActive(int index)
    {
        activeCard = index;

        if (activeCard < 0)
            activeCard = 0;
        else if (activeCard > 352)
            activeCard = 352;
    }
    public void SetRandomDataObjectActive()
    {
        int rng;

        rng = Random.Range(0, ReadExcelFile.Instance.newDataObjectList.dataObjectList.Length);

        while (activeCard == rng + 1)
        {
            rng = Random.Range(0, ReadExcelFile.Instance.newDataObjectList.dataObjectList.Length);
        }

        activeCard = rng + 1;
    }
}