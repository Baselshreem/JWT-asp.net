using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication11.Model;
namespace WebApplication11.Iserv
{
    public interface  iuserserv
    {

        userinfo Authenticate(string username, string password);
    }
}
