﻿using SignalRAssignment.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalRAssignment.Interface
{
    public interface IOrderService
    {
        List<Orders> GetByCusId(int cusId);
    }
}