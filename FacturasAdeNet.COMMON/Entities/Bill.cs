using System;
using System.Collections.Generic;
using System.Text;

namespace FacturasAdeNet.COMMON.Entities
{
    public class Bill:Base
    {
        public string Id { get; set; }
        public DateTime BillDate { get; set; }
        public Client BillClient { get; set; }
        public Employee BillEmployee { get; set; }
    }
}
