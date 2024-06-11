using etiqatest.Application.Users.User.GetUser;
using etiqatest.Domain.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace etiqatest.Application.Users.User.GetUsers
{
    public class GetUsersResponse
    {
        public List<GetUserResponse> Users { get; set; } = new List<GetUserResponse>();
    }
}
