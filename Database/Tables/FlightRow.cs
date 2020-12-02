using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab7_Bd_Mk2_Entity
{
    public class FlightRow
    {
        public int iDFlight;
        public int iDAirplane;
        public int iDAirline;
        public string destination;
        public decimal? cost;
        public DateTime departureTime;
        public DateTime arrivalTime;

        public FlightRow(int aiDFlight, int aiDAirplane, int aiDAirline, string adestination,
            decimal? acost, DateTime adepartureTime, DateTime aarrivalTime)
        {
            iDFlight = aiDFlight;
            iDAirplane = aiDAirplane;
            iDAirline = aiDAirline;
            destination = adestination;
            cost = acost;
            departureTime = adepartureTime;
            arrivalTime = aarrivalTime;
        }

        public string[] GetArrayStr()
        {
            string[] arr = { iDFlight.ToString(), iDAirplane.ToString(), iDAirline.ToString(), destination,
                cost.ToString(), departureTime.ToString(), arrivalTime.ToString() };
            return arr;
        }

        public static string[] namesColumn = new string[] { "ID Рейса", "ID Самолета", "ID Авиакомпании", "Пункт назначения", "Цена", "Время отправления", "Время прибытия" };
    }
}
