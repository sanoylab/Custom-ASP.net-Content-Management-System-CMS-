using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessSearch;

namespace BusinessEntitySearch
{
   public class SparepartCategory
    {
       private AddisTowerDataContext context;
       public List<DataAccessSearch.SparepartCategory> PopulateAllSparepartCategoy()
       {
           context = new AddisTowerDataContext();
           var list = from p in context.SparepartCategories
                      select p;
           return list.ToList();
       }
       public void InsertSparepartCategory(string Name, string Remark)
       {
           context = new AddisTowerDataContext();
           var sparepartCategoryEntity = new DataAccessSearch.SparepartCategory
                                                                            {
                                                                                Id = Guid.NewGuid(),
                                                                                Name = Name,
                                                                                Remark = Remark
                                                                            };
           context.SparepartCategories.InsertOnSubmit(sparepartCategoryEntity);
           context.SubmitChanges();
       }
       //public int UpdateMotorcycleCategory(Guid Id, string Name, string Remark)
       //{
       //    context = new AddisTowerDataContext();
       //    return context.usp_Employee_Update(Id, Firstname, Lastname, Sex, Remark);

       //}
       //public int DeleteMotorcycleCategory(Guid Id)
       //{
       //    context = new AddisTowerDataContext();
       //    return context.usp_Employee_Delete(Id);
       //}
    }
}
