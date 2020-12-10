using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_Bd_Mk2_Entity.Database.Tables
{
    public class UsersDatabaseRow
    {
        //Данные колонок таблицы пользователей
        string name;
        int principal_id;
        string type;
        string type_desc;
        string default_schema_name;
        DateTime create_date;
        DateTime modify_date;
        string authentication_type_desc;


        public UsersDatabaseRow(string aname, int aprincipal_id, string atype, string atype_desc,
                             string adefault_schema_name, DateTime acreate_date,
                             DateTime amodify_date, string aauthentication_type_desc)
        {
            name = aname;
            principal_id = aprincipal_id;
            type = atype;
            type_desc = atype_desc;
            default_schema_name = adefault_schema_name;
            create_date = acreate_date;
            modify_date = amodify_date;
            authentication_type_desc = aauthentication_type_desc;
        }

        //Функция получения массива строк нашего класса
        public string[] GetArrayStr()
        {
            string[] arr = { name, principal_id.ToString(), type, type_desc, default_schema_name,
            create_date.ToString(), modify_date.ToString(), authentication_type_desc };
            return arr;
        }

        //Константа, отвечающая за названия колонок
        public static string[] namesColumn = new string[] { "name", "principal_id", "type",
        "type_desc", "default_schema_name", "create_date", "modify_date",
            "authentication_type_desc" };
        //SELECT name, principal_id, type, type_desc, default_schema_name, create_date, modify_date, authentication_type_desc FROM sys.database_principals WHERE (type= 'S' or type = 'U')
    }
}
