using Microsoft.EntityFrameworkCore;
using Milestone1.Data.Interfaces;
using Milestone1.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Milestone1.Data.Repository
{
    public class MerchRepository : IAllMerches
    {
        private readonly AppDBContent appDBContent;

        public MerchRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }


        public IEnumerable<Merch> Merches => appDBContent.Merch.Include(c=>c.Category);

        public IEnumerable<Merch> getFavMerches => appDBContent.Merch.Where(p => p.isFav).Include(c => c.Category);

        public Merch getObjectMerch(int merchID) => appDBContent.Merch.FirstOrDefault(p => p.id == merchID);
    }
}
