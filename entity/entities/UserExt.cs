

using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.entities
{
    public class UserExt : IdentityUser<int>
    {

        public UserExt()
        {
            UserMotivations = new HashSet<UserMotivation>();
            UserWorkingPreferences = new HashSet<UserWorkingPreference>();
            UserDistricts = new HashSet<UserDistrict>();

        }


        public string SurName { get; set; }
        public string? Title { get; set; }






        public string? RefrestToken { get; set; }
        public string? JwtToken { get; set; }
        public DateTime? JwtTokenExpTime { get; set; }
        public DateTime? RefresTokenExpTime { get; set; }

        public virtual ICollection<UserMotivation> UserMotivations { get; set; }
        public virtual ICollection<UserWorkingPreference> UserWorkingPreferences { get; set; }
        public virtual ICollection<UserDistrict> UserDistricts { get; set; }


    }
}
