using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayActiveCard : Singleton<DisplayActiveCard>
{
    [Header("Parents")]
    [SerializeField] GameObject display_1_Parent;
    [SerializeField] GameObject display_8_Parent;

    [Header("UI - Cards")]
    public List<CastawayCard> cardList;

    [Header("Morale Track")]
    public Sprite morale_1;
    public Sprite morale_2;
    public Sprite morale_3;
    public Sprite morale_4;
    public Sprite morale_5;
    public Sprite morale_6;
    public Sprite morale_7;
    public Sprite morale_8;
    public Sprite morale_9;
    public Sprite morale_10;

    [Header("Stat Colors")]
    public Color lowest_Color;
    public Color highest_Color;
    public Color best_Color;


    //--------------------

    private void Start()
    {
        display_1_Parent.SetActive(true);
        display_8_Parent.SetActive(false);
    }

    private void Update()
    {
        ReadExcelFile.Instance.ReadExcelSheet();

        SetDisplay_1(ControlPanel.Instance.activeCard);
    }


    //--------------------


    public void SetDisplay_1(int index)
    {
        display_1_Parent.SetActive(true);
        display_8_Parent.SetActive(false);

        if (index < 0)
            index = 0;
        else if (index > 352)
            index = 352;

        DisplayInput(index, 0);
    }
    public void SetDisplay_8(int index)
    {
        display_1_Parent.SetActive(false);
        display_8_Parent.SetActive(true);

        DisplayInput(index, 1);
        DisplayInput(index + 1, 2);
        DisplayInput(index + 2, 3);
        DisplayInput(index + 3, 4);
        DisplayInput(index + 4, 5);
        DisplayInput(index + 5, 6);
        DisplayInput(index + 6, 7);
        DisplayInput(index + 7, 8);
    }

    void DisplayInput(int objectList, int cardNumber)
    {
        if (ReadExcelFile.Instance.newDataObjectList.dataObjectList[objectList] != null)
        {
            cardList[cardNumber].name_Text.text = ReadExcelFile.Instance.newDataObjectList.dataObjectList[objectList].fullName;

            string imageNameTemp = "CastawaysImages/" + GetSeasonName(ReadExcelFile.Instance.newDataObjectList.dataObjectList[objectList].season) + "/" + ReadExcelFile.Instance.newDataObjectList.dataObjectList[objectList].fullName;
            cardList[cardNumber].character_image.sprite = Resources.Load<Sprite>(imageNameTemp);

            cardList[cardNumber].ability_text.text = ReadExcelFile.Instance.newDataObjectList.dataObjectList[objectList].ability;
            cardList[cardNumber].popularity_text.text = ReadExcelFile.Instance.newDataObjectList.dataObjectList[objectList].popularity.ToString();
            GetMoraleSprite(ReadExcelFile.Instance.newDataObjectList.dataObjectList[objectList].morale, cardNumber);

            string seasonNameTemp = "Logo/" + GetSeasonName(ReadExcelFile.Instance.newDataObjectList.dataObjectList[objectList].season);
            cardList[cardNumber].season_Logo.sprite = Resources.Load<Sprite>(seasonNameTemp);

            cardList[cardNumber].stat_Relationship_Text.text = ReadExcelFile.Instance.newDataObjectList.dataObjectList[objectList].outwit_Relation.ToString();
            cardList[cardNumber].stat_Charisma_Text.text = ReadExcelFile.Instance.newDataObjectList.dataObjectList[objectList].outwit_Charisma.ToString();
            cardList[cardNumber].stat_Intuision_Text.text = ReadExcelFile.Instance.newDataObjectList.dataObjectList[objectList].outwit_Intuition.ToString();
            cardList[cardNumber].stat_Persuation_Text.text = ReadExcelFile.Instance.newDataObjectList.dataObjectList[objectList].outwit_Persuasion.ToString();
            cardList[cardNumber].stat_Deception_Text.text = ReadExcelFile.Instance.newDataObjectList.dataObjectList[objectList].outwit_Deception.ToString();

            cardList[cardNumber].stat_Dexterity_Text.text = ReadExcelFile.Instance.newDataObjectList.dataObjectList[objectList].outplay_Dexterity.ToString();
            cardList[cardNumber].stat_Strength_Text.text = ReadExcelFile.Instance.newDataObjectList.dataObjectList[objectList].outplay_Strength.ToString();
            cardList[cardNumber].stat_Puzzle_Text.text = ReadExcelFile.Instance.newDataObjectList.dataObjectList[objectList].outplay_Puzzle.ToString();
            cardList[cardNumber].stat_Consentration_Text.text = ReadExcelFile.Instance.newDataObjectList.dataObjectList[objectList].outplay_Concentration.ToString();
            cardList[cardNumber].stat_Endurance_Text.text = ReadExcelFile.Instance.newDataObjectList.dataObjectList[objectList].outplay_Endurance.ToString();

            cardList[cardNumber].stat_Loyality_Text.text = ReadExcelFile.Instance.newDataObjectList.dataObjectList[objectList].outlast_Loyalty.ToString();
            cardList[cardNumber].stat_Strategic_Text.text = ReadExcelFile.Instance.newDataObjectList.dataObjectList[objectList].outlast_Strategic.ToString();
            cardList[cardNumber].stat_SelfControl_Text.text = ReadExcelFile.Instance.newDataObjectList.dataObjectList[objectList].outlast_SelfControl.ToString();
            cardList[cardNumber].stat_Advantages_Text.text = ReadExcelFile.Instance.newDataObjectList.dataObjectList[objectList].outlast_Advantages.ToString();
            cardList[cardNumber].stat_Survival_Text.text = ReadExcelFile.Instance.newDataObjectList.dataObjectList[objectList].outlast_Survival.ToString();

            //Set Color on StatText
            GetStatNumberColors(cardList[cardNumber].stat_Relationship_Text, cardNumber);
            GetStatNumberColors(cardList[cardNumber].stat_Charisma_Text, cardNumber);
            GetStatNumberColors(cardList[cardNumber].stat_Intuision_Text, cardNumber);
            GetStatNumberColors(cardList[cardNumber].stat_Persuation_Text, cardNumber);
            GetStatNumberColors(cardList[cardNumber].stat_Deception_Text, cardNumber);

            GetStatNumberColors(cardList[cardNumber].stat_Dexterity_Text, cardNumber);
            GetStatNumberColors(cardList[cardNumber].stat_Strength_Text, cardNumber);
            GetStatNumberColors(cardList[cardNumber].stat_Puzzle_Text, cardNumber);
            GetStatNumberColors(cardList[cardNumber].stat_Consentration_Text, cardNumber);
            GetStatNumberColors(cardList[cardNumber].stat_Endurance_Text, cardNumber);

            GetStatNumberColors(cardList[cardNumber].stat_Loyality_Text, cardNumber);
            GetStatNumberColors(cardList[cardNumber].stat_Strategic_Text, cardNumber);
            GetStatNumberColors(cardList[cardNumber].stat_SelfControl_Text, cardNumber);
            GetStatNumberColors(cardList[cardNumber].stat_Advantages_Text, cardNumber);
            GetStatNumberColors(cardList[cardNumber].stat_Survival_Text, cardNumber);
        }
        else
        {
            cardList[cardNumber].name_Text.text = "";

            cardList[cardNumber].character_image.sprite = null;

            cardList[cardNumber].ability_text.text = "";
            cardList[cardNumber].popularity_text.text = "";
            cardList[cardNumber].morale_Track.sprite = null;

            cardList[cardNumber].stat_Relationship_Text.text = "";
            cardList[cardNumber].stat_Charisma_Text.text = "";
            cardList[cardNumber].stat_Intuision_Text.text = "";
            cardList[cardNumber].stat_Persuation_Text.text = "";
            cardList[cardNumber].stat_Deception_Text.text = "";

            cardList[cardNumber].stat_Dexterity_Text.text = "";
            cardList[cardNumber].stat_Strength_Text.text = "";
            cardList[cardNumber].stat_Puzzle_Text.text = "";
            cardList[cardNumber].stat_Consentration_Text.text = "";
            cardList[cardNumber].stat_Endurance_Text.text = "";

            cardList[cardNumber].stat_Loyality_Text.text = "";
            cardList[cardNumber].stat_Strategic_Text.text = "";
            cardList[cardNumber].stat_SelfControl_Text.text = "";
            cardList[cardNumber].stat_Advantages_Text.text = "";
            cardList[cardNumber].stat_Survival_Text.text = "";
        }
    }

    string GetSeasonName(string season)
    {
        if (season == 1.ToString())
            return "S1 - Boreno";
        else if (season == 2.ToString())
            return "S2 - Australia";
        else if (season == 3.ToString())
            return "S3 - Africa";
        else if (season == 4.ToString())
            return "S4 - Marquases";
        else if (season == 5.ToString())
            return "S5 - Thailand";
        else if (season == 6.ToString())
            return "S6 - Amazon";
        else if (season == 7.ToString())
            return "S7 - Pearl Island";

        else if (season == 9.ToString())
            return "S9 - Vanuatu";
        else if (season == 10.ToString())
            return "S10 - Palau";
        else if (season == 11.ToString())
            return "S11 - Guatemala";
        else if (season == 12.ToString())
            return "S12 - Panama";
        else if (season == 13.ToString())
            return "S13 - Cook Island";
        else if (season == 14.ToString())
            return "S14 - Fiji";
        else if (season == 15.ToString())
            return "S15 - China";
        else if (season == 16.ToString())
            return "S16 - Fans vs. Favorites";
        else if (season == 17.ToString())
            return "S17 - Gabon";
        else if (season == 18.ToString())
            return "S18 - Tocantins";
        else if (season == 19.ToString())
            return "S19 - Samoa";

        else if (season == 21.ToString())
            return "S21 - Nicaragua";
        else if (season == 22.ToString())
            return "S22 - Redemption Island";
        else if (season == 23.ToString())
            return "S23 - South Pacific";
        else if (season == 24.ToString())
            return "S24 - One World";
        else if (season == 25.ToString())
            return "S25 - Philippines";
        else if (season == 26.ToString())
            return "S26 - Caramoan";
        else if (season == 27.ToString())
            return "S27 - Blood vs. Water";
        else if (season == 28.ToString())
            return "S28 - Cagayan";
        else if (season == 29.ToString())
            return "S29 - San Juan del Sur";
        else if (season == 30.ToString())
            return "S30 - Worlds Apart";

        else if (season == 32.ToString())
            return "S32 - Kaôh Rōng";
        else if (season == 33.ToString())
            return "S33 - Millennials vs. Gen X";
        else if (season == 34.ToString())
            return "S34 - Game Changers";
        else if (season == 35.ToString())
            return "S35 - Heroes vs. Healers vs. Hustlers";
        else if (season == 36.ToString())
            return "S36 - Ghost Island";
        else if (season == 37.ToString())
            return "S37 - David vs. Goliath";
        else if (season == 38.ToString())
            return "S38 - Edge of Extinction";
        else if (season == 39.ToString())
            return "S39 - Island of the Idols";

        return null;
    }
    void GetMoraleSprite(string morale, int index)
    {
        if (morale == "1")
            cardList[index].morale_Track.sprite = morale_1;
        else if (morale == "2")
            cardList[index].morale_Track.sprite = morale_2;
        else if (morale == "3")
            cardList[index].morale_Track.sprite = morale_3;
        else if (morale == "4")
            cardList[index].morale_Track.sprite = morale_4;
        else if (morale == "5")
            cardList[index].morale_Track.sprite = morale_5;
        else if (morale == "6")
            cardList[index].morale_Track.sprite = morale_6;
        else if (morale == "7")
            cardList[index].morale_Track.sprite = morale_7;
        else if (morale == "8")
            cardList[index].morale_Track.sprite = morale_8;
        else if (morale == "9")
            cardList[index].morale_Track.sprite = morale_9;
        else if (morale == "10")
            cardList[index].morale_Track.sprite = morale_10;
        else
            cardList[index].morale_Track.sprite = null;
    }

    int GetLowestStatNumber(int index)
    {
        int lowestNumber = 0;

        lowestNumber = int.Parse(cardList[index].stat_Relationship_Text.text);

        if (int.Parse(cardList[index].stat_Charisma_Text.text) < lowestNumber && int.Parse(cardList[index].stat_Charisma_Text.text) >= 0)
            lowestNumber = int.Parse(cardList[index].stat_Charisma_Text.text);
        if (int.Parse(cardList[index].stat_Intuision_Text.text) < lowestNumber && int.Parse(cardList[index].stat_Intuision_Text.text) >= 0)
            lowestNumber = int.Parse(cardList[index].stat_Intuision_Text.text);
        if (int.Parse(cardList[index].stat_Persuation_Text.text) < lowestNumber && int.Parse(cardList[index].stat_Persuation_Text.text) >= 0)
            lowestNumber = int.Parse(cardList[index].stat_Persuation_Text.text);
        if (int.Parse(cardList[index].stat_Deception_Text.text) < lowestNumber && int.Parse(cardList[index].stat_Deception_Text.text) >= 0)
            lowestNumber = int.Parse(cardList[index].stat_Deception_Text.text);

        if (int.Parse(cardList[index].stat_Dexterity_Text.text) < lowestNumber && int.Parse(cardList[index].stat_Dexterity_Text.text) >= 0)
            lowestNumber = int.Parse(cardList[index].stat_Dexterity_Text.text);
        if (int.Parse(cardList[index].stat_Strength_Text.text) < lowestNumber && int.Parse(cardList[index].stat_Strength_Text.text) >= 0)
            lowestNumber = int.Parse(cardList[index].stat_Strength_Text.text);
        if (int.Parse(cardList[index].stat_Puzzle_Text.text) < lowestNumber && int.Parse(cardList[index].stat_Puzzle_Text.text) >= 0)
            lowestNumber = int.Parse(cardList[index].stat_Puzzle_Text.text);
        if (int.Parse(cardList[index].stat_Consentration_Text.text) < lowestNumber && int.Parse(cardList[index].stat_Consentration_Text.text) >= 0)
            lowestNumber = int.Parse(cardList[index].stat_Consentration_Text.text);
        if (int.Parse(cardList[index].stat_Endurance_Text.text) < lowestNumber && int.Parse(cardList[index].stat_Endurance_Text.text) >= 0)
            lowestNumber = int.Parse(cardList[index].stat_Endurance_Text.text);

        if (int.Parse(cardList[index].stat_Loyality_Text.text) < lowestNumber && int.Parse(cardList[index].stat_Loyality_Text.text) >= 0)
            lowestNumber = int.Parse(cardList[index].stat_Loyality_Text.text);
        if (int.Parse(cardList[index].stat_Strategic_Text.text) < lowestNumber && int.Parse(cardList[index].stat_Strategic_Text.text) >= 0)
            lowestNumber = int.Parse(cardList[index].stat_Strategic_Text.text);
        if (int.Parse(cardList[index].stat_SelfControl_Text.text) < lowestNumber && int.Parse(cardList[index].stat_SelfControl_Text.text) >= 0)
            lowestNumber = int.Parse(cardList[index].stat_SelfControl_Text.text);
        if (int.Parse(cardList[index].stat_Advantages_Text.text) < lowestNumber && int.Parse(cardList[index].stat_Advantages_Text.text) >= 0)
            lowestNumber = int.Parse(cardList[index].stat_Advantages_Text.text);
        if (int.Parse(cardList[index].stat_Survival_Text.text) < lowestNumber && int.Parse(cardList[index].stat_Survival_Text.text) >= 0)
            lowestNumber = int.Parse(cardList[index].stat_Survival_Text.text);

        return lowestNumber;
    }
    int GetHighestStatNumber(int index)
    {
        int lowestNumber = 0;

        lowestNumber = int.Parse(cardList[index].stat_Relationship_Text.text);

        if (int.Parse(cardList[index].stat_Charisma_Text.text) > lowestNumber && int.Parse(cardList[index].stat_Charisma_Text.text) <= 5)
            lowestNumber = int.Parse(cardList[index].stat_Charisma_Text.text);
        if (int.Parse(cardList[index].stat_Intuision_Text.text) > lowestNumber && int.Parse(cardList[index].stat_Intuision_Text.text) <= 5)
            lowestNumber = int.Parse(cardList[index].stat_Intuision_Text.text);
        if (int.Parse(cardList[index].stat_Persuation_Text.text) > lowestNumber && int.Parse(cardList[index].stat_Persuation_Text.text) <= 5)
            lowestNumber = int.Parse(cardList[index].stat_Persuation_Text.text);
        if (int.Parse(cardList[index].stat_Deception_Text.text) > lowestNumber && int.Parse(cardList[index].stat_Deception_Text.text) <= 5)
            lowestNumber = int.Parse(cardList[index].stat_Deception_Text.text);

        if (int.Parse(cardList[index].stat_Dexterity_Text.text) > lowestNumber && int.Parse(cardList[index].stat_Dexterity_Text.text) <= 5)
            lowestNumber = int.Parse(cardList[index].stat_Dexterity_Text.text);
        if (int.Parse(cardList[index].stat_Strength_Text.text) > lowestNumber && int.Parse(cardList[index].stat_Strength_Text.text) <= 5)
            lowestNumber = int.Parse(cardList[index].stat_Strength_Text.text);
        if (int.Parse(cardList[index].stat_Puzzle_Text.text) > lowestNumber && int.Parse(cardList[index].stat_Puzzle_Text.text) <= 5)
            lowestNumber = int.Parse(cardList[index].stat_Puzzle_Text.text);
        if (int.Parse(cardList[index].stat_Consentration_Text.text) > lowestNumber && int.Parse(cardList[index].stat_Consentration_Text.text) <= 5)
            lowestNumber = int.Parse(cardList[index].stat_Consentration_Text.text);
        if (int.Parse(cardList[index].stat_Endurance_Text.text) > lowestNumber && int.Parse(cardList[index].stat_Endurance_Text.text) <= 5)
            lowestNumber = int.Parse(cardList[index].stat_Endurance_Text.text);

        if (int.Parse(cardList[index].stat_Loyality_Text.text) > lowestNumber && int.Parse(cardList[index].stat_Loyality_Text.text) <= 5)
            lowestNumber = int.Parse(cardList[index].stat_Loyality_Text.text);
        if (int.Parse(cardList[index].stat_Strategic_Text.text) > lowestNumber && int.Parse(cardList[index].stat_Strategic_Text.text) <= 5)
            lowestNumber = int.Parse(cardList[index].stat_Strategic_Text.text);
        if (int.Parse(cardList[index].stat_SelfControl_Text.text) > lowestNumber && int.Parse(cardList[index].stat_SelfControl_Text.text) <= 5)
            lowestNumber = int.Parse(cardList[index].stat_SelfControl_Text.text);
        if (int.Parse(cardList[index].stat_Advantages_Text.text) > lowestNumber && int.Parse(cardList[index].stat_Advantages_Text.text) <= 5)
            lowestNumber = int.Parse(cardList[index].stat_Advantages_Text.text);
        if (int.Parse(cardList[index].stat_Survival_Text.text) > lowestNumber && int.Parse(cardList[index].stat_Survival_Text.text) <= 5)
            lowestNumber = int.Parse(cardList[index].stat_Survival_Text.text);

        return lowestNumber;
    }

    void GetStatNumberColors(TextMeshProUGUI text, int index)
    {
        text.color = Color.black;

        if (int.Parse(text.text) == GetLowestStatNumber(index))
            text.color = lowest_Color;
        else if (int.Parse(text.text) == GetHighestStatNumber(index))
            text.color = highest_Color;
        else if (int.Parse(text.text) > GetHighestStatNumber(index))
            text.color = best_Color;
        else
            text.color = Color.black;
    }
}

