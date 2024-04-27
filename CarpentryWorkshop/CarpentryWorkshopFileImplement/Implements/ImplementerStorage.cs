using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.StoragesContracts;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpentryWorkshopFileImplement.Implements
{
	public class ImplementerStorage : IImplementerStorage
	{
		private readonly DataFileSingleton source;

		public ImplementerStorage()
		{
			source = DataFileSingleton.GetInstance();
		}

		public List<ImplementerViewModel> GetFullList()
		{
			return source.Implementers
				.Select(x => x.GetViewModel)
				.ToList();
		}

		public List<ImplementerViewModel> GetFilteredList(ImplementerSearchModel model)
		{
			if (string.IsNullOrEmpty(model.ImplementerFIO))
			{
				return new();
			}
			return source.Implementers
					.Where(x => x.ImplementerFIO.Contains(model.ImplementerFIO))
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public ImplementerViewModel? GetElement(ImplementerSearchModel model)
		{
			if (!model.Id.HasValue && string.IsNullOrEmpty(model.ImplementerFIO) && string.IsNullOrEmpty(model.Password))
			{
				return null;
			}
			return source.Implementers
					.FirstOrDefault(x => (model.Id.HasValue && x.Id == model.Id) ||
						(!string.IsNullOrEmpty(model.ImplementerFIO) && x.ImplementerFIO == model.ImplementerFIO &&
						!string.IsNullOrEmpty(model.Password) && x.Password == model.Password))
					?.GetViewModel;
		}

		public ImplementerViewModel? Insert(ImplementerBindingModel model)
		{
			model.Id = source.Components.Count > 0 ? source.Components.Max(x => x.Id) + 1 : 1;
			var newImplementer = Implementer.Create(model);
			if (newImplementer == null)
			{
				return null;
			}
			source.Implementers.Add(newImplementer);
			source.SaveImplementers();
			return newImplementer.GetViewModel;
		}

		public ImplementerViewModel? Update(ImplementerBindingModel model)
		{
			var implementer = source.Implementers.FirstOrDefault(x => x.Id == model.Id);
			if (implementer == null)
			{
				return null;
			}
			implementer.Update(model);
			source.SaveImplementers();
			return implementer.GetViewModel;
		}

		public ImplementerViewModel? Delete(ImplementerBindingModel model)
		{
			var element = source.Implementers.FirstOrDefault(x => x.Id == model.Id);
			if (element != null)
			{
				source.Implementers.Remove(element);
				source.SaveImplementers();
				return element.GetViewModel;
			}
			return null;
		}
	}
}
