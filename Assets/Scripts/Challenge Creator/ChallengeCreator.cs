using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ChallengeCreator : Singleton<ChallengeCreator>
{
    #region Variables
    public Challenges_SO challenges_SO;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI subName;
    [SerializeField] Image challengeImage;
    [SerializeField] Image challengeType;

    [SerializeField] GameObject requirementSlot_Parent_1;
    [SerializeField] GameObject requirementSlot_Parent_2;
    [SerializeField] GameObject requirementSlot_Parent_3;
    [SerializeField] GameObject requirementSlot_Prefab;

    [Header("Components")]
    [SerializeField] Sprite challengeType_Tribal;
    [SerializeField] Sprite challengeType_Merged;

    [Header("RequirementSlot Prefabs")]
    public GameObject dice_Image;
    public GameObject stat_Image;

    public GameObject plussSign;
    public GameObject colonSign;
    public GameObject breakSign;
    public GameObject requirementText;
    public GameObject repeatText;
    public GameObject description;

    [Header("Dice Sprites")]
    [SerializeField] Sprite dice_1;
    [SerializeField] Sprite dice_2;
    [SerializeField] Sprite dice_3;
    [SerializeField] Sprite dice_4;
    [SerializeField] Sprite dice_5;
    [SerializeField] Sprite dice_6;
    [SerializeField] Sprite dice_7;
    [SerializeField] Sprite dice_8;
    [SerializeField] Sprite dice_9;
    [SerializeField] Sprite dice_10;
    [SerializeField] Sprite dice_11;

    [Header("Stat Sprites")]
    [SerializeField] Sprite stat_Relationship;
    [SerializeField] Sprite stat_Charisma;
    [SerializeField] Sprite stat_Intuition;
    [SerializeField] Sprite stat_Perseption;
    [SerializeField] Sprite stat_Deception;

    [SerializeField] Sprite stat_Dexterity;
    [SerializeField] Sprite stat_Strength;
    [SerializeField] Sprite stat_Puzzle;
    [SerializeField] Sprite stat_Consentration;
    [SerializeField] Sprite stat_Endurance;

    [SerializeField] Sprite stat_Loyalty;
    [SerializeField] Sprite stat_Strategic;
    [SerializeField] Sprite stat_SelfControl;
    [SerializeField] Sprite stat_AdvantageHunting;
    [SerializeField] Sprite stat_Survival;

    [Header("Box Sprites")]
    [SerializeField] Sprite requirementBox_Upper;
    [SerializeField] Sprite requirementBox_Lower;

    [Header("Lists")]
    public List<GameObject> requirementSlotList = new List<GameObject>();
    #endregion

    public bool isScreenshoting;


    //--------------------


    private void Update()
    {
        if (challenges_SO.requirementSlotList.Count > 0 && !isScreenshoting)
        {
            //Get the latest challenge card built
            BuildChallengeCard(challenges_SO.requirementSlotList.Count - 1);
        }
    }


    //--------------------


    public void BuildChallengeCard(int index)
    {
        //Set Name
        name.text = challenges_SO.requirementSlotList[index].name;
        subName.text = challenges_SO.requirementSlotList[index].subName;

        //Set challenge Image
        challengeImage.sprite = challenges_SO.requirementSlotList[index].ChallengeType_Image;

        //Set Challenge Type
        if (challenges_SO.requirementSlotList[index].isMerged)
            challengeType.sprite = challengeType_Merged;
        else
            challengeType.sprite = challengeType_Tribal;

        //Reset "requirementSlotList"
        for (int i = requirementSlotList.Count - 1; i >= 0; i--)
        {
            DestroyImmediate(requirementSlotList[i]);
        }
        requirementSlotList.Clear();

        //Set new RequirementSlots
        for (int i = 0; i < challenges_SO.requirementSlotList[index].requirementSlots.Count; i++)
        {
            //Set RequirementSlot Parent
            GameObject tempParent = null;
            if (i <= 0)
            { 
                tempParent = requirementSlot_Parent_1;
            }
            else if (i == 1)
            {
                tempParent = requirementSlot_Parent_2;
            }
            else if (i >= 2)
            {
                tempParent = requirementSlot_Parent_3;
            }

            //Instantiate Description
            requirementSlotList.Add(Instantiate(requirementSlot_Prefab, tempParent.transform));
            RequirementSlot slot_1 = requirementSlotList[requirementSlotList.Count - 1].GetComponent<RequirementSlot>();

            //Add Box_Sprite to RequirementSlots
            slot_1.GetComponent<Image>().sprite = requirementBox_Upper;

            //Add text to Description
            slot_1.componentsList.Add(Instantiate(description, slot_1.components_Parent.transform));
            slot_1.componentsList[slot_1.componentsList.Count - 1].GetComponent<TextMeshProUGUI>().text = challenges_SO.requirementSlotList[index].requirementSlots[i].description;


            //-----


            //Instantiate a requirementSlot
            requirementSlotList.Add(Instantiate(requirementSlot_Prefab, tempParent.transform));
            RequirementSlot slot_2 = requirementSlotList[requirementSlotList.Count - 1].GetComponent<RequirementSlot>();

            //Add Box_Sprite to RequirementSlots
            slot_2.GetComponent<Image>().sprite = requirementBox_Lower;

            //Add Dice
            slot_2.componentsList.Add(Instantiate(dice_Image, slot_2.components_Parent.transform));
            slot_2.componentsList[slot_2.componentsList.Count - 1].GetComponent<Image>().sprite = SetDiceSprite(challenges_SO.requirementSlotList[index].requirementSlots[i].diceType);

            AddSign(slot_2, ":");

            //Add amount of Stats
            for (int j = 0; j < challenges_SO.requirementSlotList[index].requirementSlots[i].stats.Count; j++)
            {
                slot_2.componentsList.Add(Instantiate(stat_Image, slot_2.components_Parent.transform));
                slot_2.componentsList[slot_2.componentsList.Count - 1].GetComponent<Image>().sprite = SetStatSprite(challenges_SO.requirementSlotList[index].requirementSlots[i].stats[j]);

                if ((j + 1) >= challenges_SO.requirementSlotList[index].requirementSlots[i].stats.Count)
                {

                }
                else if (challenges_SO.requirementSlotList[index].requirementSlots[i].stats.Count > 1)
                {
                    AddSign(slot_2, "+");
                }
            }
            AddSign(slot_2, ":");

            //Add Requirement
            slot_2.componentsList.Add(Instantiate(requirementText, slot_2.components_Parent.transform));
            slot_2.componentsList[slot_2.componentsList.Count - 1].GetComponent<TextMeshProUGUI>().text = challenges_SO.requirementSlotList[index].requirementSlots[i].requirement.ToString();

            //Add Requirement Chaning
            switch (challenges_SO.requirementSlotList[index].requirementSlots[i].requirementChange)
            {
                case requirementChange.None:
                    break;

                case requirementChange.Increasing:
                    slot_2.componentsList[slot_2.componentsList.Count - 1].GetComponent<TextMeshProUGUI>().text += "<sprite=29>";
                    break;
                case requirementChange.Decreasing:
                    slot_2.componentsList[slot_2.componentsList.Count - 1].GetComponent<TextMeshProUGUI>().text += "<sprite=30>";
                    break;

                default:
                    break;
            }

            //Check if adding "repeat"
            if (challenges_SO.requirementSlotList[index].requirementSlots[i].repeat > 0)
            {
                AddSign(slot_2, "|");

                slot_2.componentsList.Add(Instantiate(repeatText, slot_2.components_Parent.transform));
                slot_2.componentsList[slot_2.componentsList.Count - 1].GetComponent<TextMeshProUGUI>().text = "[" + challenges_SO.requirementSlotList[index].requirementSlots[i].repeat.ToString() + "]";
            }

            //Set size
            slot_2.gameObject.GetComponent<HorizontalLayoutGroup>().spacing = challenges_SO.requirementSlotList[index].requirementSlots[i].spacing;
        }
    }

    void AddSign(RequirementSlot slot, string sign)
    {
        switch (sign)
        {
            case ":":
                slot.componentsList.Add(Instantiate(colonSign, slot.components_Parent.transform));
                break;

            case "+":
                slot.componentsList.Add(Instantiate(plussSign, slot.components_Parent.transform));
                break;

            case "|":
                slot.componentsList.Add(Instantiate(breakSign, slot.components_Parent.transform));
                break;

            default:
                break;
        }
    }

    Sprite SetDiceSprite(dice sprite)
    {
        switch (sprite)
        {
            case dice.None:
                return null;
                break;

            case dice.Dice_1:
                return dice_1;
            case dice.Dice_2:
                return dice_2;
            case dice.Dice_3:
                return dice_3;
            case dice.Dice_4:
                return dice_4;
            case dice.Dice_5:
                return dice_5;
            case dice.Dice_6:
                return dice_6;
            case dice.Dice_7:
                return dice_7;
            case dice.Dice_8:
                return dice_8;
            case dice.Dice_9:
                return dice_9;
            case dice.Dice_10:
                return dice_10;
            case dice.Dice_11:
                return dice_11;

            default:
                return null;
        }
    }

    Sprite SetStatSprite(Stats sprite)
    {
        switch (sprite)
        {
            case Stats.None:
                return null;

            case Stats.Relationship:
                return stat_Relationship;
            case Stats.Charisma:
                return stat_Charisma;
            case Stats.Intuition:
                return stat_Intuition;
            case Stats.Perception:
                return stat_Perseption;
            case Stats.Deception:
                return stat_Deception;
            case Stats.Dexterity:
                return stat_Dexterity;
            case Stats.Strength:
                return stat_Strength;
            case Stats.Puzzle:
                return stat_Puzzle;
            case Stats.Consentration:
                return stat_Consentration;
            case Stats.Endurance:
                return stat_Endurance;
            case Stats.Loyalty:
                return stat_Loyalty;
            case Stats.Strategic:
                return stat_Strategic;
            case Stats.Self_Control:
                return stat_SelfControl;
            case Stats.Advantage_Hunting:
                return stat_AdvantageHunting;
            case Stats.Survival:
                return stat_Survival;

            default:
                return null;
        }
    }
}