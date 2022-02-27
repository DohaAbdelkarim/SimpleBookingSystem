using Microsoft.EntityFrameworkCore;
using SimpleBookingSystem.API.Infrastructure;
using SimpleBookingSystem.API.Infrastructure.Domain;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;

namespace SimpleBookingSystem.UnitTest
{
    public static class SimpleBookingSystemContextMock
    {
        public static SimpleBookingSystemContext GetDBContext()
        {
            var options = new DbContextOptionsBuilder<SimpleBookingSystemContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .ConfigureWarnings(x => x.Ignore(InMemoryEventId.TransactionIgnoredWarning))
            .Options;

            var simpleBookingSystemContext = new SimpleBookingSystemContext(options);
            simpleBookingSystemContext.Database.EnsureCreated();

            SeedResourceRecords(simpleBookingSystemContext);
            SeedBookingRecords(simpleBookingSystemContext);
            simpleBookingSystemContext.SaveChanges();

            return simpleBookingSystemContext;
        }
        private static void SeedResourceRecords(SimpleBookingSystemContext simpleBookingSystemContext)
        {
            simpleBookingSystemContext.Resource.Add(new Resource { Id = 1, Name = "Resource1", Quantity = 50 });
            simpleBookingSystemContext.Resource.Add(new Resource { Id = 2, Name = "Resource2", Quantity = 100 });
            simpleBookingSystemContext.Resource.Add(new Resource { Id = 3, Name = "Resource3", Quantity = 35 });
            simpleBookingSystemContext.Resource.Add(new Resource { Id = 4, Name = "Resource4", Quantity = 500 });
        }
        private static void SeedBookingRecords(SimpleBookingSystemContext simpleBookingSystemContext)
        {
            simpleBookingSystemContext.Booking.Add(new API.Infrastructure.Domain.Booking { Id = 1, DateFrom = "2022-02-21", DateTo = "2022-02-23", BookedQuantity = 50, ResourceId = 1 });
            simpleBookingSystemContext.Booking.Add(new API.Infrastructure.Domain.Booking { Id = 2, DateFrom = "2022-02-22", DateTo = "2022-02-24", BookedQuantity = 50, ResourceId = 2 });
            simpleBookingSystemContext.Booking.Add(new API.Infrastructure.Domain.Booking { Id = 3, DateFrom = "2022-02-24", DateTo = "2022-02-25", BookedQuantity = 50, ResourceId = 2 });
            simpleBookingSystemContext.Booking.Add(new API.Infrastructure.Domain.Booking { Id = 4, DateFrom = "2022-02-25", DateTo = "2022-02-28", BookedQuantity = 20, ResourceId = 3 });
            simpleBookingSystemContext.Booking.Add(new API.Infrastructure.Domain.Booking { Id = 5, DateFrom = "2022-02-29", DateTo = "2022-02-30", BookedQuantity = 10, ResourceId = 3 });
        }
    }
}