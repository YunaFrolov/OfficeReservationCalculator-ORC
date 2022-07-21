using OfficeReservationCalculator.Models;
using OfficeReservationCalculator.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;

namespace OfficeReservationCalculator.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            var Model = new HomeViewModel();
            List<Office> getOffices_List = _getOfficeDataFromCSV();
            Model.Offices = getOffices_List;

            return View(Model);
        }

        private List<Office> _getOfficeDataFromCSV()
        {
            string fileName = "rent_data.csv";
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"Extras\", fileName);
            List<Office> lOfficesFromCSV = System.IO.File.ReadAllLines(path)
                                           .Skip(1)
                                           .Select(v => Office.OfficeValuesFromCsv(v))
                                           .ToList();
            return lOfficesFromCSV;
        }


        public string _calcMonthRevenue(int iChosenMonth, int iChosenYear)
        {

            List<Office> lOfficesFromCSV = _getOfficeDataFromCSV();
            List<Office> lReservedThisMonth = new List<Office>();

            DateTime dtStartOfMonth = new DateTime(iChosenYear, iChosenMonth, 1);
            DateTime dtEndOfMonth = new DateTime(iChosenYear, iChosenMonth, DateTime.DaysInMonth(iChosenYear, iChosenMonth));

            foreach (var office in lOfficesFromCSV)
            {
                if (office.dtStartDay < dtEndOfMonth && office.dtEndDay > dtStartOfMonth)
                {
                    office.dtStartDay = office.dtStartDay < dtStartOfMonth ? dtStartOfMonth : office.dtStartDay;
                    office.dtEndDay = office.dtEndDay > dtEndOfMonth ? dtEndOfMonth : office.dtEndDay;
                    var DaysInMonthReserved = (office.dtEndDay - office.dtStartDay).TotalDays;
                    office.iMonthlyPrice = (int)(office.iMonthlyPrice / (DateTime.DaysInMonth(iChosenYear, iChosenMonth) - DaysInMonthReserved));
                    lReservedThisMonth.Add(office);
                }
            }

            decimal totalRevenue = lReservedThisMonth.Sum(revenue => revenue.iMonthlyPrice);

            string totalRevenueCurrency = String.Format("{0:C}", totalRevenue);

            return totalRevenueCurrency;
        }


        public int _calcMonthCapacity(int iChosenMonth, int iChosenYear)
        {
            List<Office> lOfficesFromCSV = _getOfficeDataFromCSV();
            List<Office> lUnreservedThisMonth = new List<Office>();

            DateTime dtStartOfMonth = new DateTime(iChosenYear, iChosenMonth, 1);
            DateTime dtEndOfMonth = new DateTime(iChosenYear, iChosenMonth, DateTime.DaysInMonth(iChosenYear, iChosenMonth));

            foreach (var office in lOfficesFromCSV)
            {
                if (  office.dtStartDay > dtEndOfMonth || office.dtEndDay < dtStartOfMonth  )
                    lUnreservedThisMonth.Add(office);
            }

            int totalReserved = lUnreservedThisMonth.Sum(reserved => reserved.sCapacity); 

            return totalReserved;
        }
    }
}