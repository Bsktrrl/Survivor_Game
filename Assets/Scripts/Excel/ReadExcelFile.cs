using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using UnityEngine;


public class ReadExcelFile : Singleton<ReadExcelFile>
{
    [Header("Document")]
    [SerializeField] TextAsset excelSheet;

    [Header("Stats from Excel")]
    [SerializeField] int startRow;
    [SerializeField] int columns;

    [Header("DataObjectList")]
    public DataObjectList newDataObjectList = new DataObjectList();

    //Other
    int entriesAmount;


    //--------------------


    public void ReadExcelSheet()
    {
        //Separate Excel Sheet into a string[] by its ";"
        string[] excelData = excelSheet.text.Split(new string[] { ";", "\n" }, StringSplitOptions.None);

        //Get the size of the Excel table
        int excelTableSize = (excelData.Length / columns - 1) - 0;

        //Make list "newDataObjectList" with the correct amount of elements
        newDataObjectList.dataObjectList = new DataObject[excelTableSize];

        //Fill the new element with data
        for (int i = 0; i < 352 /*excelTableSize*/; i++)
        {
            int result;
            newDataObjectList.dataObjectList[i] = new DataObject();

            //Name
            if (excelData[columns * (i + startRow - 1) + 2] != "")
                newDataObjectList.dataObjectList[i].fullName = excelData[columns * (i + startRow - 1) + 2];
            else
                newDataObjectList.dataObjectList[i].fullName = "";

            //ID
            if (excelData[columns * (i + startRow - 1) + 1] != "")
                newDataObjectList.dataObjectList[i].ID = excelData[columns * (i + startRow - 1) + 1];
            else
                newDataObjectList.dataObjectList[i].ID = "";

            //Season
            if (excelData[columns * (i + startRow - 1) + 3] != "")
                newDataObjectList.dataObjectList[i].season = excelData[columns * (i + startRow - 1) + 3];
            else
                newDataObjectList.dataObjectList[i].season = "";

            //Popularity
            if (excelData[columns * (i + startRow - 1) + 4] != "")
                newDataObjectList.dataObjectList[i].popularity = excelData[columns * (i + startRow - 1) + 4];
            else
                newDataObjectList.dataObjectList[i].popularity = "";

            //Morale
            if (excelData[columns * (i + startRow - 1) + 25] != "")
                newDataObjectList.dataObjectList[i].morale = excelData[columns * (i + startRow - 1) + 25];
            else
                newDataObjectList.dataObjectList[i].morale = "";

            //Morale
            if (excelData[columns * (i + startRow - 1) + 28] != "")
                newDataObjectList.dataObjectList[i].ability = excelData[columns * (i + startRow - 1) + 28];
            else
                newDataObjectList.dataObjectList[i].ability = "";

            //Outwit
            if (excelData[columns * (i + startRow - 1) + 6] != "")
                newDataObjectList.dataObjectList[i].outwit_Relation = excelData[columns * (i + startRow - 1) + 6];
            else
                newDataObjectList.dataObjectList[i].outwit_Relation = "";
            if (excelData[columns * (i + startRow - 1) + 7] != "")
                newDataObjectList.dataObjectList[i].outwit_Charisma = excelData[columns * (i + startRow - 1) + 7];
            else
                newDataObjectList.dataObjectList[i].outwit_Charisma = "";
            if (excelData[columns * (i + startRow - 1) + 8] != "")
                newDataObjectList.dataObjectList[i].outwit_Intuition = excelData[columns * (i + startRow - 1) + 8];
            else
                newDataObjectList.dataObjectList[i].outwit_Intuition = "";
            if (excelData[columns * (i + startRow - 1) + 9] != "")
                newDataObjectList.dataObjectList[i].outwit_Persuasion = excelData[columns * (i + startRow - 1) + 9];
            else
                newDataObjectList.dataObjectList[i].outwit_Persuasion = "";
            if (excelData[columns * (i + startRow - 1) + 10] != "")
                newDataObjectList.dataObjectList[i].outwit_Deception = excelData[columns * (i + startRow - 1) + 10];
            else
                newDataObjectList.dataObjectList[i].outwit_Deception = "";

            //Outplay
            if (excelData[columns * (i + startRow - 1) + 12] != "")
                newDataObjectList.dataObjectList[i].outplay_Dexterity = excelData[columns * (i + startRow - 1) + 12];
            else
                newDataObjectList.dataObjectList[i].outplay_Dexterity = "";
            if (excelData[columns * (i + startRow - 1) + 13] != "")
                newDataObjectList.dataObjectList[i].outplay_Strength = excelData[columns * (i + startRow - 1) + 13];
            else
                newDataObjectList.dataObjectList[i].outplay_Strength = "";
            if (excelData[columns * (i + startRow - 1) + 14] != "")
                newDataObjectList.dataObjectList[i].outplay_Puzzle = excelData[columns * (i + startRow - 1) + 14];
            else
                newDataObjectList.dataObjectList[i].outplay_Puzzle = "";
            if (excelData[columns * (i + startRow - 1) + 15] != "")
                newDataObjectList.dataObjectList[i].outplay_Concentration = excelData[columns * (i + startRow - 1) + 15];
            else
                newDataObjectList.dataObjectList[i].outplay_Concentration = "";
            if (excelData[columns * (i + startRow - 1) + 16] != "")
                newDataObjectList.dataObjectList[i].outplay_Endurance = excelData[columns * (i + startRow - 1) + 16];
            else
                newDataObjectList.dataObjectList[i].outplay_Endurance = "";

            //Outlast
            if (excelData[columns * (i + startRow - 1) + 18] != "")
                newDataObjectList.dataObjectList[i].outlast_Loyalty = excelData[columns * (i + startRow - 1) + 18];
            else
                newDataObjectList.dataObjectList[i].outlast_Loyalty = "";
            if (excelData[columns * (i + startRow - 1) + 19] != "")
                newDataObjectList.dataObjectList[i].outlast_Strategic = excelData[columns * (i + startRow - 1) + 19];
            else
                newDataObjectList.dataObjectList[i].outlast_Strategic = "";
            if (excelData[columns * (i + startRow - 1) + 20] != "")
                newDataObjectList.dataObjectList[i].outlast_SelfControl = excelData[columns * (i + startRow - 1) + 20];
            else
                newDataObjectList.dataObjectList[i].outlast_SelfControl = "";
            if (excelData[columns * (i + startRow - 1) + 21] != "")
                newDataObjectList.dataObjectList[i].outlast_Advantages = excelData[columns * (i + startRow - 1) + 21];
            else
                newDataObjectList.dataObjectList[i].outlast_Advantages = "";
            if (excelData[columns * (i + startRow - 1) + 22] != "")
                newDataObjectList.dataObjectList[i].outlast_Survival = excelData[columns * (i + startRow - 1) + 22];
            else
                newDataObjectList.dataObjectList[i].outlast_Survival = "";
        }

        //Remove elements that doesn't have a name
        newDataObjectList.dataObjectList = newDataObjectList.dataObjectList.Where(obj => obj != null && !string.IsNullOrEmpty(obj.fullName)).ToArray();
    }
}

[Serializable]
public class DataObjectList
{
    public DataObject[] dataObjectList;
}

[Serializable]
public class DataObject
{
    [Header("General Info")]
    public string fullName;

    public string ID;
    public string season;
    public string morale;
    public string popularity;

    [Header("Ability")]
    [TextArea(3, 15)] public string ability;

    [Header("Outwit")]
    public string outwit_Relation;
    public string outwit_Charisma;
    public string outwit_Intuition;
    public string outwit_Persuasion;
    public string outwit_Deception;

    [Header("Outplay")]
    public string outplay_Dexterity;
    public string outplay_Strength;
    public string outplay_Puzzle;
    public string outplay_Concentration;
    public string outplay_Endurance;

    [Header("Outlast")]
    public string outlast_Loyalty;
    public string outlast_Strategic;
    public string outlast_SelfControl;
    public string outlast_Advantages;
    public string outlast_Survival;
}
