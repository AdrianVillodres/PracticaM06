using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cat.itb.store_VillodresAdrian.empDAO
{
    public class Employee
    {
        public virtual int _id { get; set; }
        public virtual string surname { get; set; }
        public virtual string job { get; set; }
        public virtual int managerid { get; set; }
        public virtual DateTime startdate { get; set; }
        public virtual double salary { get; set; }
        public virtual double comission { get; set; }
        public virtual int depid { get; set; }
    }
}
