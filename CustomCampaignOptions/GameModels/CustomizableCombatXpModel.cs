using System;
using CustomCampaignOptions.Behaviours;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;

namespace CustomCampaignOptions.GameModels
{
    public class CustomizableCombatXpModel : DefaultCombatXpModel
    {
        public override void GetXpFromHit(CharacterObject attackerTroop, CharacterObject attackedTroop, int damage, bool isFatal,
            MissionTypeEnum missionType, out int xpAmount)
        {
            base.GetXpFromHit(attackerTroop, attackedTroop, damage, isFatal, missionType, out xpAmount);
            xpAmount = (int)Math.Round(xpAmount * (CustomCampaignOptionsBehaviour.m_optionsData.m_troopXp / 100f));
        }
    }
}