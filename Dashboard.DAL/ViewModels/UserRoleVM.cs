using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dashboard.DAL.ViewModels
{
    public class UserRoleVM
    {
        public string UserId { get; set; }
        public List<string> Roles { get; set; }
    }
}
