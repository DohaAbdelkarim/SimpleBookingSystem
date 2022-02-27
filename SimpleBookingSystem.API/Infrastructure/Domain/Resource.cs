using System;
using System.Collections.Generic;

#nullable disable

namespace SimpleBookingSystem.API.Infrastructure.Domain
{
    public partial class Resource
    {
        public Resource()
        {
            Booking = new HashSet<Booking>();
        }

        public long Id { get; set; }
        public string Name { get; set; }
        public long Quantity { get; set; }

        public virtual ICollection<Booking> Booking { get; set; }
    }
}
