using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace etiqatest.Application.Users.User.GetUser
{
    public class GetUserQuery : IRequest<GetUserResponse>
    {
        public int Id { get; set; }
        public GetUserQuery(int userId)
        {
            Id = userId;
        }
    }
}
