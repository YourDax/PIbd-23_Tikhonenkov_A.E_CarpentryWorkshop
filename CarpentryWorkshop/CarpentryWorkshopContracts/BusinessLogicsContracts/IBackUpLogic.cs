using CarpentryWorkshopContracts.BindingModels;

namespace CarpentryWorkshopContracts.BusinessLogicsContracts
{
    public interface IBackUpLogic
    {
        void CreateBackUp(BackUpSaveBinidngModel model);
    }
}
