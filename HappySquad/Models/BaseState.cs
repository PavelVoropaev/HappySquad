
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Web.Mvc;

namespace HappySquad.Models
{
    public enum Type
    {
        HQ,
        Trpoops,
        Elite
    }
    public enum Race
    {
        Космодесант,
        Космические_Волки,
        Имперская_Гвардия,
        Черные_Храмовники,
        Серые_Рыцари,
        Темные_Ангелы,
        Кровавые_Ангелы,
        Космические_Десантники_Хаоса,
        Демоны_Хаоса,
        Орки,
        Тираниды,
        Тёмные_Эльдары,
        Эльдароы,
        Тау,
        Некроны
    }

    public class BaseState
    {
        public BaseState()
        {
             Races = Enum.GetValues(typeof(Race)).Cast<Race>().Select(x => new SelectListItem
            {
                Text = x.ToString(),
                Value = x.ToString()
            });
            Types = Enum.GetValues(typeof(Type)).Cast<Type>().Select(x => new SelectListItem
            {
                Text = x.ToString(),
                Value = x.ToString()
            });

        }

        /// <summary>
        /// Преобразование enum в IEnumerable для DropDownList на вьюхах
        /// </summary>
        public IEnumerable<SelectListItem> Races;

        /// <summary>
        /// Преобразование enum в IEnumerable для DropDownList на вьюхах
        /// </summary>
        public IEnumerable<SelectListItem> Types;

        public byte WS { set; get; }
        public byte BS { set; get; }
        public byte S { set; get; }
        public byte T { set; get; }
        public byte W { set; get; }
        public byte I { set; get; }
        public byte A { set; get; }
        public byte Ld { set; get; }
        public byte Sv { set; get; }
    }
}