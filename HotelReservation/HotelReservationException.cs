using System;
using System.Collections.Generic;
using System.Text;

namespace HotelReservation
{
    class HotelReservationException : Exception
    {
        /// <summary>
        /// Exception types
        /// </summary>
        public enum ExceptionType
        {
            INVALID_DATE,
            INVALID_CUSTOMER_TYPE,
            INVALID_HOTEL_TYPE,
            INVALID_CHOICE
        }
        ExceptionType type;
        /// <summary>
        /// Constructor of custom exception inheriting from Exception class
        /// </summary>
        /// <param name="type"></param>
        /// <param name="message"></param>
        public HotelReservationException(ExceptionType type, string message) : base(message)
        {
            this.type = type;
        }
    }
}
