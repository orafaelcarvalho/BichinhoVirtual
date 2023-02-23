using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BichinhoVirtual.Model
{
    public class Mascotes
    {
        public int count { get; set; }
        public object previous { get; set; }
        public List<Mascote> results { get; set; }
    }
}
