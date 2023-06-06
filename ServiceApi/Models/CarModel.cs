using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceApi.Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public string CarModelId { get; set; }
        public string CarBrandName { get; set; }
        public string CarModelName { get; set; }
        public string CarVehicleType { get; set; }
        public string CarPetrolType { get; set; }
        public string CarTransmissionType { get; set; }
        public string CarImageLink { get; set; }

    }
}
