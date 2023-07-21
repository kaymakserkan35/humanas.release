using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.entities
{
    public class UserDistrict
    {
        public UserExt User { get; set; }
        public int UserExtId { get; set; }

        public District District { get; set; }
        public int DistrictId { get; set; }
    }
}
