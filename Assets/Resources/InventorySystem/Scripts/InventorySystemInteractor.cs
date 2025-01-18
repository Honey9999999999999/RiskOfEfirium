using Architecture;

namespace Assets.Scripts.InventorySystem
{
    public class InventorySystemInteractor : Interactor
    {
        public ItemInformationMap ItemInformationCard { get; private set; }

        public override void Initialize()
        {
            base.Initialize();            
        }
        public override void OnCreate()
        {
            base.OnCreate();

            ItemInformationCard = new();
        }

        public override void OnStart()
        {
            base.OnStart();
        }

        public override string ToString()
        {
            return base.ToString();
        }
    }
}
