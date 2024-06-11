using etiqatest.Domain.Common;
using System.ComponentModel.DataAnnotations.Schema;

namespace etiqatest.Domain.Users
{
    public class Skillset : AuditableEntity
    {
        public int Id { get; set; }
        [ForeignKey("User")]
        public int UserId { get; set; }
        public string SkillName { get; set; }

        public string SkillDescription { get; set; }

        public virtual User User { get; set; }

    }
}
