using StoryMode;
using TaleWorlds.CampaignSystem;

namespace CustomCampaignOptions.GameModels
{
    public class CustomizableStoryModeCombatXpModel : CustomizableCombatXpModel
    {
        public override void GetXpFromHit(
            CharacterObject attackerTroop,
            CharacterObject attackedTroop,
            int damage,
            bool isFatal,
            MissionTypeEnum missionType,
            out int xpAmount)
        {
            if (Settlement.CurrentSettlement != null && Settlement.CurrentSettlement.IsTrainingField())
                xpAmount = 0;
            else
                base.GetXpFromHit(attackerTroop, attackedTroop, damage, isFatal, missionType, out xpAmount);
        }
    }
}