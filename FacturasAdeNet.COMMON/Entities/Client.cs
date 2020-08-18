using System;
using System.Collections.Generic;
using System.Text;

namespace FacturasAdeNet.COMMON.Entities
{
    public class Client:Base
    {
        public string Id { get; set; }

        public string Name { get; set; }
        public string LastName { get; set; }
        public string DNI { get; set; }
        public char NetSpeed { get; set; }
        public int Tariff { get; set; }
        public string MACAddress { get; set; }
        public string IPAddress { get; set; }
        public string Phone { get; set; }
        public byte Status { get; set; }

    }
}
