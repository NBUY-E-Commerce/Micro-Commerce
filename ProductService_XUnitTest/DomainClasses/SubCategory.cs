using B_Commerce.Common.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.DomainClasses
{
    public class SubCategory:BaseEntity
    {
        //Tv
        //Foreign key---->Master Category
        public int Master_Category_ID { get; set; } 
        public string Category_Name { get; set; }
        public string Description { get; set; }
        public bool isActive { get; set; } = true;
        
        public virtual MasterCategory MasterCategory { get; set;}
    }

    /*
     * [Id] [bigint] IDENTITY(1,1) NOT NULL,
  [FK_Product_Id] [bigint] NOT NULL,
  [Product_Sub_Category] [nvarchar](100) NULL,
  [Description] [nvarchar](200) NULL,
  [Updated_By] [nvarchar](50) NULL,
  [Last_Updated_Date] [datetime] NULL,
  [IsActive] [bit] NULL)
     */

    /*
     *    public virtual int ID { get; set; }
        public bool isDeleted { get; set; } = false;
        public DateTime insertDateTime { get; set; } = DateTime.Now;
        public DateTime? deleteDateTime { get; set; } 
        public int? insertUserId { get; set; }
        public int? deleteUserId { get; set; }
     */
}
