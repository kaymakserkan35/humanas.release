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
            for (int i = 1; i < num; i++)
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
            int i = 1;
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
            for (int i = 1; i < num; i++)
            {

                var x = new UserExt()
                {
                    UserName = Faker.Name.First(),
                    SurName = Faker.Name.Last()

                };
                x.Email = x.SurName + "_" + x.UserName + "@";
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
            int i = 1;
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

        public static List<UserDistrict> seedUserDistrict(List<UserExt> users, List<District> districts,bool setId=true)
        {
            List<UserDistrict> userDistricts = new List<UserDistrict>();
            Random random = new Random();

            foreach (UserExt user in users)
            {

                for (int i = 1; i < 10; i++)
                {
                    int districtId = random.Next(districts.Count);
                 
                    UserDistrict userDistrict = new UserDistrict()
                    {
                        UserExtId = user.Id,
                        UserExt = user,
                        District = districts[districtId],
                        DistrictId= districtId
                    };
                    userDistricts.Add(userDistrict);
                    user.UserDistricts.Add(userDistrict);
                    if (setId) userDistrict.Id = districtId*user.Id;
                                     
                }

            }

            return userDistricts;
        }

        public static List<UserMotivation> seedUserMotivation(List<UserExt> users, List<Motivation> motivations,bool setId=true)
        {
            List<UserMotivation> userMotivations = new List<UserMotivation>();
            Random random = new Random();

            foreach (UserExt user in users)
            {
                for (int i = 1; i < 4; i++)
                {
                    int motivationId = random.Next(motivations.Count);
      
                    UserMotivation userMotivation = new UserMotivation()
                    {
                        UserExtId = user.Id,
                        UserExt = user,
                        Motivation = motivations[motivationId],
                        MotivationId= motivationId
                    };
                    if(setId) userMotivation.Id = motivationId*user.Id;
                    userMotivations.Add(userMotivation);
                    user.UserMotivations.Add(userMotivation);
                }
               
               
            }

            return userMotivations;
        }
        public static List<UserWorkingPreference> seedUserWorkingPreference(List<UserExt> users, List<WorkingPreference> preferences,bool setId=true)
        {
            List<UserWorkingPreference> userPreferences = new List<UserWorkingPreference>();
            Random random = new Random();

            foreach (UserExt user in users)
            {
                for (int i = 1; i < 3; i++)
                {
                    int preferenceId = random.Next(preferences.Count);
                  
                    UserWorkingPreference userPreference = new UserWorkingPreference()
                    {
                        UserExtId = user.Id,
                        UserExt = user,
                        WorkingPreference = preferences[preferenceId],
                        WorkingPreferenceId=preferenceId,
           
                    };
                    if (setId) userPreference.Id = preferenceId * user.Id;
                    userPreferences.Add(userPreference);
                    user.UserWorkingPreferences.Add(userPreference);
                }

            }

            return userPreferences;
        }


       
    }
}
