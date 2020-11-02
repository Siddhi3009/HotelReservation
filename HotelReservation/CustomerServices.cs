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
                Console.WriteLine("Best hotel for your stay is " + HotelType.LAKEWOOD + " Cost of stay: " + rateLakewood);
            }
            if (rateLakewood == rateBridgewood && rateLakewood < rateRidgewood)
            {
                Console.WriteLine("Best hotel for your stay is " + HotelType.LAKEWOOD + ", " + HotelType.BRIDGEWOOD + " Cost of stay: " + rateLakewood);
            }
            if (rateLakewood == rateRidgewood && rateLakewood < rateBridgewood)
            {
                Console.WriteLine("Best hotel for your stay is " + HotelType.LAKEWOOD + ", " + HotelType.RIDGEWOOD + " Cost of stay: " + rateLakewood);
            }
            if (rateBridgewood < rateLakewood && rateBridgewood < rateRidgewood)
            {
                Console.WriteLine("Best hotel for your stay is " + HotelType.BRIDGEWOOD + " Cost of stay: " + rateBridgewood);
            }
            if (rateBridgewood == rateRidgewood && rateBridgewood > rateLakewood)
            {
                Console.WriteLine("Best hotel for your stay is " + HotelType.BRIDGEWOOD + ", " + HotelType.RIDGEWOOD + " Cost of stay: " + rateLakewood);
            }
            if (rateRidgewood < rateLakewood && rateRidgewood < rateBridgewood)
            {
                Console.WriteLine("Best hotel for your stay is " + HotelType.RIDGEWOOD + " Cost of stay: " + rateRidgewood);
            }
        }
    }
}
