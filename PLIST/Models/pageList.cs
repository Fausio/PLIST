using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PLIST.Models
{
    public class pageList<T>:  List<T>
    {
        public int PageIndex { get; private set; }
        public int TotalPages { get; set; }


        public pageList(List<T> items, int count, int pageIndex, int pageSize)
        {
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            this.AddRange(items);
        }

        public bool PreviousPage { get { return (PageIndex > 1); }  }

        public bool NextPage { get { return (PageIndex < TotalPages); } }

        public static async Task<pageList<T>> CreateAsync(IQueryable<T> source, int pageIndex, int pageSize)
        {
            var count =   source.Count();
            var items =   source.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();

            return new pageList<T>(items, count, pageIndex, pageSize);
        }
    }
}
