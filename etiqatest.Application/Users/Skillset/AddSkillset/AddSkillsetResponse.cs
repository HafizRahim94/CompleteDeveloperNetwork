using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace etiqatest.Application.Users.User.AddSkillset
{
    public class AddSkillsetResponse
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SkillName { get; set; }
        public string SkillDescription { get; set; }
    }

}
