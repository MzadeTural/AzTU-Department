using Microsoft.AspNetCore.Mvc.RazorPages;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kafedra.Application.DTOs
{
    public class PagenatedListDto<T> : List<T>
    {
        public PagenatedListDto(List<T> items, int count, int pageIndex, int pageSize, bool hasItems)
        {
           
            this.AddRange(items);
            PageIndex = pageIndex;
            TotalPage = (int)Math.Ceiling(count / (double)pageSize);
            HasItems = hasItems;
            PageSize = pageSize;
        }
        public bool HasItems { get; set; }
        public int TotalPage { get; set; }
        public int PageSize { get; set; }

        public int PageIndex { get; set; }
       

        public bool HasPrev
        {
            get => PageIndex > 1;
        }

        public bool HasNext
        {
            get => TotalPage > PageIndex;
        }

        public static PagenatedListDto<T> Save(IQueryable<T> query, int pageIndex, int pageSize)
        {
            if (pageIndex < 1)
            {
                pageIndex = 1;
            }

            var items = query.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList();
            var hasItems = items.Any();
            return new PagenatedListDto<T>(items, query.Count(), pageIndex, pageSize, hasItems);
        }
    }
}
