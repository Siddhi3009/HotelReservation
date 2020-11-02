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
        private readonly double RATE;
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
                    this.RATE = 110;
                }
                if (hotelType.Equals(HotelType.BRIDGEWOOD))
                {
                    this.RATE = 150;
                }
                if (hotelType.Equals(HotelType.RIDGEWOOD))
                {
                    this.RATE = 220;
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
                    rate = rate + RATE;
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
