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

    [Header("Rewards")]
    [SerializeField] GameObject contributor_rewardBox;
    [SerializeField] Image contributor_rewardImage;
    [SerializeField] TextMeshProUGUI contributor_rewardText;

    [SerializeField] GameObject general_rewardBox;
    [SerializeField] Image general_rewardImage;
    [SerializeField] TextMeshProUGUI general_rewardText;

    [SerializeField] GameObject punishment_rewardBox;
    [SerializeField] Image punishment_rewardImage;
    [SerializeField] TextMeshProUGUI punishment_rewardText;

    public bool isScreenshoting;

    #region Reward Images
    [Header("Reward Images")]
    [SerializeField] Sprite Outwit_Coin;
    [SerializeField] Sprite Outplay_Coin;
    [SerializeField] Sprite Outlast_Coin;

    [SerializeField] Sprite PressureToken;

    [SerializeField] Sprite Quest;
    [SerializeField] Sprite TribalCard;

    [SerializeField] Sprite MoraleUP;
    [SerializeField] Sprite MoraleDown;

    [SerializeField] Sprite Stat_Relationship_UP;
    [SerializeField] Sprite Stat_Charisma_UP;
    [SerializeField] Sprite Stat_Intuition_UP;
    [SerializeField] Sprite Stat_Perception_UP;
    [SerializeField] Sprite Stat_Deception_UP;

    [SerializeField] Sprite Stat_Dexterity_UP;
    [SerializeField] Sprite Stat_Strength_UP;
    [SerializeField] Sprite Stat_Puzzle_UP;
    [SerializeField] Sprite Stat_Consentration_UP;
    [SerializeField] Sprite Stat_Endurance_UP;

    [SerializeField] Sprite Stat_Loyalty_UP;
    [SerializeField] Sprite Stat_Strategic_UP;
    [SerializeField] Sprite Stat_SelfControl_UP;
    [SerializeField] Sprite Stat_AdvantageHunting_UP;
    [SerializeField] Sprite Stat_Survival_UP;

    [SerializeField] Sprite Stat_Relationship_DOWN;
    [SerializeField] Sprite Stat_Charisma_DOWN;
    [SerializeField] Sprite Stat_Intuition_DOWN;
    [SerializeField] Sprite Stat_Perception_DOWN;
    [SerializeField] Sprite Stat_Deception_DOWN;

    [SerializeField] Sprite Stat_Dexterity_DOWN;
    [SerializeField] Sprite Stat_Strength_DOWN;
    [SerializeField] Sprite Stat_Puzzle_DOWN;
    [SerializeField] Sprite Stat_Consentration_DOWN;
    [SerializeField] Sprite Stat_Endurance_DOWN;

    [SerializeField] Sprite Stat_Loyalty_DOWN;
    [SerializeField] Sprite Stat_Strategic_DOWN;
    [SerializeField] Sprite Stat_SelfControl_DOWN;
    [SerializeField] Sprite Stat_AdvantageHunting_DOWN;
    [SerializeField] Sprite Stat_Survival_DOWN;
    #endregion


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

        //Set Contributor Reward
        if (dailyTask_SO.dailyTaskList[index].contributorReward != Rewards.None)
        {
            contributor_rewardBox.SetActive(true);
            contributor_rewardText.text = dailyTask_SO.dailyTaskList[index].contributorReward_amount.ToString();

            switch (dailyTask_SO.dailyTaskList[index].contributorReward)
            {
                case Rewards.None:
                    contributor_rewardImage.sprite = null;
                    break;

                case Rewards.Outwit_Coin:
                    contributor_rewardImage.sprite = Outwit_Coin;
                    break;
                case Rewards.Outplay_Coin:
                    contributor_rewardImage.sprite = Outwit_Coin;
                    break;
                case Rewards.Outlast_Coin:
                    contributor_rewardImage.sprite = Outlast_Coin;
                    break;
                case Rewards.PressureToken:
                    contributor_rewardImage.sprite = PressureToken;
                    break;
                case Rewards.Quest:
                    contributor_rewardImage.sprite = Quest;
                    break;
                case Rewards.TribalCard:
                    contributor_rewardImage.sprite = TribalCard;
                    break;
                case Rewards.MoraleUP:
                    contributor_rewardImage.sprite = MoraleUP;
                    break;
                case Rewards.MoraleDown:
                    contributor_rewardImage.sprite = MoraleDown;
                    break;
                case Rewards.Stat_Relationship_UP:
                    contributor_rewardImage.sprite = Stat_Relationship_UP;
                    break;
                case Rewards.Stat_Charisma_UP:
                    contributor_rewardImage.sprite = Stat_Charisma_UP;
                    break;
                case Rewards.Stat_Intuition_UP:
                    contributor_rewardImage.sprite = Stat_Intuition_UP;
                    break;
                case Rewards.Stat_Perception_UP:
                    contributor_rewardImage.sprite = Stat_Perception_UP;
                    break;
                case Rewards.Stat_Deception_UP:
                    contributor_rewardImage.sprite = Stat_Deception_UP;
                    break;
                case Rewards.Stat_Dexterity_UP:
                    contributor_rewardImage.sprite = Stat_Dexterity_UP;
                    break;
                case Rewards.Stat_Strength_UP:
                    contributor_rewardImage.sprite = Stat_Strength_UP;
                    break;
                case Rewards.Stat_Puzzle_UP:
                    contributor_rewardImage.sprite = Stat_Puzzle_UP;
                    break;
                case Rewards.Stat_Consentration_UP:
                    contributor_rewardImage.sprite = Stat_Consentration_UP;
                    break;
                case Rewards.Stat_Endurance_UP:
                    contributor_rewardImage.sprite = Stat_Endurance_UP;
                    break;
                case Rewards.Stat_Loyalty_UP:
                    contributor_rewardImage.sprite = Stat_Loyalty_UP;
                    break;
                case Rewards.Stat_Strategic_UP:
                    contributor_rewardImage.sprite = Stat_Strategic_UP;
                    break;
                case Rewards.Stat_SelfControl_UP:
                    contributor_rewardImage.sprite = Stat_SelfControl_UP;
                    break;
                case Rewards.Stat_AdvantageHunting_UP:
                    contributor_rewardImage.sprite = Stat_AdvantageHunting_UP;
                    break;
                case Rewards.Stat_Survival_UP:
                    contributor_rewardImage.sprite = Stat_Survival_UP;
                    break;
                case Rewards.Stat_Relationship_DOWN:
                    contributor_rewardImage.sprite = Stat_Relationship_DOWN;
                    break;
                case Rewards.Stat_Charisma_DOWN:
                    contributor_rewardImage.sprite = Stat_Charisma_DOWN;
                    break;
                case Rewards.Stat_Intuition_DOWN:
                    contributor_rewardImage.sprite = Stat_Intuition_DOWN;
                    break;
                case Rewards.Stat_Perception_DOWN:
                    contributor_rewardImage.sprite = Stat_Perception_DOWN;
                    break;
                case Rewards.Stat_Deception_DOWN:
                    contributor_rewardImage.sprite = Stat_Deception_DOWN;
                    break;
                case Rewards.Stat_Dexterity_DOWN:
                    contributor_rewardImage.sprite = Stat_Dexterity_DOWN;
                    break;
                case Rewards.Stat_Strength_DOWN:
                    contributor_rewardImage.sprite = Stat_Strength_DOWN;
                    break;
                case Rewards.Stat_Puzzle_DOWN:
                    contributor_rewardImage.sprite = Stat_Puzzle_DOWN;
                    break;
                case Rewards.Stat_Consentration_DOWN:
                    contributor_rewardImage.sprite = Stat_Consentration_DOWN;
                    break;
                case Rewards.Stat_Endurance_DOWN:
                    contributor_rewardImage.sprite = Stat_Endurance_DOWN;
                    break;
                case Rewards.Stat_Loyalty_DOWN:
                    contributor_rewardImage.sprite = Stat_Loyalty_DOWN;
                    break;
                case Rewards.Stat_Strategic_DOWN:
                    contributor_rewardImage.sprite = Stat_Strategic_DOWN;
                    break;
                case Rewards.Stat_SelfControl_DOWN:
                    contributor_rewardImage.sprite = Stat_SelfControl_DOWN;
                    break;
                case Rewards.Stat_AdvantageHunting_DOWN:
                    contributor_rewardImage.sprite = Stat_AdvantageHunting_DOWN;
                    break;
                case Rewards.Stat_Survival_DOWN:
                    contributor_rewardImage.sprite = Stat_Survival_DOWN;
                    break;

                default:
                    break;
            }
        }
        else
        {
            contributor_rewardBox.SetActive(false);
        }

        //Set General Reward
        if (dailyTask_SO.dailyTaskList[index].generalReward != Rewards.None)
        {
            general_rewardBox.SetActive(true);
            general_rewardText.text = dailyTask_SO.dailyTaskList[index].generalReward_amount.ToString();

            switch (dailyTask_SO.dailyTaskList[index].generalReward)
            {
                case Rewards.None:
                    general_rewardImage.sprite = null;
                    break;

                case Rewards.Outwit_Coin:
                    general_rewardImage.sprite = Outwit_Coin;
                    break;
                case Rewards.Outplay_Coin:
                    general_rewardImage.sprite = Outwit_Coin;
                    break;
                case Rewards.Outlast_Coin:
                    general_rewardImage.sprite = Outlast_Coin;
                    break;
                case Rewards.PressureToken:
                    general_rewardImage.sprite = PressureToken;
                    break;
                case Rewards.Quest:
                    general_rewardImage.sprite = Quest;
                    break;
                case Rewards.TribalCard:
                    general_rewardImage.sprite = TribalCard;
                    break;
                case Rewards.MoraleUP:
                    general_rewardImage.sprite = MoraleUP;
                    break;
                case Rewards.MoraleDown:
                    general_rewardImage.sprite = MoraleDown;
                    break;
                case Rewards.Stat_Relationship_UP:
                    general_rewardImage.sprite = Stat_Relationship_UP;
                    break;
                case Rewards.Stat_Charisma_UP:
                    general_rewardImage.sprite = Stat_Charisma_UP;
                    break;
                case Rewards.Stat_Intuition_UP:
                    general_rewardImage.sprite = Stat_Intuition_UP;
                    break;
                case Rewards.Stat_Perception_UP:
                    general_rewardImage.sprite = Stat_Perception_UP;
                    break;
                case Rewards.Stat_Deception_UP:
                    general_rewardImage.sprite = Stat_Deception_UP;
                    break;
                case Rewards.Stat_Dexterity_UP:
                    general_rewardImage.sprite = Stat_Dexterity_UP;
                    break;
                case Rewards.Stat_Strength_UP:
                    general_rewardImage.sprite = Stat_Strength_UP;
                    break;
                case Rewards.Stat_Puzzle_UP:
                    general_rewardImage.sprite = Stat_Puzzle_UP;
                    break;
                case Rewards.Stat_Consentration_UP:
                    general_rewardImage.sprite = Stat_Consentration_UP;
                    break;
                case Rewards.Stat_Endurance_UP:
                    general_rewardImage.sprite = Stat_Endurance_UP;
                    break;
                case Rewards.Stat_Loyalty_UP:
                    general_rewardImage.sprite = Stat_Loyalty_UP;
                    break;
                case Rewards.Stat_Strategic_UP:
                    general_rewardImage.sprite = Stat_Strategic_UP;
                    break;
                case Rewards.Stat_SelfControl_UP:
                    general_rewardImage.sprite = Stat_SelfControl_UP;
                    break;
                case Rewards.Stat_AdvantageHunting_UP:
                    general_rewardImage.sprite = Stat_AdvantageHunting_UP;
                    break;
                case Rewards.Stat_Survival_UP:
                    general_rewardImage.sprite = Stat_Survival_UP;
                    break;
                case Rewards.Stat_Relationship_DOWN:
                    general_rewardImage.sprite = Stat_Relationship_DOWN;
                    break;
                case Rewards.Stat_Charisma_DOWN:
                    general_rewardImage.sprite = Stat_Charisma_DOWN;
                    break;
                case Rewards.Stat_Intuition_DOWN:
                    general_rewardImage.sprite = Stat_Intuition_DOWN;
                    break;
                case Rewards.Stat_Perception_DOWN:
                    general_rewardImage.sprite = Stat_Perception_DOWN;
                    break;
                case Rewards.Stat_Deception_DOWN:
                    general_rewardImage.sprite = Stat_Deception_DOWN;
                    break;
                case Rewards.Stat_Dexterity_DOWN:
                    general_rewardImage.sprite = Stat_Dexterity_DOWN;
                    break;
                case Rewards.Stat_Strength_DOWN:
                    general_rewardImage.sprite = Stat_Strength_DOWN;
                    break;
                case Rewards.Stat_Puzzle_DOWN:
                    general_rewardImage.sprite = Stat_Puzzle_DOWN;
                    break;
                case Rewards.Stat_Consentration_DOWN:
                    general_rewardImage.sprite = Stat_Consentration_DOWN;
                    break;
                case Rewards.Stat_Endurance_DOWN:
                    general_rewardImage.sprite = Stat_Endurance_DOWN;
                    break;
                case Rewards.Stat_Loyalty_DOWN:
                    general_rewardImage.sprite = Stat_Loyalty_DOWN;
                    break;
                case Rewards.Stat_Strategic_DOWN:
                    general_rewardImage.sprite = Stat_Strategic_DOWN;
                    break;
                case Rewards.Stat_SelfControl_DOWN:
                    general_rewardImage.sprite = Stat_SelfControl_DOWN;
                    break;
                case Rewards.Stat_AdvantageHunting_DOWN:
                    general_rewardImage.sprite = Stat_AdvantageHunting_DOWN;
                    break;
                case Rewards.Stat_Survival_DOWN:
                    general_rewardImage.sprite = Stat_Survival_DOWN;
                    break;

                default:
                    break;
            }
        }
        else
        {
            general_rewardBox.SetActive(false);
        }

        //Set Punishment
        if (dailyTask_SO.dailyTaskList[index].punishment != Rewards.None)
        {
            punishment_rewardBox.SetActive(true);
            punishment_rewardText.text = dailyTask_SO.dailyTaskList[index].punishment_amount.ToString();

            switch (dailyTask_SO.dailyTaskList[index].punishment)
            {
                case Rewards.None:
                    punishment_rewardImage.sprite = null;
                    break;

                case Rewards.Outwit_Coin:
                    punishment_rewardImage.sprite = Outwit_Coin;
                    break;
                case Rewards.Outplay_Coin:
                    punishment_rewardImage.sprite = Outwit_Coin;
                    break;
                case Rewards.Outlast_Coin:
                    punishment_rewardImage.sprite = Outlast_Coin;
                    break;
                case Rewards.PressureToken:
                    punishment_rewardImage.sprite = PressureToken;
                    break;
                case Rewards.Quest:
                    punishment_rewardImage.sprite = Quest;
                    break;
                case Rewards.TribalCard:
                    punishment_rewardImage.sprite = TribalCard;
                    break;
                case Rewards.MoraleUP:
                    punishment_rewardImage.sprite = MoraleUP;
                    break;
                case Rewards.MoraleDown:
                    punishment_rewardImage.sprite = MoraleDown;
                    break;
                case Rewards.Stat_Relationship_UP:
                    punishment_rewardImage.sprite = Stat_Relationship_UP;
                    break;
                case Rewards.Stat_Charisma_UP:
                    punishment_rewardImage.sprite = Stat_Charisma_UP;
                    break;
                case Rewards.Stat_Intuition_UP:
                    punishment_rewardImage.sprite = Stat_Intuition_UP;
                    break;
                case Rewards.Stat_Perception_UP:
                    punishment_rewardImage.sprite = Stat_Perception_UP;
                    break;
                case Rewards.Stat_Deception_UP:
                    punishment_rewardImage.sprite = Stat_Deception_UP;
                    break;
                case Rewards.Stat_Dexterity_UP:
                    punishment_rewardImage.sprite = Stat_Dexterity_UP;
                    break;
                case Rewards.Stat_Strength_UP:
                    punishment_rewardImage.sprite = Stat_Strength_UP;
                    break;
                case Rewards.Stat_Puzzle_UP:
                    punishment_rewardImage.sprite = Stat_Puzzle_UP;
                    break;
                case Rewards.Stat_Consentration_UP:
                    punishment_rewardImage.sprite = Stat_Consentration_UP;
                    break;
                case Rewards.Stat_Endurance_UP:
                    punishment_rewardImage.sprite = Stat_Endurance_UP;
                    break;
                case Rewards.Stat_Loyalty_UP:
                    punishment_rewardImage.sprite = Stat_Loyalty_UP;
                    break;
                case Rewards.Stat_Strategic_UP:
                    punishment_rewardImage.sprite = Stat_Strategic_UP;
                    break;
                case Rewards.Stat_SelfControl_UP:
                    punishment_rewardImage.sprite = Stat_SelfControl_UP;
                    break;
                case Rewards.Stat_AdvantageHunting_UP:
                    punishment_rewardImage.sprite = Stat_AdvantageHunting_UP;
                    break;
                case Rewards.Stat_Survival_UP:
                    punishment_rewardImage.sprite = Stat_Survival_UP;
                    break;
                case Rewards.Stat_Relationship_DOWN:
                    punishment_rewardImage.sprite = Stat_Relationship_DOWN;
                    break;
                case Rewards.Stat_Charisma_DOWN:
                    punishment_rewardImage.sprite = Stat_Charisma_DOWN;
                    break;
                case Rewards.Stat_Intuition_DOWN:
                    punishment_rewardImage.sprite = Stat_Intuition_DOWN;
                    break;
                case Rewards.Stat_Perception_DOWN:
                    punishment_rewardImage.sprite = Stat_Perception_DOWN;
                    break;
                case Rewards.Stat_Deception_DOWN:
                    punishment_rewardImage.sprite = Stat_Deception_DOWN;
                    break;
                case Rewards.Stat_Dexterity_DOWN:
                    punishment_rewardImage.sprite = Stat_Dexterity_DOWN;
                    break;
                case Rewards.Stat_Strength_DOWN:
                    punishment_rewardImage.sprite = Stat_Strength_DOWN;
                    break;
                case Rewards.Stat_Puzzle_DOWN:
                    punishment_rewardImage.sprite = Stat_Puzzle_DOWN;
                    break;
                case Rewards.Stat_Consentration_DOWN:
                    punishment_rewardImage.sprite = Stat_Consentration_DOWN;
                    break;
                case Rewards.Stat_Endurance_DOWN:
                    punishment_rewardImage.sprite = Stat_Endurance_DOWN;
                    break;
                case Rewards.Stat_Loyalty_DOWN:
                    punishment_rewardImage.sprite = Stat_Loyalty_DOWN;
                    break;
                case Rewards.Stat_Strategic_DOWN:
                    punishment_rewardImage.sprite = Stat_Strategic_DOWN;
                    break;
                case Rewards.Stat_SelfControl_DOWN:
                    punishment_rewardImage.sprite = Stat_SelfControl_DOWN;
                    break;
                case Rewards.Stat_AdvantageHunting_DOWN:
                    punishment_rewardImage.sprite = Stat_AdvantageHunting_DOWN;
                    break;
                case Rewards.Stat_Survival_DOWN:
                    punishment_rewardImage.sprite = Stat_Survival_DOWN;
                    break;

                default:
                    break;
            }
        }
        else
        {
            punishment_rewardBox.SetActive(false);
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