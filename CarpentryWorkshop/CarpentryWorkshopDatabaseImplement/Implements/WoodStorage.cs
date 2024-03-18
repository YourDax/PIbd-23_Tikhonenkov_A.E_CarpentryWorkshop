using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.SearchModels;
using CarpentryWorkshopContracts.StoragesContracts;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;

namespace CarpentryWorkshopDatabaseImplement.Implements
{
    public class WoodStorage : IWoodStorage
    {
		public List<WoodViewModel> GetFullList()
		{
			using var context = new CarpentryWorkshopDatabase();
			return context.Woods
					.Include(x => x.Components)
					.ThenInclude(x => x.Component)
					.ToList()
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public List<WoodViewModel> GetFilteredList(WoodSearchModel model)
		{
			if (string.IsNullOrEmpty(model.WoodName))
			{
				return new();
			}
			using var context = new CarpentryWorkshopDatabase();
			return context.Woods
					.Include(x => x.Components)
					.ThenInclude(x => x.Component)
					.Where(x => x.WoodName.Contains(model.WoodName))
					.ToList()
					.Select(x => x.GetViewModel)
					.ToList();
		}

		public WoodViewModel? GetElement(WoodSearchModel model)
		{
			if (string.IsNullOrEmpty(model.WoodName) && !model.Id.HasValue)
			{
				return null;
			}
			using var context = new CarpentryWorkshopDatabase();
			return context.Woods
				.Include(x => x.Components)
				.ThenInclude(x => x.Component)
				.FirstOrDefault(x => (!string.IsNullOrEmpty(model.WoodName) && x.WoodName == model.WoodName) ||
								(model.Id.HasValue && x.Id == model.Id))
				?.GetViewModel;
		}

		public WoodViewModel? Insert(WoodBindingModel model)
		{
			using var context = new CarpentryWorkshopDatabase();
			var newWood = Wood.Create(context, model);
			if (newWood == null)
			{
				return null;
			}
			context.Woods.Add(newWood);
			context.SaveChanges();
			return newWood.GetViewModel;
		}

		public WoodViewModel? Update(WoodBindingModel model)
		{
			using var context = new CarpentryWorkshopDatabase();
			using var transaction = context.Database.BeginTransaction();
			try
			{
				var wood = context.Woods.FirstOrDefault(rec => rec.Id == model.Id);
				if (wood == null)
				{
					return null;
				}
				wood.Update(model);
				context.SaveChanges();
				wood.UpdateComponents(context, model);
				transaction.Commit();
				return wood.GetViewModel;
			}
			catch
			{
				transaction.Rollback();
				throw;
			}
		}

		public WoodViewModel? Delete(WoodBindingModel model)
		{
			using var context = new CarpentryWorkshopDatabase();
			var element = context.Woods
				.Include(x => x.Components)
				.FirstOrDefault(rec => rec.Id == model.Id);
			if (element != null)
			{
				context.Woods.Remove(element);
				context.SaveChanges();
				return element.GetViewModel;
			}
			return null;
		}
	}
}