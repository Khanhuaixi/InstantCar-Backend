using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceApi.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string BookingId { get; set; }
        public string BookingStartDate { get; set; }
        public string BookingEndDate { get; set; }
        public string BookingPaymentMethod { get; set; }
        public string CarId { get; set; }
        public string UserId { get; set; }

    }
}
