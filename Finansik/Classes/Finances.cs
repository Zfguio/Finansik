using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finansik.Classes
{
    public class Finances
    {
        public float income { get; set; }
        public float outgo { get; set; }
        public Finances()
        {
            income = 0;
            outgo = 0;
        }
    }
}
