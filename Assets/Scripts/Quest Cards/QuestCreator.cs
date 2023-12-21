using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteInEditMode]
public class QuestCreator : Singleton<QuestCreator>
{
    public Quest_SO quest_SO;

    [SerializeField] RectTransform description_Panel;
    [SerializeField] TextMeshProUGUI name;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] GameObject requirement_Parent;
    [SerializeField] GameObject requirement_Prefab;

    [SerializeField] TextMeshProUGUI gamePhase;

    [SerializeField] GameObject rewardBox;
    [SerializeField] Image rewardImage;
    [SerializeField] TextMeshProUGUI rewardText;

    [Header("Prefab")]
    [SerializeField] GameObject requirementSlot_Parent;
    [SerializeField] GameObject requirementSlot_Prefab;

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

    public bool isScreenshoting;


    //--------------------


    private void Update()
    {
        if (!isScreenshoting && quest_SO.questList.Count > 0)
        {
            BuildQuestCard(quest_SO.questList.Count - 1);
        }
    }


    //--------------------


    public void BuildQuestCard(int index)
    {
        //Set Game Phase Text
        switch (quest_SO.questList[index].phase)
        {
            case GamePhases.None:
                break;

            case GamePhases.SetupPhase:
                gamePhase.text = "Setup Phase";
                break;
            case GamePhases.DailyTaskPhase:
                gamePhase.text = "Daily Task Phase";
                break;
            case GamePhases.ChallengePhase:
                gamePhase.text = "Challenge Phase";
                break;
            case GamePhases.TribalCouncilPhase:
                gamePhase.text = "Tribal Council Phase";
                break;

            default:
                break;
        }

        //Set Name
        name.text = quest_SO.questList[index].name;

        //Set Description
        description.text = quest_SO.questList[index].description;

        //Set Description_Panel height
        description_Panel.sizeDelta = new Vector2(description_Panel.sizeDelta.x, quest_SO.questList[index].panel_height);

        //Set Reward
        if (quest_SO.questList[index].reward != Rewards.None)
        {
            rewardBox.SetActive(true);
            rewardText.text = quest_SO.questList[index].amount.ToString();

            switch (quest_SO.questList[index].reward)
            {
                case Rewards.None:
                    rewardImage.sprite = null;
                    break;

                case Rewards.Outwit_Coin:
                    rewardImage.sprite = Outwit_Coin;
                    break;
                case Rewards.Outplay_Coin:
                    rewardImage.sprite = Outwit_Coin;
                    break;
                case Rewards.Outlast_Coin:
                    rewardImage.sprite = Outlast_Coin;
                    break;
                case Rewards.PressureToken:
                    rewardImage.sprite = PressureToken;
                    break;
                case Rewards.Quest:
                    rewardImage.sprite = Quest;
                    break;
                case Rewards.TribalCard:
                    rewardImage.sprite = TribalCard;
                    break;
                case Rewards.MoraleUP:
                    rewardImage.sprite = MoraleUP;
                    break;
                case Rewards.MoraleDown:
                    rewardImage.sprite = MoraleDown;
                    break;
                case Rewards.Stat_Relationship_UP:
                    rewardImage.sprite = Stat_Relationship_UP;
                    break;
                case Rewards.Stat_Charisma_UP:
                    rewardImage.sprite = Stat_Charisma_UP;
                    break;
                case Rewards.Stat_Intuition_UP:
                    rewardImage.sprite = Stat_Intuition_UP;
                    break;
                case Rewards.Stat_Perception_UP:
                    rewardImage.sprite = Stat_Perception_UP;
                    break;
                case Rewards.Stat_Deception_UP:
                    rewardImage.sprite = Stat_Deception_UP;
                    break;
                case Rewards.Stat_Dexterity_UP:
                    rewardImage.sprite = Stat_Dexterity_UP;
                    break;
                case Rewards.Stat_Strength_UP:
                    rewardImage.sprite = Stat_Strength_UP;
                    break;
                case Rewards.Stat_Puzzle_UP:
                    rewardImage.sprite = Stat_Puzzle_UP;
                    break;
                case Rewards.Stat_Consentration_UP:
                    rewardImage.sprite = Stat_Consentration_UP;
                    break;
                case Rewards.Stat_Endurance_UP:
                    rewardImage.sprite = Stat_Endurance_UP;
                    break;
                case Rewards.Stat_Loyalty_UP:
                    rewardImage.sprite = Stat_Loyalty_UP;
                    break;
                case Rewards.Stat_Strategic_UP:
                    rewardImage.sprite = Stat_Strategic_UP;
                    break;
                case Rewards.Stat_SelfControl_UP:
                    rewardImage.sprite = Stat_SelfControl_UP;
                    break;
                case Rewards.Stat_AdvantageHunting_UP:
                    rewardImage.sprite = Stat_AdvantageHunting_UP;
                    break;
                case Rewards.Stat_Survival_UP:
                    rewardImage.sprite = Stat_Survival_UP;
                    break;
                case Rewards.Stat_Relationship_DOWN:
                    rewardImage.sprite = Stat_Relationship_DOWN;
                    break;
                case Rewards.Stat_Charisma_DOWN:
                    rewardImage.sprite = Stat_Charisma_DOWN;
                    break;
                case Rewards.Stat_Intuition_DOWN:
                    rewardImage.sprite = Stat_Intuition_DOWN;
                    break;
                case Rewards.Stat_Perception_DOWN:
                    rewardImage.sprite = Stat_Perception_DOWN;
                    break;
                case Rewards.Stat_Deception_DOWN:
                    rewardImage.sprite = Stat_Deception_DOWN;
                    break;
                case Rewards.Stat_Dexterity_DOWN:
                    rewardImage.sprite = Stat_Dexterity_DOWN;
                    break;
                case Rewards.Stat_Strength_DOWN:
                    rewardImage.sprite = Stat_Strength_DOWN;
                    break;
                case Rewards.Stat_Puzzle_DOWN:
                    rewardImage.sprite = Stat_Puzzle_DOWN;
                    break;
                case Rewards.Stat_Consentration_DOWN:
                    rewardImage.sprite = Stat_Consentration_DOWN;
                    break;
                case Rewards.Stat_Endurance_DOWN:
                    rewardImage.sprite = Stat_Endurance_DOWN;
                    break;
                case Rewards.Stat_Loyalty_DOWN:
                    rewardImage.sprite = Stat_Loyalty_DOWN;
                    break;
                case Rewards.Stat_Strategic_DOWN:
                    rewardImage.sprite = Stat_Strategic_DOWN;
                    break;
                case Rewards.Stat_SelfControl_DOWN:
                    rewardImage.sprite = Stat_SelfControl_DOWN;
                    break;
                case Rewards.Stat_AdvantageHunting_DOWN:
                    rewardImage.sprite = Stat_AdvantageHunting_DOWN;
                    break;
                case Rewards.Stat_Survival_DOWN:
                    rewardImage.sprite = Stat_Survival_DOWN;
                    break;

                default:
                    break;
            }
        }
        else
        {
            rewardBox.SetActive(false);
        }

        //Set Requirement
        #region
        //Reset "requirementSlotList"
        DestroyImmediate(requirementSlot);
        requirementSlot = null;

        //Set new RequirementSlots
        //Instantiate a requirementSlot
        requirementSlot = Instantiate(requirementSlot_Prefab, requirementSlot_Parent.transform);
        requirementSlot_Parent.GetComponent<VerticalLayoutGroup>().spacing = quest_SO.questList[index].requirementSlot.spacing;
        RequirementSlot slot = requirementSlot.GetComponent<RequirementSlot>();

        //Add Dice
        slot.componentsList.Add(Instantiate(dice_Image, slot.components_Parent.transform));
        slot.componentsList[slot.componentsList.Count - 1].GetComponent<Image>().sprite = SetDiceSprite(quest_SO.questList[index].requirementSlot.diceType);

        AddSign(slot, ":");

        //Add amount of Stats
        for (int j = 0; j < quest_SO.questList[index].requirementSlot.stats.Count; j++)
        {
            slot.componentsList.Add(Instantiate(stat_Image, slot.components_Parent.transform));
            slot.componentsList[slot.componentsList.Count - 1].GetComponent<Image>().sprite = SetStatSprite(quest_SO.questList[index].requirementSlot.stats[j]);

            if ((j + 1) >= quest_SO.questList[index].requirementSlot.stats.Count)
            {

            }
            else if (quest_SO.questList[index].requirementSlot.stats.Count > 1)
            {
                AddSign(slot, "+");
            }
        }

        AddSign(slot, ":");

        //Add Requirement
        slot.componentsList.Add(Instantiate(requirementText, slot.components_Parent.transform));
        slot.componentsList[slot.componentsList.Count - 1].GetComponent<TextMeshProUGUI>().text = quest_SO.questList[index].requirementSlot.requirement.ToString();

        //Add Requirement Chaning
        switch (quest_SO.questList[index].requirementSlot.requirementChange)
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
        if (quest_SO.questList[index].requirementSlot.repeat > 0)
        {
            AddSign(slot, "|");

            slot.componentsList.Add(Instantiate(repeatText, slot.components_Parent.transform));
            slot.componentsList[slot.componentsList.Count - 1].GetComponent<TextMeshProUGUI>().text = "[" + quest_SO.questList[index].requirementSlot.repeat.ToString() + "]";
        }

        //Set size
        slot.gameObject.GetComponent<HorizontalLayoutGroup>().spacing = quest_SO.questList[index].requirementSlot.spacing;
        #endregion
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
