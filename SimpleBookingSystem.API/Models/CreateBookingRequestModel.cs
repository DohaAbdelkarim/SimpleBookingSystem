using System;

namespace SimpleBookingSystem.API.Models
{
    public class CreateBookingRequestModel
    {
        public DateTimeOffset DateFrom { get; set; }
        public DateTimeOffset DateTo { get; set; }
        public long BookedQuantity { get; set; }
        public long ResourceId { get; set; }
    }
}