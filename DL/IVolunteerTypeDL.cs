﻿using Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DL
{
    public interface IVolunteerTypeDL
    {
        Task<List<VolunteerType>> getVolunteerTypes();
    }
}