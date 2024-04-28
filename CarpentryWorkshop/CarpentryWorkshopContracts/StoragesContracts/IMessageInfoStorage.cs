using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.ViewModels;

namespace CarpentryWorkshopContracts.StoragesContracts
{
    public interface IMessageInfoStorage
    {
        List<MessageInfoViewModel> GetFullList();

        List<MessageInfoViewModel> GetFilteredList(MessageInfoSearchModel model);

        MessageInfoViewModel? GetElement(MessageInfoSearchModel model);

        MessageInfoViewModel? Insert(MessageInfoBindingModel model);
		MessageInfoViewModel? Update(MessageInfoBindingModel model);
	}
}