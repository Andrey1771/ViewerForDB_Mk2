using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_Bd_Mk2_Entity
{
    public class AirlineRow
    {
        public int iDAirline;
        public string nameCompany;
        public string location;
        public DateTime foundationDate;
        public int? staffCount;

        public AirlineRow(int aiDAirline, string anameCompany, string alocation, DateTime afoundationDate, int? astaffCount)
        {
            iDAirline = aiDAirline;
            nameCompany = anameCompany;
            location = alocation;
            foundationDate = afoundationDate;
            staffCount = astaffCount;
        }

        //Вообще, это по красивому перегружается через IEnumerator, но....
        public string[] GetArrayStr()
        {
            string[] arr = { iDAirline.ToString(), nameCompany, location, foundationDate.ToString(), staffCount.ToString() };
            return arr;
        }

        public static string[] namesColumn = new string[] { "ID Авиакомпании", "Название компании", "Расположение", "Дата основания", "Количество персонала" };
    }
}
