using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;
using SimpleBookingSystem.API;
using SimpleBookingSystem.API.Infrastructure.Services;

namespace SimpleBookingSystem.UnitTest
{
    public static class TestFactories
    {
        public static ResourceService ResourceServiceTestFactory()
        {
            var context = SimpleBookingSystemContextMock.GetDBContext();
            var loggerMock = new Mock<ILogger<ResourceService>>();
            var mapperMock = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(System.Reflection.Assembly.GetEntryAssembly(), typeof(Startup).Assembly);
            });
            var mapper = mapperMock.CreateMapper();
            return new ResourceService(context, mapper, loggerMock.Object);
        }
        public static MailService MailServiceTestFactory()
        {
            var loggerMock = new Mock<ILogger<MailService>>();
            return new MailService(loggerMock.Object);
        }
        public static BookingService BookingServiceTestFactory()
        {
            var context = SimpleBookingSystemContextMock.GetDBContext();
            var loggerMock = new Mock<ILogger<BookingService>>();
            var mapperMock = new MapperConfiguration(cfg =>
            {
                cfg.AddMaps(System.Reflection.Assembly.GetEntryAssembly(), typeof(Startup).Assembly);
            });
            var mapper = mapperMock.CreateMapper();
            var configurationMock = new Mock<IConfiguration>();

            return new BookingService(context, MailServiceTestFactory(), mapper, loggerMock.Object, configurationMock.Object);
        }
    }
}