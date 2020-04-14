using CustomCampaignOptions.Behaviours;
using TaleWorlds.CampaignSystem;

namespace CustomCampaignOptions.GameModels
{
    public class CustomizableDifficultyModel : DifficultyModel
    {
        public override float GetPlayerTroopsReceivedDamageMultiplier()
        {
            return CustomCampaignOptionsBehaviour.Instance.PlayerTroopsReceivedDamage / 100f;
        }

        public override float GetDamageToPlayerMultiplier()
        {
            return CustomCampaignOptionsBehaviour.Instance.PlayerReceiveDamage / 100f;
        }

        public override float GetDamageToFriendsMultiplier()
        {
            return CustomCampaignOptionsBehaviour.Instance.PlayerFriendsReceivedDamage / 100f;
        }

        public override int GetPlayerRecruitSlotBonus()
        {
            return CustomCampaignOptionsBehaviour.Instance.MaximumIndexPlayerCanRecruit;
        }

        public override float GetPlayerMapMovementSpeedBonusMultiplier()
        {
            return CustomCampaignOptionsBehaviour.Instance.PlayerMapMovementSpeed / 100f;
        }

        public override float GetCombatAIDifficultyMultiplier()
        {
            return CustomCampaignOptionsBehaviour.Instance.CombatAIDifficulty / 100f;
        }
    }
}