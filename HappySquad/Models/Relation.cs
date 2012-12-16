namespace HappySquad.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Relation
    {
        private readonly HappyDbContext db = new HappyDbContext();

        public int Id { get; set; }

        public int UnitId { get; set; }

        public int LootId { get; set; }

        public string AddLootId { get; set; }

        public string ExLootId { get; set; }

        public List<int> ExLootIdList
        {
            get
            {
                try
                {
                    return this.ExLootId.Split(',').Select(value => Convert.ToInt32(value)).ToList();
                }
                catch (Exception)
                {
                    return new List<int>();
                }
            }
        }

        public List<int> AddLootIdList
        {
            get
            {
                try
                {
                    return this.AddLootId.Split(',').Select(value => Convert.ToInt32(value)).ToList();
                }
                catch (Exception)
                {
                    return new List<int>();
                }
            }
        }

        public string UnitName
        {
            get { return this.db.Units.Find(this.UnitId).Name; }
        }

        public string LootName
        {
            get { return this.db.Loots.Find(this.LootId).Name; }
        }

        public List<string> AddLootName
        {
            get
            {
                if (string.IsNullOrEmpty(this.AddLootId))
                {
                    return new List<string>();
                }

                var addLootIds = this.AddLootId.Split(',');
                var result = new List<string>();
                foreach (var id in addLootIds)
                {
                    try
                    {
                        result.Add(this.db.Loots.Find(Convert.ToInt32(id)).Name);
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
                if (string.IsNullOrEmpty(this.ExLootId))
                {
                    return new List<string>();
                }

                var exLootIds = this.ExLootId.Split(',');
                var result = new List<string>();
                foreach (var id in exLootIds)
                {
                    try
                    {
                        result.Add(this.db.Loots.Find(Convert.ToInt32(id)).Name);
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