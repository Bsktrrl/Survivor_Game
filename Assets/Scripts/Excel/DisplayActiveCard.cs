using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayActiveCard : Singleton<DisplayActiveCard>
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

    [Header("Stat Colors")]
    public Color lowest_Color;
    public Color highest_Color;
    public Color best_Color;

    [Header("Season_Logo")]
    public Image season_Logo;


    //--------------------


    private void Update()
    {
        ControlPanel.Instance.UpdateActiveDataObject();

        ReadExcelFile.Instance.ReadExcelSheet();

        SetDisplay();
    }


    //--------------------


    public void SetDisplay()
    {
        if (ControlPanel.Instance.activeDataObject != null)
        {
            name_Text.text = ControlPanel.Instance.activeDataObject.fullName;

            string imageNameTemp = "CastawaysImages/" + GetSeasonName(ControlPanel.Instance.activeDataObject.season) + "/" + ControlPanel.Instance.activeDataObject.fullName;
            character_image.sprite = Resources.Load<Sprite>(imageNameTemp);

            ability_text.text = ControlPanel.Instance.activeDataObject.ability;
            popularity_text.text = ControlPanel.Instance.activeDataObject.popularity.ToString();
            GetMoraleSprite(ControlPanel.Instance.activeDataObject.morale);

            string seasonNameTemp = "Logo/" + GetSeasonName(ControlPanel.Instance.activeDataObject.season);
            season_Logo.sprite = Resources.Load<Sprite>(seasonNameTemp);

            stat_Relationship_Text.text = ControlPanel.Instance.activeDataObject.outwit_Relation.ToString();
            stat_Charisma_Text.text = ControlPanel.Instance.activeDataObject.outwit_Charisma.ToString();
            stat_Intuision_Text.text = ControlPanel.Instance.activeDataObject.outwit_Intuition.ToString();
            stat_Persuation_Text.text = ControlPanel.Instance.activeDataObject.outwit_Persuasion.ToString();
            stat_Deception_Text.text = ControlPanel.Instance.activeDataObject.outwit_Deception.ToString();

            stat_Dexterity_Text.text = ControlPanel.Instance.activeDataObject.outplay_Dexterity.ToString();
            stat_Strength_Text.text = ControlPanel.Instance.activeDataObject.outplay_Strength.ToString();
            stat_Puzzle_Text.text = ControlPanel.Instance.activeDataObject.outplay_Puzzle.ToString();
            stat_Consentration_Text.text = ControlPanel.Instance.activeDataObject.outplay_Concentration.ToString();
            stat_Endurance_Text.text = ControlPanel.Instance.activeDataObject.outplay_Endurance.ToString();

            stat_Loyality_Text.text = ControlPanel.Instance.activeDataObject.outlast_Loyalty.ToString();
            stat_Strategic_Text.text = ControlPanel.Instance.activeDataObject.outlast_Strategic.ToString();
            stat_SelfControl_Text.text = ControlPanel.Instance.activeDataObject.outlast_SelfControl.ToString();
            stat_Advantages_Text.text = ControlPanel.Instance.activeDataObject.outlast_Advantages.ToString();
            stat_Survival_Text.text = ControlPanel.Instance.activeDataObject.outlast_Survival.ToString();

            //Set Color on StatText
            GetStatNumberColors(stat_Relationship_Text);
            GetStatNumberColors(stat_Charisma_Text);
            GetStatNumberColors(stat_Intuision_Text);
            GetStatNumberColors(stat_Persuation_Text);
            GetStatNumberColors(stat_Deception_Text);

            GetStatNumberColors(stat_Dexterity_Text);
            GetStatNumberColors(stat_Strength_Text);
            GetStatNumberColors(stat_Puzzle_Text);
            GetStatNumberColors(stat_Consentration_Text);
            GetStatNumberColors(stat_Endurance_Text);

            GetStatNumberColors(stat_Loyality_Text);
            GetStatNumberColors(stat_Strategic_Text);
            GetStatNumberColors(stat_SelfControl_Text);
            GetStatNumberColors(stat_Advantages_Text);
            GetStatNumberColors(stat_Survival_Text);
        }
        else
        {
            name_Text.text = "";

            character_image.sprite = null;

            ability_text.text = "";
            popularity_text.text = "";
            morale_Track.sprite = null;

            stat_Relationship_Text.text = "";
            stat_Charisma_Text.text = "";
            stat_Intuision_Text.text = "";
            stat_Persuation_Text.text = "";
            stat_Deception_Text.text = "";

            stat_Dexterity_Text.text = "";
            stat_Strength_Text.text = "";
            stat_Puzzle_Text.text = "";
            stat_Consentration_Text.text = "";
            stat_Endurance_Text.text = "";

            stat_Loyality_Text.text = "";
            stat_Strategic_Text.text = "";
            stat_SelfControl_Text.text = "";
            stat_Advantages_Text.text = "";
            stat_Survival_Text.text = "";
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
    void GetMoraleSprite(string morale)
    {
        if (morale == "1")
            morale_Track.sprite = morale_1;
        else if (morale == "2")
            morale_Track.sprite = morale_2;
        else if (morale == "3")
            morale_Track.sprite = morale_3;
        else if (morale == "4")
            morale_Track.sprite = morale_4;
        else if (morale == "5")
            morale_Track.sprite = morale_5;
        else if (morale == "6")
            morale_Track.sprite = morale_6;
        else if (morale == "7")
            morale_Track.sprite = morale_7;
        else if (morale == "8")
            morale_Track.sprite = morale_8;
        else if (morale == "9")
            morale_Track.sprite = morale_9;
        else if (morale == "10")
            morale_Track.sprite = morale_10;
        else
            morale_Track.sprite = null;
    }

    int GetLowestStatNumber()
    {
        int lowestNumber = 0;

        lowestNumber = int.Parse(stat_Relationship_Text.text);

        if (int.Parse(stat_Charisma_Text.text) < lowestNumber && int.Parse(stat_Charisma_Text.text) >= 0)
            lowestNumber = int.Parse(stat_Charisma_Text.text);
        if (int.Parse(stat_Intuision_Text.text) < lowestNumber && int.Parse(stat_Intuision_Text.text) >= 0)
            lowestNumber = int.Parse(stat_Intuision_Text.text);
        if (int.Parse(stat_Persuation_Text.text) < lowestNumber && int.Parse(stat_Persuation_Text.text) >= 0)
            lowestNumber = int.Parse(stat_Persuation_Text.text);
        if (int.Parse(stat_Deception_Text.text) < lowestNumber && int.Parse(stat_Deception_Text.text) >= 0)
            lowestNumber = int.Parse(stat_Deception_Text.text);

        if (int.Parse(stat_Dexterity_Text.text) < lowestNumber && int.Parse(stat_Dexterity_Text.text) >= 0)
            lowestNumber = int.Parse(stat_Dexterity_Text.text);
        if (int.Parse(stat_Strength_Text.text) < lowestNumber && int.Parse(stat_Strength_Text.text) >= 0)
            lowestNumber = int.Parse(stat_Strength_Text.text);
        if (int.Parse(stat_Puzzle_Text.text) < lowestNumber && int.Parse(stat_Puzzle_Text.text) >= 0)
            lowestNumber = int.Parse(stat_Puzzle_Text.text);
        if (int.Parse(stat_Consentration_Text.text) < lowestNumber && int.Parse(stat_Consentration_Text.text) >= 0)
            lowestNumber = int.Parse(stat_Consentration_Text.text);
        if (int.Parse(stat_Endurance_Text.text) < lowestNumber && int.Parse(stat_Endurance_Text.text) >= 0)
            lowestNumber = int.Parse(stat_Endurance_Text.text);

        if (int.Parse(stat_Loyality_Text.text) < lowestNumber && int.Parse(stat_Loyality_Text.text) >= 0)
            lowestNumber = int.Parse(stat_Loyality_Text.text);
        if (int.Parse(stat_Strategic_Text.text) < lowestNumber && int.Parse(stat_Strategic_Text.text) >= 0)
            lowestNumber = int.Parse(stat_Strategic_Text.text);
        if (int.Parse(stat_SelfControl_Text.text) < lowestNumber && int.Parse(stat_SelfControl_Text.text) >= 0)
            lowestNumber = int.Parse(stat_SelfControl_Text.text);
        if (int.Parse(stat_Advantages_Text.text) < lowestNumber && int.Parse(stat_Advantages_Text.text) >= 0)
            lowestNumber = int.Parse(stat_Advantages_Text.text);
        if (int.Parse(stat_Survival_Text.text) < lowestNumber && int.Parse(stat_Survival_Text.text) >= 0)
            lowestNumber = int.Parse(stat_Survival_Text.text);

        return lowestNumber;
    }
    int GetHighestStatNumber()
    {
        int lowestNumber = 0;

        lowestNumber = int.Parse(stat_Relationship_Text.text);

        if (int.Parse(stat_Charisma_Text.text) > lowestNumber && int.Parse(stat_Charisma_Text.text) <= 5)
            lowestNumber = int.Parse(stat_Charisma_Text.text);
        if (int.Parse(stat_Intuision_Text.text) > lowestNumber && int.Parse(stat_Intuision_Text.text) <= 5)
            lowestNumber = int.Parse(stat_Intuision_Text.text);
        if (int.Parse(stat_Persuation_Text.text) > lowestNumber && int.Parse(stat_Persuation_Text.text) <= 5)
            lowestNumber = int.Parse(stat_Persuation_Text.text);
        if (int.Parse(stat_Deception_Text.text) > lowestNumber && int.Parse(stat_Deception_Text.text) <= 5)
            lowestNumber = int.Parse(stat_Deception_Text.text);

        if (int.Parse(stat_Dexterity_Text.text) > lowestNumber && int.Parse(stat_Dexterity_Text.text) <= 5)
            lowestNumber = int.Parse(stat_Dexterity_Text.text);
        if (int.Parse(stat_Strength_Text.text) > lowestNumber && int.Parse(stat_Strength_Text.text) <= 5)
            lowestNumber = int.Parse(stat_Strength_Text.text);
        if (int.Parse(stat_Puzzle_Text.text) > lowestNumber && int.Parse(stat_Puzzle_Text.text) <= 5)
            lowestNumber = int.Parse(stat_Puzzle_Text.text);
        if (int.Parse(stat_Consentration_Text.text) > lowestNumber && int.Parse(stat_Consentration_Text.text) <= 5)
            lowestNumber = int.Parse(stat_Consentration_Text.text);
        if (int.Parse(stat_Endurance_Text.text) > lowestNumber && int.Parse(stat_Endurance_Text.text) <= 5)
            lowestNumber = int.Parse(stat_Endurance_Text.text);

        if (int.Parse(stat_Loyality_Text.text) > lowestNumber && int.Parse(stat_Loyality_Text.text) <= 5)
            lowestNumber = int.Parse(stat_Loyality_Text.text);
        if (int.Parse(stat_Strategic_Text.text) > lowestNumber && int.Parse(stat_Strategic_Text.text) <= 5)
            lowestNumber = int.Parse(stat_Strategic_Text.text);
        if (int.Parse(stat_SelfControl_Text.text) > lowestNumber && int.Parse(stat_SelfControl_Text.text) <= 5)
            lowestNumber = int.Parse(stat_SelfControl_Text.text);
        if (int.Parse(stat_Advantages_Text.text) > lowestNumber && int.Parse(stat_Advantages_Text.text) <= 5)
            lowestNumber = int.Parse(stat_Advantages_Text.text);
        if (int.Parse(stat_Survival_Text.text) > lowestNumber && int.Parse(stat_Survival_Text.text) <= 5)
            lowestNumber = int.Parse(stat_Survival_Text.text);

        return lowestNumber;
    }

    void GetStatNumberColors(TextMeshProUGUI text)
    {
        text.color = Color.black;

        if (int.Parse(text.text) == GetLowestStatNumber())
            text.color = lowest_Color;
        else if (int.Parse(text.text) == GetHighestStatNumber())
            text.color = highest_Color;
        else if (int.Parse(text.text) > GetHighestStatNumber())
            text.color = best_Color;
        else
            text.color = Color.black;
    }
}
