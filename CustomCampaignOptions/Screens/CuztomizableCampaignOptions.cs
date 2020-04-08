using CustomCampaignOptions.ViewModels;
using SandBox.View.Map;
using TaleWorlds.Engine.GauntletUI;
using TaleWorlds.Engine.Screens;
using TaleWorlds.InputSystem;
using TaleWorlds.MountAndBlade.View.Missions;

namespace CustomCampaignOptions.Screens
{
    [OverrideView(typeof(MapCampaignOptions))]
    public class CustomCampaignOptions : MapView
    {
        private CustomCampaignOptionsVM _dataSource;
        private GauntletLayer _layer;

        protected override void CreateLayout()
        {
            base.CreateLayout();
            _dataSource = new CustomCampaignOptionsVM(OnClose);
            var gauntletLayer = new GauntletLayer(4401) {IsFocusLayer = true};
            _layer = gauntletLayer;
            _layer.LoadMovie("CustomCampaignOptions", _dataSource);
            _layer.Input.RegisterHotKeyCategory(HotKeyManager.GetCategory("GenericPanelGameKeyCategory"));
            _layer.InputRestrictions.SetInputRestrictions();
            MapScreen.AddLayer(_layer);
            MapScreen.PauseAmbientSounds();
            ScreenManager.TrySetFocus(_layer);
        }

        private void OnClose()
        {
            MapScreen.Instance.CloseCampaignOptions();
        }

        protected override void OnFrameTick(float dt)
        {
            base.OnFrameTick(dt);
            if (!_layer.Input.IsHotKeyReleased("Exit"))
                return;
            OnClose();
        }

        protected override void OnFinalize()
        {
            base.OnFinalize();
            _layer.InputRestrictions.ResetInputRestrictions();
            MapScreen.RemoveLayer(_layer);
            MapScreen.RestartAmbientSounds();
            ScreenManager.TryLoseFocus(_layer);
            _layer = null;
            _dataSource = null;
        }
    }
}