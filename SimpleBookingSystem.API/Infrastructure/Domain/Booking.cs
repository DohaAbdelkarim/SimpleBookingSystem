using System;
using System.Collections.Generic;

#nullable disable

namespace SimpleBookingSystem.API.Infrastructure.Domain
{
    public partial class Booking
    {
        public long Id { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public long BookedQuantity { get; set; }
        public long ResourceId { get; set; }

        public virtual Resource Resource { get; set; }
    }
}
