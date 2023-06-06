using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceApi.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string CarId { get; set; }
        public string CarModelId { get; set; }
        public double CarRentalRate { get; set; }
        public string CarAddress { get; set; }
    }
}
