using System;
using TaleWorlds.SaveSystem;

namespace CustomCampaignOptions.Data
{
    public class CustomCampaignOptionsData
    {
        [SaveableField(1)] public float m_playerTroopsReceivedDamage = 100f;
        [SaveableField(2)] public float m_playerFriendsReceivedDamage = 100f;
        [SaveableField(3)] public float m_playerReceiveDamage = 100f;
        [SaveableField(4)] public int m_maximumIndexPlayerCanRecruit = 0;
        [SaveableField(5)] public float m_playerMapMovementSpeed = 0f;
        [SaveableField(6)] public float m_playerXp = 100f;
    }
}