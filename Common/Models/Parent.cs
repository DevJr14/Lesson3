using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Models
{
    public class Parent
    {
        public int ParentId { get; set; }
        public string Initials { get; set; }= string.Empty;
        public string Surname { get; set; }= string.Empty;
        public ICollection<Student> Students { get; set; }
    }
}
