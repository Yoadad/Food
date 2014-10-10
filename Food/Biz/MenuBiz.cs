using Food.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Food.Models;

namespace Food.Biz
{
    public class MenuBiz
    {
        public IEnumerable<Menu> GetWeekMenu(DateTime date)
        {
            var menus = new List<Menu>();
            var sundayDate = GetSundayOfWeek(date);

            for (int i = 0; i < 7; i++)
            {
                var dayDate = sundayDate.AddDays(i);
                var menu = new Menu()
                {
                    Name = GetTextDayOfWeek(dayDate),
                    Date = dayDate
                }; 

                

                menus.Add(menu);
            }
            return menus;
        }

        public DateTime GetSundayOfWeek(DateTime date)
        {
            var newDate = DateTime.Today;
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    newDate=date.AddDays(0);
                    break;
                case DayOfWeek.Monday:
                    newDate=date.AddDays(-1);
                    break;
                case DayOfWeek.Tuesday:
                    newDate=date.AddDays(-2);
                    break;
                case DayOfWeek.Wednesday:
                    newDate=date.AddDays(-3);
                    break;
                case DayOfWeek.Thursday:
                    newDate=date.AddDays(-4);
                    break;
                case DayOfWeek.Friday:
                    newDate=date.AddDays(-5);
                    break;
                case DayOfWeek.Saturday:
                    newDate=date.AddDays(-6);
                    break;
            }
            return newDate;
        }

        public string GetTextDayOfWeek(DateTime date)
        {
            var result = string.Empty;
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Friday:
                    result = "Viernes";
                    break;
                case DayOfWeek.Monday:
                    result = "Lunes";
                    break;
                case DayOfWeek.Saturday:
                    result = "Sábado";
                    break;
                case DayOfWeek.Sunday:
                    result = "Domingo";
                    break;
                case DayOfWeek.Thursday:
                    result = "Jueves";
                    break;
                case DayOfWeek.Tuesday:
                    result = "Martes";
                    break;
                case DayOfWeek.Wednesday:
                    result = "Miercoles";
                    break;
            }
            return result;
        }



    }
}