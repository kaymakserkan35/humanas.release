using entity.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace data.access.Context
{
    internal class Context_Concrete_fason : IContext
    {
        /// <summary>
        /// Her bir Repository nesnesi aynı cached listelerine erişecektir.
        /// çünkü bu listeler private static olarak tanımlanmıştır
        /// ve bu tanımlama, nesnelerin paylaşılan bir bellek havuzuna sahip olmalarını sağlar. 
        /// </summary>
        private static List<UserExt> cachedUsers;
        private static List<District> cachedDistricts;
        private static List<Motivation> cachedMotivations;
        private static List<WorkingPreference> cachedPreferences;
        private static List<UserDistrict> cachedUserDistricts;
        private static List<UserMotivation> cachedUserMotivations;
        private static List<UserWorkingPreference> cachedUserPreferences;

        public List<UserExt> _Users => GetUsers();

        public List<District> _Districts => GetDistricts();

        public List<Motivation> _Motivations => GetMotivations();

        public List<WorkingPreference> _WorkingPreferences => GetPreferences();

        internal List<UserExt> GetUsers(int num = 100, bool setId = true)
        {
            if (cachedUsers == null)
                cachedUsers = Seed.seedUser(num, setId);

            return cachedUsers;
        }
        internal List<District> GetDistricts(int num = 81, bool setId = true)
        {
            if (cachedDistricts == null)
                cachedDistricts = Seed.seedDistriact(num = 100, setId);
            return cachedDistricts;
        }
        // Method to seed and get motivations
        internal List<Motivation> GetMotivations(bool setId = true)
        {
            if (cachedMotivations == null)
                cachedMotivations = Seed.seedMotivation(setId);
            return cachedMotivations;
        }
        internal List<WorkingPreference> GetPreferences(bool setId = true)
        {
            if (cachedPreferences == null) cachedPreferences = Seed.seedPreference(setId);

            return cachedPreferences;
        }
        internal List<UserDistrict> GetUserDistricts(List<UserExt> users, List<District> districts)
        {
            if (cachedUserDistricts == null) cachedUserDistricts = Seed.seedUserDistrict(users, districts);

            return cachedUserDistricts;
        }

        // Method to seed and get user motivations
        internal List<UserMotivation> GetUserMotivations(List<UserExt> users, List<Motivation> motivations)
        {
            if (cachedUserMotivations == null)
                cachedUserMotivations = Seed.seedUserMotivation(users, motivations);
            return cachedUserMotivations;
        }
        internal List<UserWorkingPreference> GetUserPreferences(List<UserExt> users, List<WorkingPreference> preferences)
        {
            if (cachedUserPreferences == null)
                cachedUserPreferences = Seed.seedUserWorkingPreference(users, preferences);
            return cachedUserPreferences;
        }
    }
}
