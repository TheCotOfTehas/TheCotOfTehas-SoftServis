﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoftServis
{
    public interface ICompanyRepositore
    {
        public Company[] GetAllCompanies(string title);
    }
}
