using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
namespace HotelReservation
{
    /// <summary>
    /// Customer type 
    /// </summary>
    public enum CustomerType { NORMAL = 1, REWARD }
    public class Hotel
    {
        //Hotel name
        HotelType type;
        //Weekday rate of hotel
        private readonly double WEEKDAY_RATE;
        //Weekend rate of hotel
        private readonly double WEEKEND_RATE;
        //Rating of hotel
        public readonly int RATING;
        /// <summary>
        /// Parameterized constructor of Hotel
        /// </summary>
        /// <param name="hotelType"></param>
        public Hotel(HotelType hotelType, CustomerType customerType)
        {
            if (hotelType.Equals(HotelType.LAKEWOOD))
            {
                this.RATING = 3;
                try
                {
                    if (customerType.Equals(CustomerType.NORMAL))
                    {
                        this.WEEKDAY_RATE = 110;
                        this.WEEKEND_RATE = 90;
                    }
                    if (customerType.Equals(CustomerType.REWARD))
                    {
                        this.WEEKDAY_RATE = 80;
                        this.WEEKEND_RATE = 80;
                    }
                }
                catch (HotelReservationException)
                {
                    throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_CUSTOMER_TYPE, "Invalid customer type");
                }
            }
            if (hotelType.Equals(HotelType.BRIDGEWOOD))
            {
                this.RATING = 4;
                try
                {
                    if (customerType.Equals(CustomerType.NORMAL))
                    {
                        this.WEEKDAY_RATE = 150;
                        this.WEEKEND_RATE = 50;
                    }
                    if (customerType.Equals(CustomerType.REWARD))
                    {
                        this.WEEKDAY_RATE = 110;
                        this.WEEKEND_RATE = 50;
                    }
                }
                catch (HotelReservationException)
                {
                    throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_CUSTOMER_TYPE, "Invalid customer type");
                }
            }
            if (hotelType.Equals(HotelType.RIDGEWOOD))
            {
                this.RATING = 5;
                try
                {
                    if (customerType.Equals(CustomerType.NORMAL))
                    {
                        this.WEEKDAY_RATE = 220;
                        this.WEEKEND_RATE = 150;
                    }
                    if (customerType.Equals(CustomerType.REWARD))
                    {
                        this.WEEKDAY_RATE = 100;
                        this.WEEKEND_RATE = 40;
                    }
                }
                catch (Exception)
                {
                    throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_CUSTOMER_TYPE, "Invalid customer type");
                }
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
