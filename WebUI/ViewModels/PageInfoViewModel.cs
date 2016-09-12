using System;
using System.Collections.Generic;

namespace WebUI.ViewModels
{
    public class PageInfoViewModel
    {
        public PageInfoViewModel(int pageNumber, int pageSize, int totalItems, string searchItem)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            TotalItems = totalItems;
            SearchItem = searchItem;
        }

        public string SearchItem { get; set; }
        public int PageNumber { get; set; } 
        public int PageSize { get; set; } 
        public int TotalItems { get; set; }

        public int TotalPages
        {
            get { return (int) Math.Ceiling((decimal) TotalItems/PageSize); }
        }
    }
}