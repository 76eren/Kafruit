using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
namespace KaFruit
{
    class Saving
    {
        public static List<Data> objects = new List<Data>();

        public static int count = 1;

        public static void save(Data data, int count)
        {
            objects.Add(data);

        }
        
    }
}
