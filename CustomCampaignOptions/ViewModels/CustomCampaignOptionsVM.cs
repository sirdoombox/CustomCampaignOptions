using System;
using CustomCampaignOptions.Behaviours;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace CustomCampaignOptions.ViewModels
{
    public class CustomCampaignOptionsVM : ViewModel
    {
        private readonly Action m_onClose;

        private CustomCampaignOptionsBehaviour Options => CustomCampaignOptionsBehaviour.Instance;

        #region SliderMinMaxValues

        [DataSourceProperty] public float SliderFloatMinValue => 0f;

        [DataSourceProperty] public float SliderFloatMaxValue => 200f;

        [DataSourceProperty] public float SliderXpFloatMaxValue => 500f;

        [DataSourceProperty] public float SliderAiDiffFloatMaxValue => 100f;

        [DataSourceProperty] public float SliderIntMinValue => 0f;

        [DataSourceProperty] public float SliderIntMaxValue => 10f;

        #endregion

        #region TitleText

        private string m_titleText;

        [DataSourceProperty]
        public string TitleText
        {
            get => m_titleText;
            set
            {
                if (value == m_titleText)
                    return;
                m_titleText = value;
                OnPropertyChanged(nameof(TitleText));
            }
        }

        #endregion

        #region CombatAIDifficulty

        private float m_combatAIDifficulty;

        [DataSourceProperty]
        public float CombatAIDifficulty
        {
            get => m_combatAIDifficulty;
            set
            {
                SetField(ref m_combatAIDifficulty, value, nameof(CombatAIDifficulty));
                CombatAIDifficultyString = $"Combat AI Difficulty: {m_combatAIDifficulty:0}%";
                OnPropertyChanged(nameof(CombatAIDifficultyString));
                Options.CombatAIDifficulty = m_combatAIDifficulty;
            }
        }

        [DataSourceProperty] public string CombatAIDifficultyString { get; private set; }

        #endregion
        
        #region TroopsReceivedDamage

        private float m_playerTroopsReceivedDamage;

        [DataSourceProperty]
        public float PlayerTroopsReceivedDamage
        {
            get => m_playerTroopsReceivedDamage;
            set
            {
                SetField(ref m_playerTroopsReceivedDamage, value, nameof(PlayerTroopsReceivedDamage));
                PlayerTroopsReceivedDamageString = $"Player Troops Received Damage: {m_playerTroopsReceivedDamage:0}%";
                OnPropertyChanged(nameof(PlayerTroopsReceivedDamageString));
                Options.PlayerTroopsReceivedDamage = m_playerTroopsReceivedDamage;
            }
        }

        [DataSourceProperty] public string PlayerTroopsReceivedDamageString { get; private set; }

        #endregion

        #region PlayerFriendsReceivedDamage

        private float m_playerFriendsReceivedDamage;

        [DataSourceProperty]
        public float PlayerFriendsReceivedDamage
        {
            get => m_playerFriendsReceivedDamage;
            set
            {
                SetField(ref m_playerFriendsReceivedDamage, value, nameof(PlayerFriendsReceivedDamage));
                PlayerFriendsReceivedDamageString =
                    $"Friendly Parties Received Damage: {m_playerFriendsReceivedDamage:0}%";
                OnPropertyChanged(nameof(PlayerFriendsReceivedDamageString));
                Options.PlayerFriendsReceivedDamage = m_playerFriendsReceivedDamage;
            }
        }

        [DataSourceProperty] public string PlayerFriendsReceivedDamageString { get; private set; }

        #endregion

        #region PlayerReceivedDamage

        private float m_playerReceiveDamage;

        [DataSourceProperty]
        public float PlayerReceiveDamage
        {
            get => m_playerReceiveDamage;
            set
            {
                SetField(ref m_playerReceiveDamage, value, nameof(PlayerReceiveDamage));
                PlayerReceiveDamageString = $"Player Received Damage: {m_playerReceiveDamage:0}%";
                OnPropertyChanged(nameof(PlayerReceiveDamageString));
                Options.PlayerReceiveDamage = m_playerReceiveDamage;
            }
        }

        [DataSourceProperty] public string PlayerReceiveDamageString { get; private set; }

        #endregion

        #region MaximumIndexPlayerCanRecruit

        private int m_maximumIndexPlayerCanRecruit;

        [DataSourceProperty]
        public float MaximumIndexPlayerCanRecruit
        {
            get => m_maximumIndexPlayerCanRecruit;
            set
            {
                m_maximumIndexPlayerCanRecruit = (int) Math.Round(value);
                OnPropertyChanged(nameof(MaximumIndexPlayerCanRecruit));
                MaximumIndexPlayerCanRecruitString = $"Recruitable Troops: {m_maximumIndexPlayerCanRecruit} extra";
                OnPropertyChanged(nameof(MaximumIndexPlayerCanRecruitString));
                Options.MaximumIndexPlayerCanRecruit = m_maximumIndexPlayerCanRecruit;
            }
        }

        [DataSourceProperty] public string MaximumIndexPlayerCanRecruitString { get; private set; }

        #endregion

        #region PlayerMapMovementSpeed

        private float m_playerMapMovementSpeed;

        [DataSourceProperty]
        public float PlayerMapMovementSpeed
        {
            get => m_playerMapMovementSpeed;
            set
            {
                SetField(ref m_playerMapMovementSpeed, value, nameof(PlayerMapMovementSpeed));
                PlayerMapMovementSpeedString = $"Bonus Map Movement Speed: {m_playerMapMovementSpeed:0}%";
                OnPropertyChanged(nameof(PlayerMapMovementSpeedString));
                Options.PlayerMapMovementSpeed = m_playerMapMovementSpeed;
                typeof(MobileParty)
                    .GetField("_partyPureSpeedLastCheckVersion", System.Reflection.BindingFlags.NonPublic 
                                                                 | System.Reflection.BindingFlags.Instance)
                    ?.SetValue(MobileParty.MainParty, -1);
                MobileParty.MainParty.ComputeSpeed();
            }
        }

        [DataSourceProperty] public string PlayerMapMovementSpeedString { get; private set; }

        #endregion

        #region PlayerXp

        private float m_playerXp;

        [DataSourceProperty]
        public float PlayerXp
        {
            get => m_playerXp;
            set
            {
                SetField(ref m_playerXp, value, nameof(PlayerXp));
                PlayerXpString = $"Player Experience: {m_playerXp:0}%";
                OnPropertyChanged(nameof(PlayerXpString));
                Options.PlayerXp = m_playerXp;
            }
        }

        [DataSourceProperty] public string PlayerXpString { get; private set; }

        #endregion

        #region TroopXp

        private float m_troopXp;

        [DataSourceProperty]
        public float TroopXp
        {
            get => m_troopXp;
            set
            {
                SetField(ref m_troopXp, value, nameof(TroopXp));
                TroopXpString = $"Troop XP: {m_troopXp:0}%";
                OnPropertyChanged(nameof(TroopXpString));
                Options.TroopXp = m_troopXp;
            }
        }

        [DataSourceProperty] public string TroopXpString { get; private set; }

        #endregion

        #region Wages

        private float m_wages;

        [DataSourceProperty]
        public float Wages
        {
            get => m_wages;
            set
            {
                SetField(ref m_wages, value, nameof(Wages));
                WagesString = $"Player Party Wages: {m_wages:0}%";
                OnPropertyChanged(nameof(WagesString));
                Options.Wages = m_wages;
            }
        }

        [DataSourceProperty] public string WagesString { get; private set; }

        #endregion

        #region IsDeathEnabled

        private bool m_isDeathEnabled;

        [DataSourceProperty]
        public bool IsDeathEnabled
        {
            get => m_isDeathEnabled;
            set
            {
                SetField(ref m_isDeathEnabled, value, nameof(IsDeathEnabled));
                CampaignOptions.IsDeathEnabled = m_isDeathEnabled;
            }
        }

        #endregion

        #region AutoAllocateClanMemberPerks

        private bool m_autoAllocateClanMemberPerks;

        [DataSourceProperty]
        public bool AutoAllocateClanMemberPerks
        {
            get => m_autoAllocateClanMemberPerks;
            set
            {
                SetField(ref m_autoAllocateClanMemberPerks, value, nameof(AutoAllocateClanMemberPerks));
                CampaignOptions.AutoAllocateClanMemberPerks = m_autoAllocateClanMemberPerks;
            }
        }

        #endregion

        public CustomCampaignOptionsVM(Action onClose)
        {
            m_onClose = onClose;
            RefreshValues();
        }

        public sealed override void RefreshValues()
        {
            base.RefreshValues();
            TitleText = new TextObject("Custom Campaign Options").ToString();
            CombatAIDifficulty = Options.CombatAIDifficulty;
            PlayerTroopsReceivedDamage = Options.PlayerTroopsReceivedDamage;
            PlayerFriendsReceivedDamage = Options.PlayerFriendsReceivedDamage;
            PlayerReceiveDamage = Options.PlayerReceiveDamage;
            MaximumIndexPlayerCanRecruit = Options.MaximumIndexPlayerCanRecruit;
            PlayerMapMovementSpeed = Options.PlayerMapMovementSpeed;
            PlayerXp = Options.PlayerXp;
            TroopXp = Options.TroopXp;
            Wages = Options.Wages;
            IsDeathEnabled = CampaignOptions.IsDeathEnabled;
            AutoAllocateClanMemberPerks = CampaignOptions.AutoAllocateClanMemberPerks;
        }

        private void ExecuteDone() => m_onClose?.Invoke();
    }
}