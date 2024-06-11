using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace etiqatest.Application.Users.User.UpdateSkillset
{
    public class UpdateSkillsetCommand
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string SkillName { get; set; }
        public string SkillDescription { get; set; }
    }
}
