using System.Collections.Generic;
using System.Linq;
using Vaishnavi_Dere_03_Assignement.Models;

namespace Vaishnavi_Dere_03_Assignement.Services
{
    public class MemberService
    {
        private List<Member> members = new List<Member>();

        public void AddMember(Member member)
        {
            members.Add(member);
        }

        public Member GetMemberById(string uid)
        {
            return members.FirstOrDefault(m => m.UId == uid);
        }

        public List<Member> GetAllMembers()
        {
            return members;
        }

        public void UpdateMember(Member updatedMember)
        {
            var member = members.FirstOrDefault(m => m.UId == updatedMember.UId);
            if (member != null)
            {
                member.Name = updatedMember.Name;
                member.DateOfBirth = updatedMember.DateOfBirth;
                member.Email = updatedMember.Email;
            }
        }
    }
}
