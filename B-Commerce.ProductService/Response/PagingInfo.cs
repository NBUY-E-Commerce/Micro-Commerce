using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.Response
{
    public class PagingInfo
    {
        public PagingInfo() { }
        public PagingInfo(int currentPage,int demand,int allcount)
        {
            //allcount  101  10    1 sayfada
            this.CurrentPage = currentPage;
            this.Demand = demand;

            int maxpage = allcount / demand;
            if(allcount%demand>0)
            {
                maxpage++;

            }

            this.LastPage = maxpage;
        }
        
        public int CurrentPage { get; set; }

        public int Demand { get; set; }

        public int LastPage { get; set; }
    }
}
