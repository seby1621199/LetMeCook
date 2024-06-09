﻿using BusinessLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public interface IFoodService
    {
        Task<List<Dish>> GetFood(string ingredient);
    }
}
