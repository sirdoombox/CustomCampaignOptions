using TaleWorlds.SaveSystem;

namespace CustomCampaignOptions.Data
{
    public class SaveableDataDefinition : SaveableTypeDefiner
    {
        public SaveableDataDefinition() : base(696942069)
        {
        }
    
        protected override void DefineClassTypes()
        {
            AddClassDefinition(typeof(CustomCampaignOptionsData), 1);
        }
    }
}