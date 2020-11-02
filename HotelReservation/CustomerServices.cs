using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    class CustomerServices
    {
        /// <summary>
        /// Finds Cheapest Hotel
        /// </summary>
        /// <param name="startDate"></param>
        /// <param name="endDate"></param>
        /// <returns>Cheapest Hotel</returns>
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
                hotelType = HotelType.LAKEWOOD;
                Console.WriteLine("Best hotel for your stay is " + hotelType + " Cost of stay: " + rateLakewood);
            }
            if (rateBridgewood < rateLakewood && rateBridgewood < rateRidgewood)
            {
                hotelType = HotelType.BRIDGEWOOD;
                Console.WriteLine("Best hotel for your stay is " + hotelType + " Cost of stay: " + rateBridgewood);
            }
            if (rateRidgewood < rateLakewood && rateRidgewood < rateBridgewood)
            {
                hotelType = HotelType.RIDGEWOOD;
                Console.WriteLine("Best hotel for your stay is " + hotelType + " Cost of stay: " + rateRidgewood);
            }
        }
    }
}
