using CustomCampaignOptions.Behaviours;
using TaleWorlds.CampaignSystem;

namespace CustomCampaignOptions.GameModels
{
    public class CustomizableDifficultyModel : DifficultyModel
    {
        public override float GetPlayerTroopsReceivedDamageMultiplier()
        {
            return CustomCampaignOptionsBehaviour.m_optionsData.m_playerTroopsReceivedDamage / 100f;
        }

        public override float GetDamageToPlayerMultiplier()
        {
            return CustomCampaignOptionsBehaviour.m_optionsData.m_playerReceiveDamage / 100f;
        }

        public override float GetDamageToFriendsMultiplier()
        {
            return CustomCampaignOptionsBehaviour.m_optionsData.m_playerFriendsReceivedDamage / 100f;
        }

        public override int GetPlayerRecruitSlotBonus()
        {
            return CustomCampaignOptionsBehaviour.m_optionsData.m_maximumIndexPlayerCanRecruit;
        }

        public override float GetPlayerMapMovementSpeedBonusMultiplier()
        {
            return CustomCampaignOptionsBehaviour.m_optionsData.m_playerMapMovementSpeed / 100f;
        }
    }
}