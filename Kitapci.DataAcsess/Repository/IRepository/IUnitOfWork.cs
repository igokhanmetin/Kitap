using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kitapci.DataAcsess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IKategoriRepository Kategori { get; }
        IKitapRepository Kitap { get; }
        void Save();
    }
}
