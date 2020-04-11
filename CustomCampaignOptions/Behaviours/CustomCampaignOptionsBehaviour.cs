using TaleWorlds.CampaignSystem;
using TaleWorlds.SaveSystem;

namespace CustomCampaignOptions.Behaviours
{
    public class CustomCampaignOptionsBehaviour : CampaignBehaviorBase
    {
        private readonly string c_PREFIX = "CustomCampaignOptions";
        
        [SaveableField(1)] public float PlayerTroopsReceivedDamage = 100f;
        [SaveableField(2)] public float PlayerFriendsReceivedDamage = 100f;
        [SaveableField(3)] public float PlayerReceiveDamage = 100f;
        [SaveableField(4)] public int MaximumIndexPlayerCanRecruit = 0;
        [SaveableField(5)] public float PlayerMapMovementSpeed = 0f;
        [SaveableField(6)] public float PlayerXp = 100f;
        [SaveableField(7)] public float TroopXp = 100f;
        [SaveableField(8)] public float Wages = 100f;

        public static CustomCampaignOptionsBehaviour Instance;
        
        public override void RegisterEvents()
        {
            Instance = this;
        }

        public override void SyncData(IDataStore dataStore)
        {
            dataStore.SyncData(GetKey(nameof(PlayerTroopsReceivedDamage)), ref PlayerTroopsReceivedDamage);
            dataStore.SyncData(GetKey(nameof(PlayerFriendsReceivedDamage)), ref PlayerFriendsReceivedDamage);
            dataStore.SyncData(GetKey(nameof(PlayerReceiveDamage)), ref PlayerReceiveDamage);
            dataStore.SyncData(GetKey(nameof(MaximumIndexPlayerCanRecruit)), ref MaximumIndexPlayerCanRecruit);
            dataStore.SyncData(GetKey(nameof(PlayerMapMovementSpeed)), ref PlayerMapMovementSpeed);
            dataStore.SyncData(GetKey(nameof(PlayerXp)), ref PlayerXp);
            dataStore.SyncData(GetKey(nameof(TroopXp)), ref TroopXp);
            dataStore.SyncData(GetKey(nameof(Wages)), ref Wages);
        }

        private string GetKey(string fieldName) => $"{c_PREFIX}_{fieldName}";
    }
}