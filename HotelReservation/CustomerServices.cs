using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
namespace HotelReservation
{
    public class CustomerServices
    {
        //Regex for normal customer type
        public string REGEX_NORMAL = @"^[Nn][Oo][Rr][Mm][Aa][Ll]$";
        //Regex for reward customer type
        public string REGEX_REWARD = @"^[Rr][Ee][Ww][Aa][Rr][Dd]$";
        /// <summary>
        /// Finds Cheapest Hotel with best rating
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="customerType"></param>
        /// <returns>HotelType enum</returns>
        public HotelType FindCheapHotel(string startDate, string endDate, CustomerType customerType)
        {
            HotelType hotelType = HotelType.LAKEWOOD;
            Hotel lakewood = new Hotel(hotelType, customerType);
            double rateLakewood = lakewood.FindRate(startDate, endDate);
            hotelType = HotelType.BRIDGEWOOD;
            Hotel bridgewood = new Hotel(hotelType, customerType);
            double rateBridgewood = bridgewood.FindRate(startDate, endDate);
            hotelType = HotelType.RIDGEWOOD;
            Hotel ridgewood = new Hotel(hotelType, customerType);
            double rateRidgewood = ridgewood.FindRate(startDate, endDate);
            if (rateLakewood < rateBridgewood && rateLakewood < rateRidgewood)
            {
                hotelType = HotelType.LAKEWOOD;
                Console.WriteLine("Best hotel for your stay is " + HotelType.LAKEWOOD + ", Rating: " + lakewood.RATING + ", Cost of stay: " + rateLakewood);
            }
            if ((rateBridgewood < rateLakewood && rateBridgewood < rateRidgewood) || (rateLakewood == rateBridgewood && rateBridgewood < rateRidgewood))
            {
                hotelType = HotelType.BRIDGEWOOD;
                Console.WriteLine("Best hotel for your stay is " + HotelType.BRIDGEWOOD + ", Rating: " + bridgewood.RATING + ", Cost of stay: " + rateBridgewood);
            }
            if ((rateRidgewood < rateLakewood && rateRidgewood < rateBridgewood) || (rateLakewood == rateRidgewood && rateRidgewood < rateBridgewood) || (rateBridgewood == rateRidgewood && rateRidgewood < rateLakewood))
            {
                hotelType = HotelType.RIDGEWOOD;
                Console.WriteLine("Best hotel for your stay is " + HotelType.RIDGEWOOD + ", Rating: " + ridgewood.RATING + ", Cost of stay: " + rateRidgewood);
            }
            return hotelType;
        }
        /// <summary>
        /// Finds best hotel according to rating
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <param name="customerType"></param>
        /// <returns>HotelType enum</returns>
        public HotelType FindBestRatedHotel(string startDate, string endDate, CustomerType customerType)
        {
            HotelType hotelType = HotelType.LAKEWOOD;
            Hotel lakewood = new Hotel(hotelType, customerType);
            double rateLakewood = lakewood.FindRate(startDate, endDate);
            hotelType = HotelType.BRIDGEWOOD;
            Hotel bridgewood = new Hotel(hotelType, customerType);
            double rateBridgewood = bridgewood.FindRate(startDate, endDate);
            hotelType = HotelType.RIDGEWOOD;
            Hotel ridgewood = new Hotel(hotelType, customerType);
            double rateRidgewood = ridgewood.FindRate(startDate, endDate);
            if (lakewood.RATING > bridgewood.RATING && lakewood.RATING > ridgewood.RATING)
            {
                hotelType = HotelType.LAKEWOOD;
                Console.WriteLine("Best hotel for your stay is " + HotelType.LAKEWOOD + ", Rating: " + lakewood.RATING + ", Cost of stay: " + rateLakewood);
            }
            if (bridgewood.RATING > lakewood.RATING && bridgewood.RATING > ridgewood.RATING)
            {
                hotelType = HotelType.BRIDGEWOOD;
                Console.WriteLine("Best hotel for your stay is " + HotelType.BRIDGEWOOD + ", Rating: " + bridgewood.RATING + ", Cost of stay: " + rateBridgewood);
            }
            if (ridgewood.RATING > lakewood.RATING && ridgewood.RATING > bridgewood.RATING)
            {
                hotelType = HotelType.RIDGEWOOD;
                Console.WriteLine("Best hotel for your stay is " + HotelType.RIDGEWOOD + ", Rating: " + ridgewood.RATING + ", Cost of stay: " + rateRidgewood);
            }
            return hotelType;
        }
        /// <summary>
        /// Validates customer type 
        /// </summary>
        /// <param name="customerType"></param>
        /// <returns>enum CustomerType</returns>
        public CustomerType Validate(string customerType)
        {
            if (Regex.IsMatch(customerType, REGEX_NORMAL))
                return CustomerType.NORMAL;
            if (Regex.IsMatch(customerType, REGEX_REWARD))
                return CustomerType.REWARD;
            else
                throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_CUSTOMER_TYPE, "Invalid customer type");
        }
    }
}
