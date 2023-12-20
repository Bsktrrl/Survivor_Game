using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class DailyTaskCreator : Singleton<DailyTaskCreator>
{
    [Header("_SO")]
    public DailyTask_SO dailyTask_SO;

    [Header("Prefab")]
    [SerializeField] GameObject requirementSlot_Parent;
    [SerializeField] GameObject requirementSlot_Prefab;

    [Header("General")]
    [SerializeField] TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] TextMeshProUGUI reward;

    [SerializeField] GameObject requirementSlot;

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

    [Header("Reward Header Text")]
    [TextArea(3, 10)] public string contributorRewardHeader;
    [TextArea(3, 10)] public string generalRewardHeader;
    [TextArea(3, 10)] public string punishmentHeader;

    public bool isScreenshoting;


    //--------------------


    private void Update()
    {
        if (!isScreenshoting)
        {
            BuildDailyTaskCard(dailyTask_SO.dailyTaskList.Count - 1);
        }
    }


    //--------------------


    public void BuildDailyTaskCard(int index)
    {
        //Set Name
        name.text = dailyTask_SO.dailyTaskList[index].name;
        description.text = dailyTask_SO.dailyTaskList[index].description;

        //Set Requirement
        #region
        //Reset "requirementSlotList"
        DestroyImmediate(requirementSlot);
        requirementSlot = null;

        //Set new RequirementSlots
        //Instantiate a requirementSlot
        requirementSlot = Instantiate(requirementSlot_Prefab, requirementSlot_Parent.transform);
        requirementSlot_Parent.GetComponent<VerticalLayoutGroup>().spacing = dailyTask_SO.dailyTaskList[index].requirementSlot.spacing;
        RequirementSlot slot = requirementSlot.GetComponent<RequirementSlot>();

        //Add Dice
        slot.componentsList.Add(Instantiate(dice_Image, slot.components_Parent.transform));
        slot.componentsList[slot.componentsList.Count - 1].GetComponent<Image>().sprite = SetDiceSprite(dailyTask_SO.dailyTaskList[index].requirementSlot.diceType);

        AddSign(slot, ":");

        //Add amount of Stats
        for (int j = 0; j < dailyTask_SO.dailyTaskList[index].requirementSlot.stats.Count; j++)
        {
            slot.componentsList.Add(Instantiate(stat_Image, slot.components_Parent.transform));
            slot.componentsList[slot.componentsList.Count - 1].GetComponent<Image>().sprite = SetStatSprite(dailyTask_SO.dailyTaskList[index].requirementSlot.stats[j]);

            if ((j + 1) >= dailyTask_SO.dailyTaskList[index].requirementSlot.stats.Count)
            {

            }
            else if (dailyTask_SO.dailyTaskList[index].requirementSlot.stats.Count > 1)
            {
                AddSign(slot, "+");
            }
        }

        AddSign(slot, ":");

        //Add Requirement
        slot.componentsList.Add(Instantiate(requirementText, slot.components_Parent.transform));
        slot.componentsList[slot.componentsList.Count - 1].GetComponent<TextMeshProUGUI>().text = dailyTask_SO.dailyTaskList[index].requirementSlot.requirement.ToString();

        //Add Requirement Chaning
        switch (dailyTask_SO.dailyTaskList[index].requirementSlot.requirementChange)
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
        if (dailyTask_SO.dailyTaskList[index].requirementSlot.repeat > 0)
        {
            AddSign(slot, "|");

            slot.componentsList.Add(Instantiate(repeatText, slot.components_Parent.transform));
            slot.componentsList[slot.componentsList.Count - 1].GetComponent<TextMeshProUGUI>().text = "[" + dailyTask_SO.dailyTaskList[index].requirementSlot.repeat.ToString() + "]";
        }

        //Set size
        slot.gameObject.GetComponent<HorizontalLayoutGroup>().spacing = dailyTask_SO.dailyTaskList[index].requirementSlot.spacing;
        #endregion

        //Set Reward Text
        reward.text = contributorRewardHeader;
        reward.text += dailyTask_SO.dailyTaskList[index].contributorReward + "\n";
        reward.text += generalRewardHeader;
        reward.text += dailyTask_SO.dailyTaskList[index].generalReward + "\n";
        reward.text += punishmentHeader;
        reward.text += dailyTask_SO.dailyTaskList[index].punishment + "\n";
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