using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace HotelReservation
{
    class Hotel
    {
        //Hotel name
        HotelType type;
        //Weekday rate of hotel
        private readonly double WEEKDAY_RATE;
        //Weekend rate of hotel
        private readonly double WEEKEND_RATE;
        /// <summary>
        /// Parameterized constructor of Hotel
        /// </summary>
        /// <param name="hotelType"></param>
        public Hotel(HotelType hotelType)
        {
            this.type = hotelType;
            try
            {
                if (hotelType.Equals(HotelType.LAKEWOOD))
                {
                    this.WEEKDAY_RATE = 110;
                    this.WEEKEND_RATE = 90;
                }
                if (hotelType.Equals(HotelType.BRIDGEWOOD))
                {
                    this.WEEKDAY_RATE = 150;
                    this.WEEKEND_RATE = 50;
                }
                if (hotelType.Equals(HotelType.RIDGEWOOD))
                {
                    this.WEEKDAY_RATE = 220;
                    this.WEEKEND_RATE = 150;
                }
            }
            catch (HotelReservationException)
            {
                throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_HOTEL_TYPE, "Invalid Hotel Type");
            }
        }
        /// <summary>
        /// Finds rate of stay from startdate to end date at hotel
        /// </summary>
        /// <param name="startDateString"></param>
        /// <param name="endDateString"></param>
        /// <returns>rate of stay</returns>
        public double FindRate(string startDateString, string endDateString)
        {
            double rate = 0;
            try
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                DateTime startDate = Convert.ToDateTime(startDateString);
                DateTime endDate = Convert.ToDateTime(endDateString);
                for (; startDate <= endDate; startDate = startDate.AddDays(1))
                {
                    if (startDate.DayOfWeek == DayOfWeek.Saturday || startDate.DayOfWeek == DayOfWeek.Sunday)
                        rate = rate + WEEKEND_RATE;
                    else
                        rate = rate + WEEKDAY_RATE;
                }
            }
            catch (Exception)
            {
                throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_DATE, "Invalid date entered");
            }
            return rate;
        }
    }
}
