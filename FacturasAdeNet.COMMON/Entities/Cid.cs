using System;
using System.Collections.Generic;
using System.Text;

namespace FacturasAdeNet.COMMON.Entities
{
    public class Cid
    {
        public string NewCid()
        {
            int[] id = new int[6];
            var seed = Environment.TickCount;
            var random = new Random(seed);

            for(byte i = 0; i < id.Length; i++)
            {
                id[i] = random.Next(0, 10);
            }
            
            

            return string.Join("", id);
        }
    }
}
