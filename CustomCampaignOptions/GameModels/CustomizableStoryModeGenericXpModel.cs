using CustomCampaignOptions.Behaviours;
using StoryMode;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;

namespace CustomCampaignOptions.GameModels
{
    public class CustomizableStoryModeGenericXpModel : DefaultGenericXpModel
    {
        public override float GetXpMultiplier(Hero hero)
        {
            return hero?.CurrentSettlement != null && hero.CurrentSettlement.IsTrainingField()
                ? 0.0f
                : CustomCampaignOptionsBehaviour.m_optionsData.m_playerXp / 100f;
        }
    }
}