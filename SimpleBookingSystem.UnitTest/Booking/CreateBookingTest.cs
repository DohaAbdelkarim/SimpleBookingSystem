using SimpleBookingSystem.API.Infrastructure.Extensions;
using SimpleBookingSystem.API.Models;
using System.Threading.Tasks;
using Xunit;

namespace SimpleBookingSystem.UnitTest.Booking
{
    public class CreateBookingTest
    {
        [Theory]
        [InlineData("2022-02-22", "2022-02-23", 4, 700)]
        public async Task BookResource_InvalidModel_Quantity(string dateFrom, string dateTo, int resourceId, int quantity)
        {
            //Arrange
            var createBookingRequestModel = new CreateBookingRequestModel()
            {
                DateFrom = dateFrom.ToDateTimeOffset(),
                DateTo = dateTo.ToDateTimeOffset(),
                ResourceId = resourceId,
                BookedQuantity = quantity
            };

            var bookingServiceTestFactory = TestFactories.BookingServiceTestFactory();

            //Act
            var createBookingResponseModel = await bookingServiceTestFactory.BookResourceAsync(createBookingRequestModel);

            //Assert
            Assert.NotNull(createBookingResponseModel);
            Assert.Null(createBookingResponseModel.BookingId);
        }

        [Theory]
        [InlineData("2022-02-22", "2022-02-23", 1, 10)]
        public async Task BookResource_InvalidModel_ConflictTimeRange(string dateFrom, string dateTo, int resourceId, int quantity)
        {
            //Arrange
            var createBookingRequestModel = new CreateBookingRequestModel()
            {
                DateFrom = dateFrom.ToDateTimeOffset(),
                DateTo = dateTo.ToDateTimeOffset(),
                ResourceId = resourceId,
                BookedQuantity = quantity
            };

            var bookingServiceTestFactory = TestFactories.BookingServiceTestFactory();

            //Act
            var createBookingResponseModel = await bookingServiceTestFactory.BookResourceAsync(createBookingRequestModel);

            //Assert
            Assert.NotNull(createBookingResponseModel);
            Assert.Null(createBookingResponseModel.BookingId);
        }

        [Theory]
        [InlineData("2022-02-28", "2022-02-29", 3, 5)]
        public async Task BookResource_ValidModel(string dateFrom, string dateTo, int resourceId, int quantity)
        {
            //Arrange
            var createBookingRequestModel = new CreateBookingRequestModel()
            {
                DateFrom = dateFrom.ToDateTimeOffset(),
                DateTo = dateTo.ToDateTimeOffset(),
                ResourceId = resourceId,
                BookedQuantity = quantity
            };

            var bookingServiceTestFactory = TestFactories.BookingServiceTestFactory();

            //Act
            var createBookingResponseModel = await bookingServiceTestFactory.BookResourceAsync(createBookingRequestModel);

            //Assert
            Assert.NotNull(createBookingResponseModel);
            Assert.NotNull(createBookingResponseModel.BookingId);
        }
    }
}
