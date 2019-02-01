using Nzh.Frame.IRepository;
using Nzh.Frame.Model;
using Nzh.Frame.Repository.Base;
using Nzh.Frame.Repository.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Nzh.Frame.Repository
{
    public class DemoRepository : BaseRepository<Demo>, IDemoRepository
    {
        public DemoRepository(EFDbContext context)
            : base(context)
        { }

    }
}
