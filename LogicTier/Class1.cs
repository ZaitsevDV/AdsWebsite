﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicTier
{
    public class Class1 : ITestProvider
    {
        public string GetMessage()
        {
            return "Provider Message";
        }
    }
}
