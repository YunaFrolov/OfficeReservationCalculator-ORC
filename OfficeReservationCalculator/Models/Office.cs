using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace OfficeReservationCalculator.Models
{
    public class Office
    {
        public int sCapacity { get; set; }
        public int iMonthlyPrice { get; set; }
        public DateTime dtStartDay { get; set; }
        public DateTime dtEndDay { get; set; }

        public static Office OfficeValuesFromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Office officeData = new Office();
            officeData.sCapacity = Convert.ToInt32(values[0]);
            officeData.iMonthlyPrice = Convert.ToInt32(values[1]);
            officeData.dtStartDay = Convert.ToDateTime(values[2]);
            officeData.dtEndDay = values[3] == "" ? new DateTime(9999, 12, 31) : Convert.ToDateTime(values[3]);

            return officeData;
        }

    }
}