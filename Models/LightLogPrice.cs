using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class LightLogPrice
    {
        public int Id { get; set; }
        public int LightLogId { get; set; }
        public Nullable<double> Price { get; set; }

        //public int ProductId { get; set; }
        //public DateTime DateSent { get; set; }
        //public int Hours { get; set; }
        //public int Minutes { get; set; }
        //public int Seconds { get; set; }
        //public Nullable<double> Price { get; set; }
    }
}
