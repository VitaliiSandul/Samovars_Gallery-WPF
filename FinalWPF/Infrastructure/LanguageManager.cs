using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalWPF.Infrastructure
{
    public static class LanguageManager
    {
        public static Dictionary<string, string> GetDictionaryEnglish()
        {
            return new Dictionary<string, string>()
            {
                ["operations"] = "Operations",
                ["load"] = "Load",
                ["save"] = "Save",
                ["add"] = "Add",
                ["remove"] = "Remove",
                ["edit"] = "Edit",
                ["sort"] = "Sort",
                ["price (asc)"] = "Price (asc)",
                ["price (desc)"] = "Price (desc)",
                ["manufacturer (asc)"] = "Manufacturer (asc)",
                ["manufacturer (desc)"] = "Manufacturer (desc)",                
                ["model (asc)"] = "Model (asc)",
                ["model (desc)"] = "Model (desc)",
                ["volume (asc)"] = "Volume (asc)",
                ["volume (desc)"] = "Volume (desc)",
                ["manufacturer"] = "Manufacturer: ",
                ["model"] = "Model: ",
                ["volume"] = "Volume: ",
                ["l"] = " L"
            };
        }

        public static Dictionary<string, string> GetDictionaryRussian()
        {
            return new Dictionary<string, string>()
            {
                ["operations"] = "Операции",
                ["load"] = "Загрузить",
                ["save"] = "Сохранить",
                ["add"] = "Добавить",                
                ["remove"] = "Удалить",
                ["edit"] = "Редактировать",
                ["sort"] = "Сортировать",
                ["price (asc)"] = "Цена (возр.)",
                ["price (desc)"] = "Цена (убыв.)",
                ["manufacturer (asc)"] = "Производитель (возр.)",
                ["manufacturer (desc)"] = "Производитель (убыв.)",
                ["model (asc)"] = "Модель (возр.)",
                ["model (desc)"] = "Модель (убыв.)",
                ["volume (asc)"] = "Объем (возр.)",
                ["volume (desc)"] = "Объем (убыв.)",
                ["manufacturer"] = "Производитель: ",
                ["model"] = "Модель: ",
                ["volume"] = "Объем: ",
                ["l"] = " л"
            };
        }
    }
}
