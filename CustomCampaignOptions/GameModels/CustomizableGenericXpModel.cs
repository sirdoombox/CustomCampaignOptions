using CustomCampaignOptions.Behaviours;
using TaleWorlds.CampaignSystem;

namespace CustomCampaignOptions.GameModels
{
    public class CustomizableGenericXpModel : GenericXpModel
    {
        public override float GetXpMultiplier(Hero hero)
        {
            return CustomCampaignOptionsBehaviour.m_optionsData.m_playerXp / 100f;
        }
    }
}