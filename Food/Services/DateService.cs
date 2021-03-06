﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Food.Services
{
    public class DateService
    {
        public static string GetTextMonth(int month)
        {
            var result = string.Empty;
            switch (month)
            {
                case 1:
                    result = "Enero";
                    break;
                case 2:
                    result = "Febrero";
                    break;
                case 3:
                    result = "Marzo";
                    break;
                case 4:
                    result = "Abril";
                    break;
                case 5:
                    result = "Mayo";
                    break;
                case 6:
                    result = "Junio";
                    break;
                case 7:
                    result = "Julio";
                    break;
                case 8:
                    result = "Agosto";
                    break;
                case 9:
                    result = "Septiembre";
                    break;
                case 10:
                    result = "Octubre";
                    break;
                case 11:
                    result = "Noviembre";
                    break;
                case 12:
                    result = "Diciembre";
                    break;

            }
            return result;
        }
        public static string GetTextDayOfWeek(DateTime date)
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
                    result = "Miércoles";
                    break;
            }
            return result;
        }
        public static DateTime GetSundayOfWeek(DateTime date)
        {
            var newDate = DateTime.Today;
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    newDate = date.AddDays(0);
                    break;
                case DayOfWeek.Monday:
                    newDate = date.AddDays(-1);
                    break;
                case DayOfWeek.Tuesday:
                    newDate = date.AddDays(-2);
                    break;
                case DayOfWeek.Wednesday:
                    newDate = date.AddDays(-3);
                    break;
                case DayOfWeek.Thursday:
                    newDate = date.AddDays(-4);
                    break;
                case DayOfWeek.Friday:
                    newDate = date.AddDays(-5);
                    break;
                case DayOfWeek.Saturday:
                    newDate = date.AddDays(-6);
                    break;
            }
            return newDate;
        }
    }
}