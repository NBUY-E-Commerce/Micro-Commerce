using B_Commerce.ProductService.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace B_Commerce.ProductService.Response
{
    public class CategoryModel
    {
        public int ID { get; set; }
        public bool HasSubCategory { get; set; }
        public string Name { get; set; }
        public List<CategoryModel> SubCategories { get; set; }

        //cat1-subcat1,subcat2
        //cat2-subcat2_1-->subsub_2_1_1

        //list<CategoryModel>    cat1  -----> subcat1,subcat1
        //                       cat2-------->subcat2_1---->subsub_2_1_1
        //                                     list(subsub_2_1_1)
        //                       cat2-->subcat2_1(list(subsub_2_1_1))
        public static List<CategoryModel> GetCategoryModelFromData(List<Category> categories)
        {
            List<CategoryModel> categoryModels = new List<CategoryModel>();

            foreach (var item in categories)
            {

                CategoryModel categoryModel = new CategoryModel
                {
                    ID = item.ID,
                    Name = item.CategoryName,
                    HasSubCategory = item.SubCategories.Count > 0 ? true : false

                };

                if (categoryModel.HasSubCategory)
                {
                    categoryModel.SubCategories = new List<CategoryModel>();
                    categoryModel.SubCategories.AddRange(GetCategoryModelFromData(item.SubCategories.ToList()));
                }
                categoryModels.Add(categoryModel);
            }

            return categoryModels;
        }


    }
}
