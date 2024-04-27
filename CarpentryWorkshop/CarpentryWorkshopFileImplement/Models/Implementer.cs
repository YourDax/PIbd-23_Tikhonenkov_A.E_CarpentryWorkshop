using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace CarpentryWorkshopFileImplement.Models
{
	public class Implementer : IImplementerModel
	{
		public int Id { get; private set; }

		public string ImplementerFIO { get; private set; } = string.Empty;

		public string Password { get; private set; } = string.Empty;

		public int WorkExperience { get; private set; }

		public int Qualification { get; private set; }

		public static Implementer? Create(ImplementerBindingModel model)
		{
			if (model == null)
			{
				return null;
			}
			return new Implementer()
			{
				Id = model.Id,
				ImplementerFIO = model.ImplementerFIO,
				Password = model.Password,
				WorkExperience = model.WorkExperience,
				Qualification = model.Qualification,
			};
		}

		public static Implementer? Create(XElement element)
		{
			if (element == null)
			{
				return null;
			}
			return new Implementer()
			{
				Id = Convert.ToInt32(element.Attribute("Id")!.Value),
				ImplementerFIO = element.Element("ImplementerFIO")!.Value,
				Password = element.Element("Password")!.Value,
				WorkExperience = Convert.ToInt32(element.Element("Cost")!.Value),
				Qualification = Convert.ToInt32(element.Element("Cost")!.Value)
			};
		}

		public void Update(ImplementerBindingModel model)
		{
			if (model == null)
			{
				return;
			}
			ImplementerFIO = model.ImplementerFIO;
			Password = model.Password;
			WorkExperience = model.WorkExperience;
			Qualification = model.Qualification;
		}

		public ImplementerViewModel GetViewModel => new()
		{
			Id = Id,
			ImplementerFIO = ImplementerFIO,
			Password = Password,
			WorkExperience = WorkExperience,
			Qualification = Qualification
		};

		public XElement GetXElement => new("Implementer",
			new XAttribute("Id", Id),
			new XElement("ImplementerFIO", ImplementerFIO),
			new XElement("Password", Password),
			new XElement("WorkExperience", WorkExperience),
			new XElement("Qualification", Qualification));
	}
}
