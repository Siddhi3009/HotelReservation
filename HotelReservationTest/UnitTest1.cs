using Microsoft.VisualStudio.TestTools.UnitTesting;
using HotelReservation;
namespace HotelReservationTest
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void GivenRegularCustomerTypeAndValidDates_ShouldReturn_CheapestHotelWithHighestRating()
        {
            CustomerServices services = new CustomerServices();
            HotelType hotel = services.FindCheapHotel("11/09/2020", "12/09/2020", CustomerType.NORMAL);
            Assert.AreEqual(hotel, HotelType.BRIDGEWOOD);
        }
        [TestMethod]
        public void GivenRewardCustomerTypeAndValidDates_ShouldReturn_CheapestHotelWithHighestRating()
        {
            CustomerServices services = new CustomerServices();
            HotelType hotel = services.FindCheapHotel("11/09/2020", "12/09/2020", CustomerType.REWARD);
            Assert.AreEqual(hotel, HotelType.RIDGEWOOD);
        }
        [TestMethod]
        public void GivenRegularCustomerTypeAndValidDates_ShouldReturn_HotelWithHighestRating()
        {
            CustomerServices services = new CustomerServices();
            HotelType hotel = services.FindBestRatedHotel("11/09/2020", "12/09/2020", CustomerType.NORMAL);
            Assert.AreEqual(hotel, HotelType.RIDGEWOOD);
        }
        [TestMethod]
        public void GivenRewardCustomerTypeAndValidDates_ShouldReturn_HotelWithHighestRating()
        {
            CustomerServices services = new CustomerServices();
            HotelType hotel = services.FindBestRatedHotel("11/09/2020", "12/09/2020", CustomerType.REWARD);
            Assert.AreEqual(hotel, HotelType.RIDGEWOOD);
        }
        [TestMethod]
        public void GivenRegularCustomerTypeAndValidDatesForHotelLakewood_ShouldReturn_HotelRates()
        {
            Hotel hotel = new Hotel(HotelType.LAKEWOOD, CustomerType.NORMAL);
            double expected = 200;
            double actual = hotel.FindRate("11/09/2020", "12/09/2020");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GivenRegularCustomerTypeAndValidDatesForHotelBridgewood_ShouldReturn_HotelRates()
        {
            Hotel hotel = new Hotel(HotelType.BRIDGEWOOD, CustomerType.NORMAL);
            double expected = 200;
            double actual = hotel.FindRate("11/09/2020", "12/09/2020");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GivenRegularCustomerTypeAndValidDatesForHotelRidgewood_ShouldReturn_HotelRates()
        {
            Hotel hotel = new Hotel(HotelType.RIDGEWOOD, CustomerType.NORMAL);
            double expected = 370;
            double actual = hotel.FindRate("11/09/2020", "12/09/2020");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GivenRewardCustomerTypeAndValidDatesForHotelLakewood_ShouldReturn_HotelRates()
        {
            Hotel hotel = new Hotel(HotelType.LAKEWOOD, CustomerType.REWARD);
            double expected = 160;
            double actual = hotel.FindRate("11/09/2020", "12/09/2020");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GivenRewardCustomerTypeAndValidDatesForHotelBridgewood_ShouldReturn_HotelRates()
        {
            Hotel hotel = new Hotel(HotelType.BRIDGEWOOD, CustomerType.REWARD);
            double expected = 160;
            double actual = hotel.FindRate("11/09/2020", "12/09/2020");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GivenRewardCustomerTypeAndValidDatesForHotelRidgewood_ShouldReturn_HotelRates()
        {
            Hotel hotel = new Hotel(HotelType.RIDGEWOOD, CustomerType.REWARD);
            double expected = 140;
            double actual = hotel.FindRate("11/09/2020", "12/09/2020");
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GivenNormalCustomerTypeAndInvalidDates_ShouldThrow_CustomException()
        {
            Hotel hotel = new Hotel(HotelType.RIDGEWOOD, CustomerType.REWARD);
            string expectedMessage = "Invalid date entered";
            string actualMessage = "";
            try
            {
                double actual = hotel.FindRate("0000000", "12/09/2020");
            }
            catch (HotelReservationException exception)
            {
                actualMessage = exception.Message;
            }
            Assert.AreEqual(expectedMessage, actualMessage);
        }
        [TestMethod]
        public void GivenNormalString_WhenValidated_ShouldReturn_NormalCustomerType()
        {
            CustomerServices service = new CustomerServices();
            CustomerType expected = service.Validate("Normal");
            CustomerType actual = CustomerType.NORMAL;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GivenRewardString_WhenValidated_ShouldReturn_RewardCustomerType()
        {
            CustomerServices service = new CustomerServices();
            CustomerType expected = service.Validate("Reward");
            CustomerType actual = CustomerType.REWARD;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GivenInvalidString_WhenValidated_ShouldReturn_CustomExcetion()
        {
            CustomerServices service = new CustomerServices();
            string actual = "";
            string message = "Invalid customer type";
            try
            {
                CustomerType expected = service.Validate("regular");
            }
            catch (HotelReservationException exception)
            {
                actual = exception.Message;
            }
            Assert.AreEqual(message, actual);
        }
    }
}
