using Kitapci.DataAcsess.Data;
using Kitapci.DataAcsess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitapci.DataAcsess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _context;
        public IKategoriRepository Kategori { get; private set; }
        public IKitapRepository Kitap { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Kategori=new KategoriRepository(_context);
            Kitap = new KitapRepository(_context);
        }
        

        public void Save()
        {
            _context.SaveChanges();
        }
    }
    
}
