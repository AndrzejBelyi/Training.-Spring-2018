﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace URLsToXML.Interfaces
{
    public interface IUrlValidator
    {
        bool IsValid(string url);
    }
}
