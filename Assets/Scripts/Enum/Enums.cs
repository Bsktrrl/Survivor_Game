using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Stats
{
    None,

    Relationship,
    Charisma,
    Intuition,
    Perception,
    Deception,

    Dexterity,
    Strength,
    Puzzle,
    Consentration,
    Endurance,

    Loyalty,
    Strategic,
    Self_Control,
    Advantage_Hunting,
    Survival
}

public enum dice
{
    None,

    Dice_1,
    Dice_2,
    Dice_3,
    Dice_4,
    Dice_5,
    Dice_6,
    Dice_7,
    Dice_8,
    Dice_9,
    Dice_10,
    Dice_11
}

public enum voictoryPoints
{
    None,

    Outwit,
    Outplay,
    Outlast
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

public enum GamePhases
{
    None,

    SetupPhase,
    DailyTaskPhase,
    ChallengePhase,
    TribalCouncilPhase
}

public enum Tier
{
    None,

    Normal,
    Rare,
    Epic,
    Legenday
}

public enum Rewards
{
    None,

    Outwit_Coin,
    Outplay_Coin,
    Outlast_Coin,

    PressureToken,

    Quest,
    TribalCard,

    MoraleUP,
    MoraleDown,

    Stat_Relationship_UP,
    Stat_Charisma_UP,
    Stat_Intuition_UP,
    Stat_Perception_UP,
    Stat_Deception_UP,

    Stat_Dexterity_UP,
    Stat_Strength_UP,
    Stat_Puzzle_UP,
    Stat_Consentration_UP,
    Stat_Endurance_UP,

    Stat_Loyalty_UP,
    Stat_Strategic_UP,
    Stat_SelfControl_UP,
    Stat_AdvantageHunting_UP,
    Stat_Survival_UP,

    Stat_Relationship_DOWN,
    Stat_Charisma_DOWN,
    Stat_Intuition_DOWN,
    Stat_Perception_DOWN,
    Stat_Deception_DOWN,

    Stat_Dexterity_DOWN,
    Stat_Strength_DOWN,
    Stat_Puzzle_DOWN,
    Stat_Consentration_DOWN,
    Stat_Endurance_DOWN,

    Stat_Loyalty_DOWN,
    Stat_Strategic_DOWN,
    Stat_SelfControl_DOWN,
    Stat_AdvantageHunting_DOWN,
    Stat_Survival_DOWN
}