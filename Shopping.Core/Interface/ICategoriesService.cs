﻿using Shopping.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.Core.Interface
{
    public interface ICategoriesService
    {
        List<Categories> GetAllCategoriesName();
    }
}
