using Prilozenie.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prilozenie.VM
{
    public class KrossVM
    {
        public Linear Linear { get; set; }
        public Place Place { get; set; }
        public CableType CableType { get; set; }
        public Equipment Equipment { get; set; }
        public Station Station { get; set; }
    }
}
