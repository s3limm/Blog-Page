using AutoMapper;
using Blog_Page.Service.Mappings.AutoMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog_Page.Service.Helpers
{
    public static class ProfileHelper
    {
        public static List<Profile> GetProfiles()
        {
            return new List<Profile>
            {
                new BlogProfile(),
                new CategoryProfile(),
                new UserProfile()
            };
        }
    }
}
