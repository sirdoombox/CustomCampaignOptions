using System;
using CustomCampaignOptions.Behaviours;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;

namespace CustomCampaignOptions.GameModels
{
    public class CustomizablePartyWageModel : DefaultPartyWageModel
    {
        public override int GetTotalWage(MobileParty mobileParty, StatExplainer explanation = null)
        {
            var totalWage = base.GetTotalWage(mobileParty, explanation);
            if (mobileParty.IsMainParty)
                totalWage = (int)Math.Round(totalWage * (CustomCampaignOptionsBehaviour.m_optionsData.m_wages / 100f));
            return totalWage;
        }
    }
}