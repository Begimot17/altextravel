using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AltexTravel.API.Models
{
    public partial class SortingDescriptor
    {
        public Direction Direction { get; set; }
        public string Property { get; set; }
    }
}
