using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Threading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class CastawayCreator : Singleton<CastawayCreator>
{
    public static CastawayCreator instance { get; private set; }

    #region Variables
    [SerializeField] Castaway_SO character_SO;

    [Header("Name_text")]
    public TextMeshProUGUI name_Text;

    [Header("Image_sprite")]
    public Image character_image;

    [Header("Ability_text")]
    public TextMeshProUGUI ability_text;

    [Header("Popularity_text")]
    public TextMeshProUGUI popularity_text;

    [Header("Tier BG Colors")]
    public Image bg_Image;
    [SerializeField] Color normal_Color;
    [SerializeField] Color rare_Color;
    [SerializeField] Color epic_Color;
    [SerializeField] Color legendaryl_Color;

    [Header("Stat Colors")]
    [SerializeField] Color lowest_Color;
    [SerializeField] Color highest_Color;
    [SerializeField] Color best_Color;

    [Header("Morale_Track")]
    public Image morale_Track;
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

    [Header("Stats_text")]
    [SerializeField] TextMeshProUGUI stat_Relationship_Text;
    [SerializeField] TextMeshProUGUI stat_Charisma_Text;
    [SerializeField] TextMeshProUGUI stat_Intuision_Text;
    [SerializeField] TextMeshProUGUI stat_Persuation_Text;
    [SerializeField] TextMeshProUGUI stat_Deception_Text;

    [SerializeField] TextMeshProUGUI stat_Dexterity_Text;
    [SerializeField] TextMeshProUGUI stat_Strength_Text;
    [SerializeField] TextMeshProUGUI stat_Puzzle_Text;
    [SerializeField] TextMeshProUGUI stat_Consentration_Text;
    [SerializeField] TextMeshProUGUI stat_Endurance_Text;

    [SerializeField] TextMeshProUGUI stat_Loyality_Text;
    [SerializeField] TextMeshProUGUI stat_Strategic_Text;
    [SerializeField] TextMeshProUGUI stat_SelfControl_Text;
    [SerializeField] TextMeshProUGUI stat_Advantages_Text;
    [SerializeField] TextMeshProUGUI stat_Survival_Text;

    [Header("Season_Logo")]
    public Image season_Logo;

    [SerializeField] Sprite Season_1_Boreno;
    [SerializeField] Sprite Season_2_AustralianOutback;
    [SerializeField] Sprite Season_3_Africa;
    [SerializeField] Sprite Season_4_Marquesas;
    [SerializeField] Sprite Season_5_Thailand;
    [SerializeField] Sprite Season_6_Amazonas;
    [SerializeField] Sprite Season_7_PearIsland;
    [SerializeField] Sprite Season_8_AllStars;
    [SerializeField] Sprite Season_9_Vanuatu;
    [SerializeField] Sprite Season_10_Palau;

    [SerializeField] Sprite Season_11_Guatemala;
    [SerializeField] Sprite Season_12_Panama;
    [SerializeField] Sprite Season_13_CookIsland;
    [SerializeField] Sprite Season_14_Fiji;
    [SerializeField] Sprite Season_15_China;
    [SerializeField] Sprite Season_16_FansVsFavorites;
    [SerializeField] Sprite Season_17_Gabon;
    [SerializeField] Sprite Season_18_Tocantins;
    [SerializeField] Sprite Season_19_Samoa;
    [SerializeField] Sprite Season_20_HeroVsVillians;
        
    [SerializeField] Sprite Season_21_Nicaragua;
    [SerializeField] Sprite Season_22_RedemtionIsland;
    [SerializeField] Sprite Season_23_SouthPacific;
    [SerializeField] Sprite Season_24_OneWorld;
    [SerializeField] Sprite Season_25_Philippines;
    [SerializeField] Sprite Season_26_Caramoan;
    [SerializeField] Sprite Season_27_BloodVsWater;
    [SerializeField] Sprite Season_28_Cagayan;
    [SerializeField] Sprite Season_29_BloodVsWater2;
    [SerializeField] Sprite Season_30_WorldApart;
        
    [SerializeField] Sprite Season_31_SecondChance;
    [SerializeField] Sprite Season_32_KaohRong;
    [SerializeField] Sprite Season_33_MillenialsVsGenX;
    [SerializeField] Sprite Season_34_GameChangers;
    [SerializeField] Sprite Season_35_HeroesVsHealersVsHustlers;
    [SerializeField] Sprite Season_36_GhostIsland;
    [SerializeField] Sprite Season_37_DavidVsGoliath;
    [SerializeField] Sprite Season_38_EdgeOfExtinction;
    [SerializeField] Sprite Season_39_IslandOfTheIdols;
    [SerializeField] Sprite Season_40_WinnersAtWar;
    #endregion

    public bool isPrinting;


    //--------------------


    private void Update()
    {
        if (!isPrinting)
        {
            SetDisplayedCard(character_SO.character_List.Count - 1);
        }
    }


    //--------------------


    public void SetDisplayedCard(int index)
    {
        //Set Character Name
        #region
        name_Text.text = character_SO.character_List[index].name;
        #endregion

        //Set Image
        #region
        character_image.sprite = character_SO.character_List[index].image;
        #endregion

        //Set Season Logo
        switch (character_SO.character_List[index].season)
        {
            case Season.Season_1_Boreno:
                season_Logo.sprite = Season_1_Boreno;
                break;
            case Season.Season_2_AustralianOutback:
                season_Logo.sprite = Season_2_AustralianOutback;
                break;
            case Season.Season_3_Africa:
                season_Logo.sprite = Season_3_Africa;
                break;
            case Season.Season_4_Marquesas:
                season_Logo.sprite = Season_4_Marquesas;
                break;
            case Season.Season_5_Thailand:
                season_Logo.sprite = Season_5_Thailand;
                break;
            case Season.Season_6_Amazonas:
                season_Logo.sprite = Season_6_Amazonas;
                break;
            case Season.Season_7_PearIsland:
                season_Logo.sprite = Season_7_PearIsland;
                break;
            case Season.Season_8_AllStars:
                season_Logo.sprite = Season_8_AllStars;
                break;
            case Season.Season_9_Vanuatu:
                season_Logo.sprite = Season_9_Vanuatu;
                break;
            case Season.Season_10_Palau:
                season_Logo.sprite = Season_10_Palau;
                break;
            case Season.Season_11_Guatemala:
                season_Logo.sprite = Season_11_Guatemala;
                break;
            case Season.Season_12_Panama:
                season_Logo.sprite = Season_12_Panama;
                break;
            case Season.Season_13_CookIsland:
                season_Logo.sprite = Season_13_CookIsland;
                break;
            case Season.Season_14_Fiji:
                season_Logo.sprite = Season_14_Fiji;
                break;
            case Season.Season_15_China:
                season_Logo.sprite = Season_15_China;
                break;
            case Season.Season_16_FansVsFavorites:
                season_Logo.sprite = Season_16_FansVsFavorites;
                break;
            case Season.Season_17_Gabon:
                season_Logo.sprite = Season_17_Gabon;
                break;
            case Season.Season_18_Tocantins:
                season_Logo.sprite = Season_18_Tocantins;
                break;
            case Season.Season_19_Samoa:
                season_Logo.sprite = Season_19_Samoa;
                break;
            case Season.Season_20_HeroVsVillians:
                season_Logo.sprite = Season_20_HeroVsVillians;
                break;
            case Season.Season_21_Nicaragua:
                season_Logo.sprite = Season_21_Nicaragua;
                break;
            case Season.Season_22_RedemtionIsland:
                season_Logo.sprite = Season_22_RedemtionIsland;
                break;
            case Season.Season_23_SouthPacific:
                season_Logo.sprite = Season_23_SouthPacific;
                break;
            case Season.Season_24_OneWorld:
                season_Logo.sprite = Season_24_OneWorld;
                break;
            case Season.Season_25_Philippines:
                season_Logo.sprite = Season_25_Philippines;
                break;
            case Season.Season_26_Caramoan:
                season_Logo.sprite = Season_26_Caramoan;
                break;
            case Season.Season_27_BloodVsWater:
                season_Logo.sprite = Season_27_BloodVsWater;
                break;
            case Season.Season_28_Cagayan:
                season_Logo.sprite = Season_28_Cagayan;
                break;
            case Season.Season_29_BloodVsWater2:
                season_Logo.sprite = Season_29_BloodVsWater2;
                break;
            case Season.Season_30_WorldApart:
                season_Logo.sprite = Season_30_WorldApart;
                break;
            case Season.Season_31_SecondChance:
                season_Logo.sprite = Season_31_SecondChance;
                break;
            case Season.Season_32_KaohRong:
                season_Logo.sprite = Season_32_KaohRong;
                break;
            case Season.Season_33_MillenialsVsGenX:
                season_Logo.sprite = Season_33_MillenialsVsGenX;
                break;
            case Season.Season_34_GameChangers:
                season_Logo.sprite = Season_34_GameChangers;
                break;
            case Season.Season_35_HeroesVsHealersVsHustlers:
                season_Logo.sprite = Season_35_HeroesVsHealersVsHustlers;
                break;
            case Season.Season_36_GhostIsland:
                season_Logo.sprite = Season_36_GhostIsland;
                break;
            case Season.Season_37_DavidVsGoliath:
                season_Logo.sprite = Season_37_DavidVsGoliath;
                break;
            case Season.Season_38_EdgeOfExtinction:
                season_Logo.sprite = Season_38_EdgeOfExtinction;
                break;
            case Season.Season_39_IslandOfTheIdols:
                season_Logo.sprite = Season_39_IslandOfTheIdols;
                break;
            case Season.Season_40_WinnersAtWar:
                season_Logo.sprite = Season_40_WinnersAtWar;
                break;
            default:
                season_Logo.sprite = null;
                break;
        }

        //Set Popularity
        #region
        popularity_text.text = character_SO.character_List[index].popularity.ToString();
        #endregion

        //Set Ability
        #region
        ability_text.text = "<size=130%><b><U>Ability</b></U>\r\n<size=20%>\r\n<size=100%>" + character_SO.character_List[index].ability;
        #endregion

        //Set Morale_Track
        switch (character_SO.character_List[index].morale)
        {
            case 1:
                morale_Track.sprite = morale_1;
                break;
            case 2:
                morale_Track.sprite = morale_2;
                break;
            case 3:
                morale_Track.sprite = morale_3;
                break;
            case 4:
                morale_Track.sprite = morale_4;
                break;
            case 5:
                morale_Track.sprite = morale_5;
                break;
            case 6:
                morale_Track.sprite = morale_6;
                break;
            case 7:
                morale_Track.sprite = morale_7;
                break;
            case 8:
                morale_Track.sprite = morale_8;
                break;
            case 9:
                morale_Track.sprite = morale_9;
                break;
            case 10:
                morale_Track.sprite = morale_10;
                break;
            default:
                morale_Track.sprite = null;
                break;
        }

        //Set Stat Number
        #region
        #region
        stat_Relationship_Text.text = character_SO.character_List[index].Relationship.ToString();
        stat_Charisma_Text.text = character_SO.character_List[index].Charisma.ToString();
        stat_Intuision_Text.text = character_SO.character_List[index].Intuision.ToString();
        stat_Persuation_Text.text = character_SO.character_List[index].Persuation.ToString();
        stat_Deception_Text.text = character_SO.character_List[index].Deception.ToString();

        stat_Dexterity_Text.text = character_SO.character_List[index].Dexterity.ToString();
        stat_Strength_Text.text = character_SO.character_List[index].Strength.ToString();
        stat_Puzzle_Text.text = character_SO.character_List[index].Puzzle.ToString();
        stat_Consentration_Text.text = character_SO.character_List[index].Consentration.ToString();
        stat_Endurance_Text.text = character_SO.character_List[index].Endurance.ToString();

        stat_Loyality_Text.text = character_SO.character_List[index].Loyality.ToString();
        stat_Strategic_Text.text = character_SO.character_List[index].Strategic.ToString();
        stat_SelfControl_Text.text = character_SO.character_List[index].SelfControl.ToString();
        stat_Advantages_Text.text = character_SO.character_List[index].Advantages.ToString();
        stat_Survival_Text.text = character_SO.character_List[index].Survival.ToString();
        #endregion

        //Set stat color
        List<int> tempStatList = new List<int>();
        #region
        tempStatList.Add(character_SO.character_List[index].Relationship);
        tempStatList.Add(character_SO.character_List[index].Charisma);
        tempStatList.Add(character_SO.character_List[index].Intuision);
        tempStatList.Add(character_SO.character_List[index].Persuation);
        tempStatList.Add(character_SO.character_List[index].Deception);

        tempStatList.Add(character_SO.character_List[index].Dexterity);
        tempStatList.Add(character_SO.character_List[index].Strength);
        tempStatList.Add(character_SO.character_List[index].Puzzle);
        tempStatList.Add(character_SO.character_List[index].Consentration);
        tempStatList.Add(character_SO.character_List[index].Endurance);

        tempStatList.Add(character_SO.character_List[index].Loyality);
        tempStatList.Add(character_SO.character_List[index].Strategic);
        tempStatList.Add(character_SO.character_List[index].SelfControl);
        tempStatList.Add(character_SO.character_List[index].Advantages);
        tempStatList.Add(character_SO.character_List[index].Survival);
        #endregion
        List<TextMeshProUGUI> tempStatTextList = new List<TextMeshProUGUI>();
        #region
        tempStatTextList.Add(stat_Relationship_Text);
        tempStatTextList.Add(stat_Charisma_Text);
        tempStatTextList.Add(stat_Intuision_Text);
        tempStatTextList.Add(stat_Persuation_Text);
        tempStatTextList.Add(stat_Deception_Text);

        tempStatTextList.Add(stat_Dexterity_Text);
        tempStatTextList.Add(stat_Strength_Text);
        tempStatTextList.Add(stat_Puzzle_Text);
        tempStatTextList.Add(stat_Consentration_Text);
        tempStatTextList.Add(stat_Endurance_Text);

        tempStatTextList.Add(stat_Loyality_Text);
        tempStatTextList.Add(stat_Strategic_Text);
        tempStatTextList.Add(stat_SelfControl_Text);
        tempStatTextList.Add(stat_Advantages_Text);
        tempStatTextList.Add(stat_Survival_Text);

        for (int i = 0; i < tempStatTextList.Count; i++)
        {
            tempStatTextList[i].color = new Color(0, 0, 0, 1);
        }
        #endregion

        //set color lowest
        #region
        int count_low = int.MaxValue;
        for (int i = 0; i < tempStatList.Count; i++)
        {
            if (tempStatList[i] < count_low)
            {
                count_low = tempStatList[i];
            }
        }

        for (int i = 0; i < tempStatList.Count; i++)
        {
            if (tempStatList[i] == count_low)
            {
                tempStatTextList[i].color = lowest_Color;
            }
        }
        #endregion

        //set color higher
        #region
        int count_high = int.MinValue;
        for (int i = 0; i < tempStatList.Count; i++)
        {
            if (tempStatList[i] > count_high && tempStatList[i] < 6)
            {
                count_high = tempStatList[i];
            }
        }

        for (int i = 0; i < tempStatList.Count; i++)
        {
            if (tempStatList[i] == count_high)
            {
                tempStatTextList[i].color = highest_Color;
            }
        }
        #endregion

        //set color best
        #region
        for (int i = 0; i < tempStatList.Count; i++)
        {
            if (tempStatList[i] >= 6)
            {
                tempStatTextList[i].color = best_Color;
            }
        }
        #endregion

        #endregion

        //Set Tier BG Color
        switch (character_SO.character_List[index].tier)
        {
            case Tier.None:
                bg_Image.color = normal_Color;
                break;
            case Tier.Normal:
                bg_Image.color = normal_Color;
                break;
            case Tier.Rare:
                bg_Image.color = rare_Color;
                break;
            case Tier.Epic:
                bg_Image.color = epic_Color;
                break;
            case Tier.Legenday:
                bg_Image.color = legendaryl_Color;
                break;

            default:
                bg_Image.color = normal_Color;
                break;
        }
    }
}