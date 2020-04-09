using StoryMode;
using TaleWorlds.CampaignSystem;

namespace CustomCampaignOptions.GameModels
{
    public class CustomizableStoryModeGenericXpModel : CustomizableGenericXpModel
    {
        public override float GetXpMultiplier(Hero hero)
        {
            return hero?.CurrentSettlement != null && hero.CurrentSettlement.IsTrainingField()
                ? 0.0f
                : base.GetXpMultiplier(hero);
        }
    }
}