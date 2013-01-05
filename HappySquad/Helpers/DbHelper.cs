namespace HappySquad.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.Mvc;

    using HappySquad.Models;

    public class DbHelper
    {
        private static readonly HappyDbContext DB = new HappyDbContext();

        public static string GetUnitNameById(int id)
        {
            try
            {
                return DB.Units.Find(id).Name;
            }
            catch (Exception)
            {
                return "Нет такого";
            }
        }

        public static string GetLootNameById(int id)
        {
            try
            {
                return DB.Loots.Find(id).Name;
            }
            catch (Exception)
            {
                return "Нет такого";
            }
        }

        public static IEnumerable<SelectListItem> GetRaceSelectList()
        {
            return from Race n in Enum.GetValues(typeof(Race))
                   select new SelectListItem
                  {
                      Value = Convert.ToInt16(n).ToString(),
                      Text = EnumHelper.GetEnumDescription(n),
                  };
        }
    }
}