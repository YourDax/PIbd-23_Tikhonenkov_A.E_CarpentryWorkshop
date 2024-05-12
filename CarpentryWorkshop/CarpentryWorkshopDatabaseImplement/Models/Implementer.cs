using CarpentryWorkshopContracts.BindingModels;
using CarpentryWorkshopContracts.ViewModels;
using CarpentryWorkshopDataModels.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace CarpentryWorkshopDatabaseImplement.Models
{
    [DataContract]
    public class Implementer : IImplementerModel
	{
        [DataMember]
        public int Id { get; set; }

        [DataMember]
        [Required]
		public string ImplementerFIO { get; set; } = string.Empty;

        [DataMember]
        [Required]
		public string Password { get; set; } = string.Empty;

        [DataMember]
        [Required]
		public int WorkExperience { get; set; }

        [DataMember]
        [Required]
		public int Qualification { get; set; }

		[ForeignKey("ImplementerId")]
		public virtual List<Order> Order { get; set; } = new();

		public static Implementer? Create(ImplementerBindingModel? model)
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
				Qualification = model.Qualification
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
	}
}
