﻿using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education.Model
{
    public class ApiUser
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Secret { get; set; }
        public string AppId { get; set; }
    }
}
