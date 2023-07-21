using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace entity.entities
{
    public class UserMotivation
    {
        public UserExt User { get; set; }
        public int UserExtId { get; set; }

        public Motivation Motivation { get; set; }
        public int MotivationId { get; set; }
    }
}
