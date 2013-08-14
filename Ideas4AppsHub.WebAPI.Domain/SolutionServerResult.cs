﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ideas4AppsHub.WebAPI.Domain
{
    public class SolutionServerResult<T>
    {
        public bool IsOk { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
