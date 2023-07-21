using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.entities
{
    public class WorkingPreference
    {

        public WorkingPreference()
        {
            UserWorkingPreference = new HashSet<UserWorkingPreference>();
        }
        public int Id { get; set; }
        public string Name { get; set; }


        internal virtual ICollection<UserWorkingPreference> UserWorkingPreference { get; set; }
    }
}
