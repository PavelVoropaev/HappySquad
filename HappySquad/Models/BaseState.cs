
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
        �����������,
        �����������_�����,
        ���������_�������,
        ������_����������,
        �����_������,
        ������_������,
        ��������_������,
        �����������_����������_�����,
        ������_�����,
        ����,
        ��������,
        Ҹ����_�������,
        ��������,
        ���,
        �������
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
        /// �������������� enum � IEnumerable ��� DropDownList �� ������
        /// </summary>
        public IEnumerable<SelectListItem> Races;

        /// <summary>
        /// �������������� enum � IEnumerable ��� DropDownList �� ������
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