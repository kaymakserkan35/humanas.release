using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.entities
{
    public class District
    {
        public District()
        {
            UserDistricts = new HashSet<UserDistrict>();
        }



        public int Id { get; set; }
        public string Name { get; set; }
        public string Country { get; set; }


        public virtual ICollection<UserDistrict> UserDistricts { get; set; }
    }
}
