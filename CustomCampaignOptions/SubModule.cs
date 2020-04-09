using BannerLib.Gameplay.Models;
using CustomCampaignOptions.Behaviours;
using CustomCampaignOptions.GameModels;
using StoryMode.GameModels;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Map;
using TaleWorlds.CampaignSystem.SandBox.GameComponents.Party;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace CustomCampaignOptions
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            if (!(game.GameType is Campaign)) return;
            // Difficulty model
            gameStarterObject.Replace<DefaultDifficultyModel, CustomizableDifficultyModel>();
            // Xp Models
            gameStarterObject.Replace<DefaultGenericXpModel, CustomizableGenericXpModel>();
            gameStarterObject.Replace<StoryModeGenericXpModel, CustomizableStoryModeGenericXpModel>();
            // Wage Models
            gameStarterObject.Replace<DefaultPartyWageModel, CustomizablePartyWageModel>();
            gameStarterObject.Replace<StoryModePartyWageModel, CustomizableStoryModePartyWageModel>();
            // CombatXp Models
            gameStarterObject.Replace<DefaultCombatXpModel, CustomizableCombatXpModel>();
            gameStarterObject.Replace<StoryModeCombatXpModel, CustomizableStoryModeCombatXpModel>();
            ((CampaignGameStarter)gameStarterObject).AddBehavior(new CustomCampaignOptionsBehaviour());
        }
    }
}