using BugTrackerDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bug_Tracker_Server.Data_Services
{
    interface IGetTeamMembersService
    {
        List<MemberDto> GetTeamMembers(int ProjectId, int UserClass, UserDto User);
        List<MemberDto> GetTeamMembersAdd(int ProjectId, int UserClass, UserDto User);
        bool AddTeamMembers(AddTeamDto Member);
        bool RemoveTeamMembers(AddTeamDto Member);
    }
}
