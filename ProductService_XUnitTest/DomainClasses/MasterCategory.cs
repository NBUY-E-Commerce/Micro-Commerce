using B_Commerce.Common.DomainClasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace B_Commerce.ProductService.DomainClasses
{
    public class MasterCategory:BaseEntity
    {   //Elektronik
        public string Category_Name { get; set; }
        public string Description { get; set; }
        public bool isActive { get; set; } = true;

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }



    /*
     *
 CREATE TABLE [dbo].[M_Product_Category](
[Id] [bigint] IDENTITY(1,1) NOT NULL,
[Product_Type] [nvarchar](50) NOT NULL,
[Description] [nvarchar](100) NULL,
[Updated_By] [nvarchar](50) NULL,
[IsActive] [bit] NULL,
[Last_Updated_Date] [datetime] NULL)

     */

    /*
     *  public virtual int ID { get; set; }
        public bool isDeleted { get; set; } = false;
        public DateTime insertDateTime { get; set; } = DateTime.Now;
        public DateTime? deleteDateTime { get; set; } 
        public int? insertUserId { get; set; }
        public int? deleteUserId { get; set; }
     */


}
