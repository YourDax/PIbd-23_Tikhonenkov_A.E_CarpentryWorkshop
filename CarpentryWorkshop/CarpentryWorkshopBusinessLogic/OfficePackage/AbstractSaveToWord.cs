using CarpentryWorkshopBusinessLogic.OfficePackage.HelperEnums;
using CarpentryWorkshopBusinessLogic.OfficePackage.HelperModels;

namespace CarpentryWorkshopBusinessLogic.OfficePackage
{
    public abstract class AbstractSaveToWord
    {
        public void CreateDoc(WordInfo info)
        {
            CreateWord(info);

            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = true, Size = "24", }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });

            foreach (var wood in info.Woods)
            {
                CreateParagraph(new WordParagraph
                {
                    Texts = new List<(string, WordTextProperties)> {
                        (wood.WoodName + ": ", new WordTextProperties { Size = "24", Bold = true }),
                        (Convert.ToInt32(wood.Price).ToString(), new WordTextProperties { Size = "24", })},
                    TextProperties = new WordTextProperties
                    {
                        Size = "24",
                        JustificationType = WordJustificationType.Both
                    }
                });
            }

            SaveWord(info);
        }
        public void CreateShopsDoc(WordShopInfo info)
        {
            CreateWord(info);
            CreateParagraph(new WordParagraph
            {
                Texts = new List<(string, WordTextProperties)> { (info.Title, new WordTextProperties { Bold = true, Size = "24", }) },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    JustificationType = WordJustificationType.Center
                }
            });

            CreateTable(new List<string> { "3000", "3000", "3000" });
            CreateRow(new WordRowParameters
            {
                Texts = new List<string> { "Название", "Адрес", "Дата открытия" },
                TextProperties = new WordTextProperties
                {
                    Size = "24",
                    Bold = true,
                    JustificationType = WordJustificationType.Center
                }
            });

            foreach (var shop in info.Shops)
            {
                CreateRow(new WordRowParameters
                {
                    Texts = new List<string> { shop.ShopName, shop.Address, shop.DateOpen.ToString() },
                    TextProperties = new WordTextProperties
                    {
                        Size = "22",
                        JustificationType = WordJustificationType.Both
                    }
                });
            }

            SaveWord(info);
        }

        /// <summary>
		/// Создание doc-файла
		/// </summary>
		/// <param name="info"></param>
        protected abstract void CreateWord(IDocument info);

        /// <summary>
        /// Создание абзаца с текстом
        /// </summary>
        /// <param name="paragraph"></param>
        /// <returns></returns>
        protected abstract void CreateParagraph(WordParagraph paragraph);

        /// <summary>
		/// Сохранение файла
		/// </summary>
		/// <param name="info"></param>
        protected abstract void SaveWord(IDocument info);
        protected abstract void CreateTable(List<string> colums);
        protected abstract void CreateRow(WordRowParameters rowParameters);
    }
}