using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using entity.entities;

namespace data.access.Context
{
    public class Seed
    {
        enum Motivations
        {
            sağlık, eğitim, spor, ekonomi, mühendislik, iletişim, hukuk, tasarım
        }

        enum WorkingPreferences
        {
            tam_zamanlı, yarı_zamanlı, uzaktan, proje_bazlı
        }
        public static List<District> seedDistriact(int num, bool setId)
        {
            List<District> districts = new List<District>();
            for (int i = 0; i < num; i++)
            {

                var d = new District()
                {
                    Name = Faker.Address.City(),
                    Country = Faker.Address.Country()
                };
                if (setId) { d.Id = i; }
                districts.Add(d);
            }
            return districts;
        }
        public static List<Motivation> seedMotivation(bool setId)
        {
            List<Motivation> motivations = new List<Motivation>();
            int i = 0;
            foreach (string motivation in Enum.GetNames(typeof(Motivations)))
            {
                Motivation m = new Motivation()
                {
                    Name = motivation
                };
                if (setId) m.Id = i;
                i = i + 1;
                motivations.Add(m);
            }
            return motivations;

        }
        public static List<UserExt> seedUser(int num, bool setId)
        {
            List<UserExt> list = new List<UserExt>();
            for (int i = 0; i < num; i++)
            {

                var x = new UserExt()
                {
                    Name = Faker.Name.First(),
                    SurName = Faker.Name.Last()

                };
                x.Email = x.SurName + "_" + x.Name + "@";
                x.Email += i % 2 == 0 ? "hotmail" : "gmail";
                x.Email += ".com";

                if (setId) { x.Id = i; }
                list.Add(x);
            }
            return list;
        }
        public static List<WorkingPreference> seedPreference(bool setId)
        {
            List<WorkingPreference> list = new List<WorkingPreference>();
            int i = 0;
            foreach (string preference in Enum.GetNames(typeof(WorkingPreferences)))
            {
                WorkingPreference x = new WorkingPreference();
                x.Name = preference;

                if (setId) x.Id = i;
                i = i + 1;
                list.Add(x);
            }
            return list;
        }

        public static List<UserDistrict> seedUserDistrict(List<UserExt> users, List<District> districts)
        {
            List<UserDistrict> userDistricts = new List<UserDistrict>();
            Random random = new Random();

            foreach (UserExt user in users)
            {
                int districtId = random.Next(districts.Count);
                UserDistrict userDistrict = new UserDistrict()
                {
                    User = user,
                    District = districts[districtId]
                };
                userDistricts.Add(userDistrict);
            }

            return userDistricts;
        }

        public static List<UserMotivation> seedUserMotivation(List<UserExt> users, List<Motivation> motivations)
        {
            List<UserMotivation> userMotivations = new List<UserMotivation>();
            Random random = new Random();

            foreach (UserExt user in users)
            {
                int motivationId = random.Next(motivations.Count);
                UserMotivation userMotivation = new UserMotivation()
                {
                    User = user,
                    Motivation = motivations[motivationId]
                };
                userMotivations.Add(userMotivation);
            }

            return userMotivations;
        }
        public static List<UserWorkingPreference> seedUserWorkingPreference(List<UserExt> users, List<WorkingPreference> preferences)
        {
            List<UserWorkingPreference> userPreferences = new List<UserWorkingPreference>();
            Random random = new Random();

            foreach (UserExt user in users)
            {
                int preferenceId = random.Next(preferences.Count);
                UserWorkingPreference userPreference = new UserWorkingPreference()
                {
                    User = user,
                    WorkingPreference = preferences[preferenceId]
                };
                userPreferences.Add(userPreference);
            }

            return userPreferences;
        }


        public static void seedAll()
        {
            List<UserExt> users = seedUser(100, true);
            List<District> districts = seedDistriact(100, true);
            List<Motivation> motivations = seedMotivation(true);
            List<WorkingPreference> preferences = seedPreference(true);

            List<UserDistrict> userDistricts = seedUserDistrict(users, districts);
            List<UserMotivation> userMotivations = seedUserMotivation(users, motivations);
            List<UserWorkingPreference> userPreferences = seedUserWorkingPreference(users, preferences);
        }
    }
}
