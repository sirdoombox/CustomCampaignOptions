using StoryMode.GameModels;
using TaleWorlds.CampaignSystem;

namespace CustomCampaignOptions.GameModels
{
    public class CustomizableStoryModePartyWageModel : CustomizablePartyWageModel
    {
        public override int GetTroopRecruitmentCost(
            CharacterObject troop,
            Hero buyerHero,
            bool withoutItemCost = false)
        {
            if (StoryMode.StoryMode.Current.MainStoryLine.TutorialPhase.IsCompleted)
                return base.GetTroopRecruitmentCost(troop, buyerHero, withoutItemCost);
            return troop.StringId != "tutorial_placeholder_volunteer" ? base.GetTroopRecruitmentCost(troop, buyerHero, withoutItemCost) : 50;
        }
    }
}