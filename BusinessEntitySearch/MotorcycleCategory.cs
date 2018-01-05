using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessSearch;

namespace BusinessEntitySearch
{
   public class MotorcycleCategory
    {
       private AddisTowerDataContext context;
       public List<DataAccessSearch.MotorcycleCategory> PopulateAllMotorcycleCategoy()
       {
           context = new AddisTowerDataContext();
           var list = from p in context.MotorcycleCategories
                      select p;
           return list.ToList();
       }
       public void InsertMotorcycleCategory(string Name, string Remark)
       {
           DataAccessSearch.MotorcycleCategory motorcycleCategory = new DataAccessSearch.MotorcycleCategory
                                                                        {
                                                                            Id = Guid.NewGuid(),
                                                                            Name = Name,
                                                                            Remark = Remark
                                                                        };
           context = new AddisTowerDataContext();
           context.MotorcycleCategories.InsertOnSubmit(motorcycleCategory);
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
