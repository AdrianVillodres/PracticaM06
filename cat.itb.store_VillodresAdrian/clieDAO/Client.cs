using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using cat.itb.store_VillodresAdrian.empDAO;

namespace cat.itb.store_VillodresAdrian.clieDAO
{
    public class Client
    {
        public virtual int _id { get; set; }
        public virtual string name { get; set; }
        public virtual string address { get; set; }
        public virtual string city { get; set; }
        public virtual string st { get; set; }
        public virtual string zipcode { get; set; }
        public virtual int? area { get; set; }
        public virtual string phone { get; set; }
        public virtual int? empid { get; set; }
        public virtual decimal? credit { get; set; }
        public virtual string comments { get; set; }
        public virtual Employee employee { get; set; }
    }
}
