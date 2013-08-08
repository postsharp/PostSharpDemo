using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArchitectureUnitTest
{
    [Singleton]
    class LoadBalancer1
    {
        private static readonly LoadBalancer1 instance;

        private LoadBalancer1()
        {
            
        }

        public static LoadBalancer1 GetInstance()
        {
            return null;
        }
    }

    
}
