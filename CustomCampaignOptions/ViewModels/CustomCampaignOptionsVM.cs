using System;
using CustomCampaignOptions.Behaviours;
using CustomCampaignOptions.Data;
using TaleWorlds.CampaignSystem;
using TaleWorlds.Library;
using TaleWorlds.Localization;

namespace CustomCampaignOptions.ViewModels
{
    public class CustomCampaignOptionsVM : ViewModel
    {
        private readonly Action m_onClose;

        private CustomCampaignOptionsData m_optionData => CustomCampaignOptionsBehaviour.m_optionsData;

        #region SliderMinMaxValues

        [DataSourceProperty] public float SliderFloatMinValue => 0f;

        [DataSourceProperty] public float SliderFloatMaxValue => 200f;

        [DataSourceProperty] public float SliderXpFloatMaxValue => 1000f;

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

        #region TroopsReceivedDamage
        private float m_playerTroopsReceivedDamage;
        private string m_playerTroopsReceivedDamageString;
        [DataSourceProperty]
        public float PlayerTroopsReceivedDamage
        {
            get => m_playerTroopsReceivedDamage;
            set
            {
                m_playerTroopsReceivedDamage = value;
                m_playerTroopsReceivedDamageString =
                    $"Player Troops Received Damage: {m_playerTroopsReceivedDamage:0}%";
                OnPropertyChanged(nameof(PlayerTroopsReceivedDamage));
                OnPropertyChanged(nameof(PlayerTroopsReceivedDamageString));
                if (m_optionData is null) return;
                m_optionData.m_playerTroopsReceivedDamage = value;
            }
        }
        [DataSourceProperty]
        public string PlayerTroopsReceivedDamageString => m_playerTroopsReceivedDamageString;
        #endregion

        #region PlayerFriendsReceivedDamage
        private float m_playerFriendsReceivedDamage;
        private string m_playerFriendsReceivedDamageString;
        [DataSourceProperty]
        public float PlayerFriendsReceivedDamage
        {
            get => m_playerFriendsReceivedDamage;
            set
            {
                m_playerFriendsReceivedDamage = value;
                m_playerFriendsReceivedDamageString =
                    $"Friendly Parties Received Damage: {m_playerFriendsReceivedDamage:0}%";
                OnPropertyChanged(nameof(PlayerFriendsReceivedDamage));
                OnPropertyChanged(nameof(PlayerFriendsReceivedDamageString));
                if (m_optionData is null) return;
                m_optionData.m_playerFriendsReceivedDamage = value;
            }
        }
        [DataSourceProperty]
        public string PlayerFriendsReceivedDamageString => m_playerFriendsReceivedDamageString;
        #endregion

        #region PlayerReceivedDamage
        private float m_playerReceiveDamage;
        private string m_playerReceiveDamageString;
        [DataSourceProperty]
        public float PlayerReceiveDamage
        {
            get => m_playerReceiveDamage;
            set
            {
                m_playerReceiveDamage = value;
                m_playerReceiveDamageString = $"Player Received Damage: {m_playerReceiveDamage:0}%";
                OnPropertyChanged(nameof(PlayerReceiveDamage));
                OnPropertyChanged(nameof(PlayerReceiveDamageString));
                if (m_optionData is null) return;
                m_optionData.m_playerReceiveDamage = value;
            }
        }
        [DataSourceProperty]
        public string PlayerReceiveDamageString => m_playerReceiveDamageString;
        #endregion

        #region MaximumIndexPlayerCanRecruit
        private int m_maximumIndexPlayerCanRecruit;
        private string m_maximumIndexPlayerCanRecruitString;
        [DataSourceProperty]
        public float MaximumIndexPlayerCanRecruit
        {
            get => m_maximumIndexPlayerCanRecruit;
            set
            {
                m_maximumIndexPlayerCanRecruit = (int)Math.Round(value);
                m_maximumIndexPlayerCanRecruitString =
                    $"Recruitable Troops: {m_maximumIndexPlayerCanRecruit} extra";
                OnPropertyChanged(nameof(MaximumIndexPlayerCanRecruit));
                OnPropertyChanged(nameof(MaximumIndexPlayerCanRecruitString));
                if (m_optionData is null) return;
                m_optionData.m_maximumIndexPlayerCanRecruit = m_maximumIndexPlayerCanRecruit;
            }
        }
        [DataSourceProperty]
        public string MaximumIndexPlayerCanRecruitString => m_maximumIndexPlayerCanRecruitString;
        #endregion
        
        #region PlayerMapMovementSpeed
        private float m_playerMapMovementSpeed;
        [DataSourceProperty]
        public float PlayerMapMovementSpeed
        {
            get => m_playerMapMovementSpeed;
            set
            {
                m_playerMapMovementSpeed = value;
                PlayerMapMovementSpeedString = $"Bonus Map Movement Speed: {m_playerMapMovementSpeed:0}%";
                OnPropertyChanged(nameof(PlayerMapMovementSpeed));
                OnPropertyChanged(nameof(PlayerMapMovementSpeedString));
                if (m_optionData is null) return;
                m_optionData.m_playerMapMovementSpeed = value;
            }
        }
        [DataSourceProperty]
        public string PlayerMapMovementSpeedString { get; private set; }
        #endregion
        
        #region PlayerXp
        private float m_playerXp;
        [DataSourceProperty]
        public float PlayerXp
        {
            get => m_playerXp;
            set
            {
                m_playerXp = value;
                PlayerXpString = $"Player Experience: {m_playerXp:0}%";
                OnPropertyChanged(nameof(PlayerXp));
                OnPropertyChanged(nameof(PlayerXpString));
                if (m_optionData is null) return;
                m_optionData.m_playerXp = value;
            }
        }
        [DataSourceProperty]
        public string PlayerXpString { get; private set; }
        #endregion

        #region IsDeathEnabled

        private bool m_isDeathEnabled;

        [DataSourceProperty]
        public bool IsDeathEnabled
        {
            get => m_isDeathEnabled;
            set
            {
                m_isDeathEnabled = value;
                OnPropertyChanged(nameof(IsDeathEnabled));
                CampaignOptions.IsDeathEnabled = value;
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
                m_autoAllocateClanMemberPerks = value;
                OnPropertyChanged(nameof(AutoAllocateClanMemberPerks));
                CampaignOptions.AutoAllocateClanMemberPerks = value;
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
            PlayerTroopsReceivedDamage = m_optionData.m_playerTroopsReceivedDamage;
            PlayerFriendsReceivedDamage = m_optionData.m_playerFriendsReceivedDamage;
            PlayerReceiveDamage = m_optionData.m_playerReceiveDamage;
            MaximumIndexPlayerCanRecruit = m_optionData.m_maximumIndexPlayerCanRecruit;
            PlayerMapMovementSpeed = m_optionData.m_playerMapMovementSpeed;
            PlayerXp = m_optionData.m_playerXp;
            IsDeathEnabled = CampaignOptions.IsDeathEnabled;
            AutoAllocateClanMemberPerks = CampaignOptions.AutoAllocateClanMemberPerks;
        }

        private void ExecuteDone() => m_onClose?.Invoke();
    }
}