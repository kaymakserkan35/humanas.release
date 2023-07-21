using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.entities
{
    public class Motivation
    {
        public Motivation()
        {
            UserMotivations = new HashSet<UserMotivation>();
        }
        public int Id { get; set; }
        public string Name { get; set; }

        public virtual ICollection<UserMotivation> UserMotivations { get; set; }
    }
}
