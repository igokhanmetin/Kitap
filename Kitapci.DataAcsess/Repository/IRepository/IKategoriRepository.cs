﻿using Kitapci.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitapci.DataAcsess.Repository.IRepository
{
    public interface IKategoriRepository :IRepository<Kategori>
    {
        void Update(Kategori obj);
    }
}
