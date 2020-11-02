using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    class CustomerServices
    {
        /// <summary>
        /// Finds Cheapest Hotel with best rating
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        public void FindCheapHotel(string startDate, string endDate)
        {
            HotelType hotelType = HotelType.LAKEWOOD;
            Hotel lakewood = new Hotel(hotelType);
            double rateLakewood = lakewood.FindRate(startDate, endDate);
            hotelType = HotelType.BRIDGEWOOD;
            Hotel bridgewood = new Hotel(hotelType);
            double rateBridgewood = bridgewood.FindRate(startDate, endDate);
            hotelType = HotelType.RIDGEWOOD;
            Hotel ridgewood = new Hotel(hotelType);
            double rateRidgewood = ridgewood.FindRate(startDate, endDate);
            if (rateLakewood < rateBridgewood && rateLakewood < rateRidgewood)
            {
                Console.WriteLine("Best hotel for your stay is " + HotelType.LAKEWOOD + " Rating: " + lakewood.RATING + " Cost of stay: " + rateLakewood);
            }
            if ((rateBridgewood < rateLakewood && rateBridgewood < rateRidgewood) || (rateLakewood == rateBridgewood && rateBridgewood < rateRidgewood))
            {
                Console.WriteLine("Best hotel for your stay is " + HotelType.BRIDGEWOOD + " Rating: " + bridgewood.RATING + " Cost of stay: " + rateBridgewood);
            }
            if ((rateRidgewood < rateLakewood && rateRidgewood < rateBridgewood) || (rateLakewood == rateRidgewood && rateRidgewood < rateBridgewood) || (rateBridgewood == rateRidgewood && rateRidgewood < rateLakewood))
            {
                Console.WriteLine("Best hotel for your stay is " + HotelType.RIDGEWOOD + " Rating: " + ridgewood.RATING + " Cost of stay: " + rateRidgewood);
            }
        }
    }
}
