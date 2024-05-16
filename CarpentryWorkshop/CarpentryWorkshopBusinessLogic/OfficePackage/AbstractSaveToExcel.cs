using CarpentryWorkshopBusinessLogic.OfficePackage.HelperEnums;
using CarpentryWorkshopBusinessLogic.OfficePackage.HelperModels;

namespace CarpentryWorkshopBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToExcel
    {
		/// <summary>
		/// Создание отчета
		/// </summary>
		/// <param name="info"></param>
		public void CreateReport(ExcelInfo info)
		{
			CreateExcel(info);

			InsertCellInWorksheet(new ExcelCellParameters
			{
				ColumnName = "A",
				RowIndex = 1,
				Text = info.Title,
				StyleInfo = ExcelStyleInfoType.Title
			});

			MergeCells(new ExcelMergeParameters
			{
				CellFromName = "A1",
				CellToName = "C1"
			});

			uint rowIndex = 2;
			foreach (var pc in info.WoodComponents)
			{
				InsertCellInWorksheet(new ExcelCellParameters
				{
					ColumnName = "A",
					RowIndex = rowIndex,
					Text = pc.WoodName,
					StyleInfo = ExcelStyleInfoType.Text
				});
				rowIndex++;

				foreach (var (Component, Count) in pc.Components)
				{
					InsertCellInWorksheet(new ExcelCellParameters
					{
						ColumnName = "B",
						RowIndex = rowIndex,
						Text = Component,
						StyleInfo = ExcelStyleInfoType.TextWithBroder
					});

					InsertCellInWorksheet(new ExcelCellParameters
					{
						ColumnName = "C",
						RowIndex = rowIndex,
						Text = Count.ToString(),
						StyleInfo = ExcelStyleInfoType.TextWithBroder
					});

					rowIndex++;
				}

				InsertCellInWorksheet(new ExcelCellParameters
				{
					ColumnName = "A",
					RowIndex = rowIndex,
					Text = "Итого",
					StyleInfo = ExcelStyleInfoType.Text
				});
				InsertCellInWorksheet(new ExcelCellParameters
				{
					ColumnName = "C",
					RowIndex = rowIndex,
					Text = pc.TotalCount.ToString(),
					StyleInfo = ExcelStyleInfoType.Text
				});
				rowIndex++;
			}

			SaveExcel(info);
		}
        public void CreateShopWoodsReport(ExcelShop info)
        {
            CreateExcel(info);

            InsertCellInWorksheet(new ExcelCellParameters
            {
                ColumnName = "A",
                RowIndex = 1,
                Text = info.Title,
                StyleInfo = ExcelStyleInfoType.Title
            });

            MergeCells(new ExcelMergeParameters
            {
                CellFromName = "A1",
                CellToName = "C1"
            });

            uint rowIndex = 2;
            foreach (var sr in info.ShopWoods)
            {
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    ColumnName = "A",
                    RowIndex = rowIndex,
                    Text = sr.ShopName,
                    StyleInfo = ExcelStyleInfoType.Text
                });
                rowIndex++;

                foreach (var (Wood, Count) in sr.Woods)
                {
                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        ColumnName = "B",
                        RowIndex = rowIndex,
                        Text = Wood,
                        StyleInfo = ExcelStyleInfoType.TextWithBroder
                    });


                    InsertCellInWorksheet(new ExcelCellParameters
                    {
                        ColumnName = "C",
                        RowIndex = rowIndex,
                        Text = Count.ToString(),
                        StyleInfo = ExcelStyleInfoType.TextWithBroder
                    });

                    rowIndex++;
                }

                InsertCellInWorksheet(new ExcelCellParameters
                {
                    ColumnName = "A",
                    RowIndex = rowIndex,
                    Text = "Итого",
                    StyleInfo = ExcelStyleInfoType.Text
                });
                InsertCellInWorksheet(new ExcelCellParameters
                {
                    ColumnName = "C",
                    RowIndex = rowIndex,
                    Text = sr.TotalCount.ToString(),
                    StyleInfo = ExcelStyleInfoType.Text
                });
                rowIndex++;
            }

            SaveExcel(info);
        }


        /// <summary>
        /// Создание excel-файла
        /// </summary>
        /// <param name="info"></param>
        protected abstract void CreateExcel(IDocument info);

		/// <summary>
		/// Добавляем новую ячейку в лист
		/// </summary>
		/// <param name="cellParameters"></param>
		protected abstract void InsertCellInWorksheet(ExcelCellParameters excelParams);

		/// <summary>
		/// Объединение ячеек
		/// </summary>
		/// <param name="mergeParameters"></param>
		protected abstract void MergeCells(ExcelMergeParameters excelParams);

		/// <summary>
		/// Сохранение файла
		/// </summary>
		/// <param name="info"></param>
		protected abstract void SaveExcel(IDocument info);
	}
}