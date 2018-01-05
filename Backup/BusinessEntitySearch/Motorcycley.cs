using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessSearch;

namespace BusinessEntitySearch
{
    public class Motorcycle
    {
        private AddisTowerDataContext context;
        public List<DataAccessSearch.Motorcycle> PopulateAllMotorcycle()
        {
            context = new AddisTowerDataContext();
            var list = from p in context.Motorcycles
                       select p;
            return list.ToList();
        }

        public void InsertNewMotorcycle(Guid CategoryId, string Number, string Name, string Model, bool Approve, string Description, double Quantity)
        {
            context = new AddisTowerDataContext();
            if (Approve)
                UnApproveSelected();
            var motorCycleEntity = new DataAccessSearch.Motorcycle
                                                               {
                                                                   Approve = Approve,
                                                                   CategoryId = CategoryId,
                                                                   Description = Description,
                                                                   Id = Guid.NewGuid(),
                                                                   Model = Model,
                                                                   Name = Name,
                                                                   Number = Number,
                                                                   Quantity = Quantity
                                                               };
            context.Motorcycles.InsertOnSubmit(motorCycleEntity);
            context.SubmitChanges();
        }

        public List<DataAccessSearch.Motorcycle> PopulateAllMotorcycleByCategoryId(Guid CategoryId)
        {
            context = new AddisTowerDataContext();
            var list = from p in context.Motorcycles
                       where p.CategoryId == CategoryId
                       select p;
            return list.ToList();
        }

        public void UnApproveSelected()
        {
            var selectedApproved = from p in context.Motorcycles
                                   where p.Approve == true
                                   select p;
            if (!selectedApproved.Equals(null))
            {
                DataAccessSearch.Motorcycle motorcycle = selectedApproved.First();
                motorcycle.Approve = false;
                context.SubmitChanges();
            }
        }

        public void UpdateMotorcycle(Guid Id, string Number, string Name, string Model, bool Approve, string Description, double Quantity)
        {
            context = new AddisTowerDataContext();
            if (Approve)
                UnApproveSelected();
            var selectedSparepart = from p in context.Motorcycles
                                    where p.Id == Id
                                    select p;
            DataAccessSearch.Motorcycle motorcycle = selectedSparepart.First();
            motorcycle.Number = Number;
            motorcycle.Name = Name;
            motorcycle.Model = Model;
            motorcycle.Approve = Approve;
            motorcycle.Description = Description;
            motorcycle.Quantity = Quantity;

            context.SubmitChanges();
        }

        public void SaveImage(DataAccessSearch.ItemImage itemImageEntity)
        {
            context = new AddisTowerDataContext();
            context.ItemImages.InsertOnSubmit(itemImageEntity);
            context.SubmitChanges();
        }

        public DataAccessSearch.Motorcycle GetApprovedMotor()
        {
            context = new AddisTowerDataContext();
            var approvedMotor = from p in context.Motorcycles
                                where p.Approve == true
                                select p;
            return approvedMotor.First();
        }

        public DataAccessSearch.ItemImage GetApprovedImageUrl()
        {
            context = new AddisTowerDataContext();
            DataAccessSearch.Motorcycle motorcycle = GetApprovedMotor();
            var selectedMotor = from p in context.ItemImages
                                where p.MotorOrSpareId == motorcycle.Id
                                select p;
            return selectedMotor.First();
        }
        //public int InsertMotorcycle(Guid CategoryId, string Number, string Name, string Model, float Quantity)
        //{
        //    context = new AddisTowerDataContext();
        //    return context;
        //}
        //public int UpdateMotorcycle(Guid Id, Guid CategoryId, string Number, string Name, string Model, float Quantity)
        //{
        //    context = new AddisTowerDataContext();
        //    return context.usp_Employee_Update(Id, Firstname, Lastname, Sex, Remark);

        //}
        //public int DeleteMotorcycle(Guid Id)
        //{
        //    context = new AddisTowerDataContext();
        //    return context.usp_Employee_Delete(Id);
        //}
    }
}
