using CustomCampaignOptions.Data;
using TaleWorlds.CampaignSystem;

namespace CustomCampaignOptions.Behaviours
{
    public class CustomCampaignOptionsBehaviour : CampaignBehaviorBase
    {
        public static CustomCampaignOptionsData m_optionsData = new CustomCampaignOptionsData();
        
        public override void RegisterEvents() { }

        public override void SyncData(IDataStore dataStore)
        {
            dataStore.SyncData("m_optionsData", ref m_optionsData);
        }
    }
}