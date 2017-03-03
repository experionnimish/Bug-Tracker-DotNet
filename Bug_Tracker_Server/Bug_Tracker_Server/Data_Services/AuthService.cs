using BugTrackerDTOs;
using Bug_Tracker_Server.Data_Services;
using Bug_Tracker_Server.Mapping;
using System.Collections.Generic;
using Bug_Tracker_Server.Data;
using System.Linq;

namespace Bug_Tracker_Server.Data_Services
{
    //IAuthService IAuthService;
    public class AuthService : IAuthService
    {
        bug_trackerEntities entites = new bug_trackerEntities();
        public UserDto Login(user userObj)
        {
            var query = entites.users.Where(x => x.user_employee_id.Equals(userObj.user_employee_id) && x.user_password.Equals(userObj.user_password)).FirstOrDefault();
            if (query != null)
            {
                var userLoggedIn = UserEntityDto.ToDto(query);
                return userLoggedIn;
            }
            else
                return null;
        }
    }
}