using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class ChallengeCreator : MonoBehaviour
{
    #region Variables
    [SerializeField] Challenges_SO challenges_SO;

    [Header("UI")]
    [SerializeField] TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI subName;
    [SerializeField] Image challengeImage;
    [SerializeField] Image challengeType;

    [SerializeField] GameObject requirementSlot_Parent;
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

    [Header("Arrow Sprites")]
    [SerializeField] Sprite requirement_Increasing;
    [SerializeField] Sprite requirement_Decreasing;

    [Header("Lists")]
    public List<GameObject> requirementSlotList = new List<GameObject>();
    #endregion


    //--------------------


    private void Update()
    {
        if (challenges_SO.requirementSlotList.Count > 0)
        {
            //Get the latest challenge card built
            BuildChallengeCard(challenges_SO.requirementSlotList.Count - 1);
        }
    }


    //--------------------


    void BuildChallengeCard(int index)
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
            //Instantiate a requirementSlot
            requirementSlotList.Add(Instantiate(requirementSlot_Prefab, requirementSlot_Parent.transform));
            requirementSlot_Parent.GetComponent<VerticalLayoutGroup>().spacing = challenges_SO.requirementSlotList[index].spacing;
            RequirementSlot slot = requirementSlotList[requirementSlotList.Count - 1].GetComponent<RequirementSlot>();

            //Add Dice
            slot.componentsList.Add(Instantiate(dice_Image, slot.components_Parent.transform));
            slot.componentsList[slot.componentsList.Count - 1].GetComponent<Image>().sprite = SetDiceSprite(challenges_SO.requirementSlotList[index].requirementSlots[i].diceType);

            AddSign(slot, ":");

            //Add amount of Stats
            for (int j = 0; j < challenges_SO.requirementSlotList[index].requirementSlots[i].stats.Count; j++)
            {
                slot.componentsList.Add(Instantiate(stat_Image, slot.components_Parent.transform));
                slot.componentsList[slot.componentsList.Count - 1].GetComponent<Image>().sprite = SetStatSprite(challenges_SO.requirementSlotList[index].requirementSlots[i].stats[j]);

                if ((j + 1) >= challenges_SO.requirementSlotList[index].requirementSlots[i].stats.Count)
                {

                }
                else if (challenges_SO.requirementSlotList[index].requirementSlots[i].stats.Count > 1)
                {
                    AddSign(slot, "+");
                }
            }
            AddSign(slot, ":");

            //Add Requirement
            slot.componentsList.Add(Instantiate(requirementText, slot.components_Parent.transform));
            slot.componentsList[slot.componentsList.Count - 1].GetComponent<TextMeshProUGUI>().text = challenges_SO.requirementSlotList[index].requirementSlots[i].requirement.ToString();

            //Add Requirement Chaning
            switch (challenges_SO.requirementSlotList[index].requirementSlots[i].requirementChange)
            {
                case requirementChange.None:
                    break;

                case requirementChange.Increasing:
                    slot.componentsList[slot.componentsList.Count - 1].GetComponent<TextMeshProUGUI>().text += "<sprite=29>";
                    break;
                case requirementChange.Decreasing:
                    slot.componentsList[slot.componentsList.Count - 1].GetComponent<TextMeshProUGUI>().text += "<sprite=30>";
                    break;

                default:
                    break;
            }

            //Check if adding "repeat"
            if (challenges_SO.requirementSlotList[index].requirementSlots[i].repeat > 0)
            {
                AddSign(slot, "|");

                slot.componentsList.Add(Instantiate(repeatText, slot.components_Parent.transform));
                slot.componentsList[slot.componentsList.Count - 1].GetComponent<TextMeshProUGUI>().text = "[" + challenges_SO.requirementSlotList[index].requirementSlots[i].repeat.ToString() + "]";
            }

            //Set size
            slot.gameObject.GetComponent<HorizontalLayoutGroup>().spacing = challenges_SO.requirementSlotList[index].requirementSlots[i].spacing;
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

[CreateAssetMenu]
public class Challenges_SO : ScriptableObject
{
    public List<Challenge> requirementSlotList = new List<Challenge>();
}

[Serializable]
public class Challenge
{
    public string name;
    public string subName;
    public Sprite ChallengeType_Image;

    public bool isMerged;

    public float spacing = 100;

    public List<RequirementSlotInfo> requirementSlots = new List<RequirementSlotInfo>();
}

[Serializable]
public class RequirementSlotInfo
{
    public dice diceType;
    public List<Stats> stats;
    public int requirement;
    public requirementChange requirementChange;
    public int repeat;

    public float spacing;
}

public enum requirementChange
{
    None,

    Increasing,
    Decreasing
}