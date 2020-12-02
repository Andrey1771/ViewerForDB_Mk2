using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_Bd_Mk2_Entity
{
    public class AirplaneRow
    {
        public int iDAirplane;
        public int iDOwner;
        public string name;
        public string model;
        public DateTime productionDate;
        public decimal? cost;

        public AirplaneRow(int aiDAirplane, int aiDOwner, string aname, string amodel, DateTime aproductionDate, decimal? acost)
        {
            iDAirplane = aiDAirplane;
            iDOwner = aiDOwner;
            name = aname;
            model = amodel;
            productionDate = aproductionDate;
            cost = acost;
        }

        public string[] GetArrayStr()
        {
            string[] arr = { iDAirplane.ToString(), iDOwner.ToString(), name, model, productionDate.ToString(), cost.ToString() };
            return arr;
        }

        public static string[] namesColumn = new string[] { "ID Самолета", "ID Владельца", "Название", "Модель", "Дата производства", "Стоимость" };
    }
}
