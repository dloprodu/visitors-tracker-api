using System;
using System.Collections.Generic;
using System.Text;
using VisitorsTracker.Models;

namespace VisitorsTracker.BLL.Services
{
    public class PageResult<T>
    {
        public long total { get; set; }
        public List<T> result { get; set; }
    }
}
