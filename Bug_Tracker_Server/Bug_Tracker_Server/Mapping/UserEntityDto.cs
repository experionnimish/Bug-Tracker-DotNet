using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BugTrackerDTOs;
using Bug_Tracker_Server.Data;

namespace Bug_Tracker_Server.Mapping
{
    public class UserEntityDto
    {
        public static UserDto ToDto(user userobj)
        {
            UserDto userDto = new UserDto();
            if (userobj != null)
            {
                userDto.user_id = userobj.user_id;
                userDto.user_employee_id = userobj.user_employee_id;
                userDto.user_password = userobj.user_password;
                userDto.user_class = userobj.user_class;
                userDto.user_name = userobj.user_name;
                userDto.user_email = userobj.user_email;
                userDto.user_flag = userobj.user_flag;
            }
            return userDto;
        }
        public static user ToEntity(UserDto userDto)
        {
            user userobj = new user();
            if (userDto != null)
            {
                userobj.user_id = userDto.user_id;
                userobj.user_employee_id = userDto.user_employee_id;
                userobj.user_password = userDto.user_password;
                userobj.user_class = userDto.user_class;
                userobj.user_name = userDto.user_name;
                userobj.user_email = userDto.user_email;
                userobj.user_flag = userDto.user_flag;
            }
            return userobj;
        }
    }
}