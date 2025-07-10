using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public class AmenitiesResponse
    {
        public AmenityType Type { get; set; }
        public object Amenity { get; set; }
    }

    public enum AmenityType
    {
        Gym = 0,
        SwimmingPoolIndoor,
        SwimmingPoolOutdoor,
        CommonAmenitiesMen,
        CommonAmenitiesWomen
    }
}