[Serializable]
public class CastawayCard
{
    [Header("Name_text")]
    public TextMeshProUGUI name_Text;

    [Header("Image_sprite")]
    public Image character_image;

    [Header("Ability_text")]
    public TextMeshProUGUI ability_text;

    [Header("Popularity_text")]
    public TextMeshProUGUI popularity_text;

    [Header("Morale_Track")]
    public Image morale_Track;

    [Header("Season_Logo")]
    public Image season_Logo;

    [Header("Stats_Outwit")]
    public TextMeshProUGUI stat_Relationship_Text;
    public TextMeshProUGUI stat_Charisma_Text;
    public TextMeshProUGUI stat_Intuision_Text;
    public TextMeshProUGUI stat_Persuation_Text;
    public TextMeshProUGUI stat_Deception_Text;

    [Header("Stats_Outplay")]
    public TextMeshProUGUI stat_Dexterity_Text;
    public TextMeshProUGUI stat_Strength_Text;
    public TextMeshProUGUI stat_Puzzle_Text;
    public TextMeshProUGUI stat_Consentration_Text;
    public TextMeshProUGUI stat_Endurance_Text;

    [Header("Stats_Outlast")]
    public TextMeshProUGUI stat_Loyality_Text;
    public TextMeshProUGUI stat_Strategic_Text;
    public TextMeshProUGUI stat_SelfControl_Text;
    public TextMeshProUGUI stat_Advantages_Text;
    public TextMeshProUGUI stat_Survival_Text;
}