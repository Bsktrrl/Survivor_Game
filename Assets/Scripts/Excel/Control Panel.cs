using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlPanel : Singleton<ControlPanel>
{
    [Header("Settings")]
    public int activeCard;

    [Header("Active Data Object")]
    public DataObject activeDataObject;


    //--------------------


    public void UpdateActiveDataObject()
    {
        if (activeCard - 1 <= ReadExcelFile.Instance.newDataObjectList.dataObjectList.Length - 1
            && activeCard - 1 >= 0)
        {
            activeDataObject = ReadExcelFile.Instance.newDataObjectList.dataObjectList[activeCard - 1];
        }
        else
        {
            activeDataObject = null;
        }
    }
}