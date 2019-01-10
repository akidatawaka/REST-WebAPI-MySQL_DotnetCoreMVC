using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace User_Api_Using_SqlDataPacket.Models
{
    public class UserItem
    {
        private UserContext context;

        public int id { get; set; }
        public string name { get; set; }
        public string adress { get; set; }
    }
}
