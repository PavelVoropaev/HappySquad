namespace HappySquad.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using HappySquad.Helpers;

    public class Relation
    {
        public int Id { get; set; }

        public int UnitId { get; set; }

        public int LootId { get; set; }

        public string AddLootId { get; set; }

        public string ExLootId { get; set; }

        public string[] AddLootIdArray
        {
            get
            {
                try
                {
                    return this.AddLootId.Split(',').ToArray();
                }
                catch (Exception)
                {
                    return new string[0];
                }
            }

            set
            {
                this.AddLootId = string.Join(",", value);
            }
        }

        public string[] ExLootIdArray
        {
            get
            {
                try
                {
                    return this.ExLootId.Split(',').ToArray();
                }
                catch (Exception)
                {
                    return new string[0];
                }
            }

            set
            {
                this.ExLootId = string.Join(",", value);
            }
        }

        public string UnitName
        {
            get
            {
                return DbHelper.GetUnitNameById(this.UnitId);
            }
        }

        public string LootName
        {
            get
            {
                return DbHelper.GetLootNameById(this.LootId);
            }
        }

        public List<string> AddLootName
        {
            get
            {
                if (this.AddLootId == null)
                {
                    return new List<string>();
                }

                var result = new List<string>();
                foreach (var id in this.AddLootIdArray)
                {
                    try
                    {
                        result.Add(DbHelper.GetLootNameById(Convert.ToInt32(id)));
                    }
                    catch
                    {
                        result.Add("Нет такого лута!");
                    }
                }

                return result;
            }
        }

        public List<string> ExLootName
        {
            get
            {
                if (this.ExLootId == null)
                {
                    return new List<string>();
                }

                var result = new List<string>();
                foreach (var id in this.ExLootIdArray)
                {
                    try
                    {
                        result.Add(DbHelper.GetLootNameById(Convert.ToInt32(id)));
                    }
                    catch
                    {
                        result.Add("Нет такого лута!");
                    }
                }

                return result;
            }
        }
    }
}