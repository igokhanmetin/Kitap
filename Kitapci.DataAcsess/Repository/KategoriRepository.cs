using Kitapci.DataAcsess.Data;
using Kitapci.DataAcsess.Repository.IRepository;
using Kitapci.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Kitapci.DataAcsess.Repository
{
    public class KategoriRepository : Repository<Kategori>, IKategoriRepository
    {
        private ApplicationDbContext _context;
        public KategoriRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        
        public void Update(Kategori obj)
        {
           _context.Kategoriler.Update(obj);
        }
    }
}
