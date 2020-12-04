using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_Bd_Mk2_Entity
{
    public class OwnerRow
    {
        public int iDOwner;
        public string firstNameOwner;
        public string age;
        public int? passportSeries;
        public string secondNameOwner;

        public OwnerRow(int aiDOwner, string afirstNameOwner, string aage, int? apassportSeries, string asecondNameOwner)
        {
            iDOwner = aiDOwner;
            firstNameOwner = afirstNameOwner;
            age = aage;
            passportSeries = apassportSeries;
            secondNameOwner = asecondNameOwner;
        }

        public string[] GetArrayStr()
        {
            //тут не хватает проверок на null, делается это легко
            string[] arr = { iDOwner.ToString(), firstNameOwner, age.ToString(), passportSeries.ToString(), secondNameOwner };
            return arr;
        }

        public static string[] namesColumn = new string[] { "ID Владельца", "Имя Владельца", "Возраст", "Серия паспорта", "Фамилия Владельца" };
    }
}
