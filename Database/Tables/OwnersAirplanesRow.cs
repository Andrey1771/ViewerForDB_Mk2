using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_Bd_Mk2_Entity.Database.Tables
{
    public class OwnersAirplanesRow
    {
        public string firstNameOwner;
        public string secondNameOwner;

        public OwnersAirplanesRow(string afirstNameOwner, string asecondNameOwner)
        {
            firstNameOwner = afirstNameOwner;
            secondNameOwner = asecondNameOwner;
        }
        public string[] GetArrayStr()
        {
            string[] arr = { firstNameOwner, secondNameOwner };
            return arr;
        }
        public static string[] namesColumn = new string[] { "Имя Владельца", "Фамилия Владельца"};
    };
}
