using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class CharacterCreator : MonoBehaviour
{
    public static CharacterCreator instance { get; private set; }

    #region Variables
    [SerializeField] Character_SO character_SO;

    [Header("Stats")]
    public string name;
    public Sprite image;
    public Season season;
    public int popularity;
    [TextArea(3, 10)] public string ability;

    [Space(10)]
    public int morale;

    [Space(10)]
    public int stat_Relationship;
    public int stat_Charisma;
    public int stat_Intuision;
    public int stat_Persuation;
    public int stat_Deception;
    
    [Space(10)]
    public int stat_Dexterity;
    public int stat_Strength;
    public int stat_Puzzle;
    public int stat_Consentration;
    public int stat_Endurance;

    [Space(10)]
    public int stat_Loyality;
    public int stat_Strategic;
    public int stat_SelfControl;
    public int stat_Advantages;
    public int stat_Survival;

    [Space(100)]
    [Header("Name_text")]
    [SerializeField] TextMeshProUGUI name_Text;

    [Header("Image_sprite")]
    [SerializeField] Image character_image;

    [Header("Ability_text")]
    [SerializeField] TextMeshProUGUI ability_text;

    [Header("Popularity_text")]
    [SerializeField] TextMeshProUGUI popularity_text;

    [Header("Morale_Track")]
    [SerializeField] Image morale_Track;
    [SerializeField] Sprite morale_1;
    [SerializeField] Sprite morale_2;
    [SerializeField] Sprite morale_3;
    [SerializeField] Sprite morale_4;
    [SerializeField] Sprite morale_5;
    [SerializeField] Sprite morale_6;
    [SerializeField] Sprite morale_7;
    [SerializeField] Sprite morale_8;
    [SerializeField] Sprite morale_9;
    [SerializeField] Sprite morale_10;

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
    [SerializeField] Image season_Logo;

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


    //--------------------


    private void Awake()
    {
        //Singleton
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
        }
    }
    private void Update()
    {
        //Set Character Name
        #region
        name_Text.text = name;
        #endregion

        //Set Image
        #region
        character_image.sprite = image;
        #endregion

        //Set Season Logo
        switch (season)
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
        popularity_text.text = popularity.ToString();
        #endregion

        //Set Ability
        #region
        ability_text.text = "<size=130%><b><U>Ability</b></U>\r\n<size=20%>\r\n<size=100%>" + ability;
        #endregion

        //Set Morale_Track
        switch (morale)
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
        stat_Relationship_Text.text = stat_Relationship.ToString();
        stat_Charisma_Text.text = stat_Charisma.ToString();
        stat_Intuision_Text.text = stat_Intuision.ToString();
        stat_Persuation_Text.text = stat_Persuation.ToString();
        stat_Deception_Text.text = stat_Deception.ToString();

        stat_Dexterity_Text.text = stat_Dexterity.ToString();
        stat_Strength_Text.text = stat_Strength.ToString();
        stat_Puzzle_Text.text = stat_Puzzle.ToString();
        stat_Consentration_Text.text = stat_Consentration.ToString();
        stat_Endurance_Text.text = stat_Endurance.ToString();

        stat_Loyality_Text.text = stat_Loyality.ToString();
        stat_Strategic_Text.text = stat_Strategic.ToString();
        stat_SelfControl_Text.text = stat_SelfControl.ToString();
        stat_Advantages_Text.text = stat_Advantages.ToString();
        stat_Survival_Text.text = stat_Survival.ToString();
        #endregion
    }


    //--------------------


    public void AddButton_isPressed()
    {
        Character character = new Character();

        character.name = name;
        character.image = image;
        character.season = season;

        character.popularity = popularity;
        character.morale = morale;

        character.ability = ability;

        character.Relationship = stat_Relationship;
        character.Charisma = stat_Charisma;
        character.Intuision = stat_Intuision;
        character.Persuation = stat_Persuation;
        character.Deception = stat_Deception;

        character.Dexterity = stat_Dexterity;
        character.Strength = stat_Strength;
        character.Puzzle = stat_Puzzle;
        character.Consentration = stat_Consentration;
        character.Endurance = stat_Endurance;

        character.Loyality = stat_Loyality;
        character.Strategic = stat_Strategic;
        character.SelfControl = stat_SelfControl;
        character.Advantages = stat_Advantages;
        character.Survival = stat_Survival;

        character_SO.character_List.Add(character);
    }
}

public enum Season
{
    Season_1_Boreno,
    Season_2_AustralianOutback,
    Season_3_Africa,
    Season_4_Marquesas,
    Season_5_Thailand,
    Season_6_Amazonas,
    Season_7_PearIsland,
    Season_8_AllStars,
    Season_9_Vanuatu,
    Season_10_Palau,

    Season_11_Guatemala,
    Season_12_Panama,
    Season_13_CookIsland,
    Season_14_Fiji,
    Season_15_China,
    Season_16_FansVsFavorites,
    Season_17_Gabon,
    Season_18_Tocantins,
    Season_19_Samoa,
    Season_20_HeroVsVillians,

    Season_21_Nicaragua,
    Season_22_RedemtionIsland,
    Season_23_SouthPacific,
    Season_24_OneWorld,
    Season_25_Philippines,
    Season_26_Caramoan,
    Season_27_BloodVsWater,
    Season_28_Cagayan,
    Season_29_BloodVsWater2,
    Season_30_WorldApart,

    Season_31_SecondChance,
    Season_32_KaohRong,
    Season_33_MillenialsVsGenX,
    Season_34_GameChangers,
    Season_35_HeroesVsHealersVsHustlers,
    Season_36_GhostIsland,
    Season_37_DavidVsGoliath,
    Season_38_EdgeOfExtinction,
    Season_39_IslandOfTheIdols,
    Season_40_WinnersAtWar
}