using BannerLib.Gameplay.Models;
using CustomCampaignOptions.Behaviours;
using CustomCampaignOptions.GameModels;
using StoryMode.GameModels;
using TaleWorlds.CampaignSystem;
using TaleWorlds.CampaignSystem.SandBox.GameComponents;
using TaleWorlds.Core;
using TaleWorlds.MountAndBlade;

namespace CustomCampaignOptions
{
    public class SubModule : MBSubModuleBase
    {
        protected override void OnGameStart(Game game, IGameStarter gameStarterObject)
        {
            if (!(game.GameType is Campaign)) return;
            gameStarterObject.Replace<DefaultDifficultyModel, CustomizableDifficultyModel>();
            gameStarterObject.Replace<DefaultGenericXpModel, CustomizableGenericXpModel>();
            gameStarterObject.Replace<StoryModeGenericXpModel, CustomizableStoryModeGenericXpModel>();
            ((CampaignGameStarter)gameStarterObject).AddBehavior(new CustomCampaignOptionsBehaviour());
        }
    }
}