﻿using System;

namespace HotelReservation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Hotel Reservation System");
            Console.WriteLine("Choose your customer type \n1. NORMAL \n2. REWARD");
            int type = Convert.ToInt32(Console.ReadLine());
            CustomerType customerType = (CustomerType)type;
            Console.WriteLine("Enter start date of your stay in dd/mm/yyyy format");
            string startDate = Console.ReadLine();
            Console.WriteLine("Enter end date of your stay in dd/mm/yyyy format");
            string endDate = Console.ReadLine();
            CustomerServices customerService = new CustomerServices();
            Console.WriteLine("Select your criteria of choice \n1. According to rates \n2. According to ratings");
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    customerService.FindCheapHotel(startDate, endDate, customerType);
                    break;
                case 2:
                    customerService.FindBestRatedHotel(startDate, endDate, customerType);
                    break;
                default:
                    throw new HotelReservationException(HotelReservationException.ExceptionType.INVALID_CHOICE, "Invalid choice");
            }
        }
    }
}
