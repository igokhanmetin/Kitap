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
    public class KitapRepository : Repository<Kitap>, IKitapRepository
    {
        private ApplicationDbContext _context;
        public KitapRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }
        
        public void Update(Kitap obj)
        {
           var objFromDb = _context.Kitaplar.FirstOrDefault(u => u.Id == obj.Id);
            if (objFromDb != null)
            {
                objFromDb.Baslik=obj.Baslik;
                objFromDb.ISBN=obj.ISBN;
                objFromDb.Fiyat=obj.Fiyat;
                objFromDb.Fiyat50 = obj.Fiyat50;
                objFromDb.Fiyat100=obj.Fiyat100;
                objFromDb.ListeFiyati=obj.ListeFiyati;
                objFromDb.Aciklama=obj.Aciklama;
                objFromDb.Yazar=obj.Yazar;
                objFromDb.KategoriId=obj.KategoriId;
                if(obj.ImageUrl!=null)
                {
                    objFromDb.ImageUrl=obj.ImageUrl;
                }
            }
        }
    }
}
