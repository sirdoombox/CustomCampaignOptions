using TaleWorlds.CampaignSystem;
using TaleWorlds.SaveSystem;

namespace CustomCampaignOptions.Behaviours
{
    public class CustomCampaignOptionsBehaviour : CampaignBehaviorBase
    {
        private readonly string c_PREFIX = "CustomCampaignOptions";
        
        public float PlayerTroopsReceivedDamage = 100f;
        public float PlayerFriendsReceivedDamage = 100f;
        public float PlayerReceiveDamage = 100f;
        public int MaximumIndexPlayerCanRecruit = 0;
        public float PlayerMapMovementSpeed = 0f;
        public float PlayerXp = 100f;
        public float TroopXp = 100f;
        public float Wages = 100f;
        public float CombatAIDifficulty = 50f;

        public static CustomCampaignOptionsBehaviour Instance;
        
        public override void RegisterEvents()
        {
            Instance = this;
        }

        public override void SyncData(IDataStore dataStore)
        {
            // This is absolutely disgusting but the TaleWorld's save system is terrible so it is what it is.
            try
            {
                dataStore.SyncData(GetKey(nameof(PlayerTroopsReceivedDamage)), ref PlayerTroopsReceivedDamage);
                dataStore.SyncData(GetKey(nameof(PlayerFriendsReceivedDamage)), ref PlayerFriendsReceivedDamage);
                dataStore.SyncData(GetKey(nameof(PlayerReceiveDamage)), ref PlayerReceiveDamage);
                dataStore.SyncData(GetKey(nameof(MaximumIndexPlayerCanRecruit)), ref MaximumIndexPlayerCanRecruit);
                dataStore.SyncData(GetKey(nameof(PlayerMapMovementSpeed)), ref PlayerMapMovementSpeed);
                dataStore.SyncData(GetKey(nameof(PlayerXp)), ref PlayerXp);
                dataStore.SyncData(GetKey(nameof(TroopXp)), ref TroopXp);
                dataStore.SyncData(GetKey(nameof(Wages)), ref Wages);
                dataStore.SyncData(GetKey(nameof(CombatAIDifficulty)), ref CombatAIDifficulty);
            }
            catch
            {
                // ignored
            }
        }

        private string GetKey(string fieldName) => $"{c_PREFIX}_{fieldName}";
    }
}