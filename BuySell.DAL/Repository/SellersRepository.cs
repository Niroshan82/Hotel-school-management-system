﻿using BuySell.DAL.Data;
using BuySell.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuySell.DAL.Repository
{
    public class SellersRepository : RepositoryBase<Seller>
    {
        public SellersRepository(DataContext context) : base(context)
        {
            if (context == null)
                throw new ArgumentNullException();
        }
    }
}
