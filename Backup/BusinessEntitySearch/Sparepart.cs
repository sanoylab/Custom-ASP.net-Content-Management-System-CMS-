using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccessSearch;

namespace BusinessEntitySearch
{
    public class Sparepart
    {
        private AddisTowerDataContext context;
        public List<DataAccessSearch.Sparepart> PopulateAllSparepart()
        {
            context = new AddisTowerDataContext();
            var list = from p in context.Spareparts
                       select p;
            return list.ToList();
        }

        public void InsertNewSparepart(Guid CategoryId, string Number, string Name, string Model, bool Approve, string Description, double Quantity)
        {
            context = new AddisTowerDataContext();
            if(Approve)
                UnApproveSelected();
            var sparePartEntity = new DataAccessSearch.Sparepart
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
            context.Spareparts.InsertOnSubmit(sparePartEntity);
            context.SubmitChanges();
        }

        public void UpdateSparepart(Guid Id,string Number, string Name, string Model, bool Approve, string Description, double Quantity)
        {
            context = new AddisTowerDataContext();
            if(Approve)
                UnApproveSelected();
            var selectedSparepart = from p in context.Spareparts
                                    where p.Id == Id
                                    select p;
            DataAccessSearch.Sparepart sparepart = selectedSparepart.First();
            sparepart.Number = Number;
            sparepart.Name = Name;
            sparepart.Model = Model;
            sparepart.Approve = Approve;
            sparepart.Description = Description;
            sparepart.Quantity = Quantity;

            context.SubmitChanges();
        }

        public List<DataAccessSearch.Sparepart> PopulateAllSparepartByCategoryId(Guid CategoryId)
        {
            context = new AddisTowerDataContext();
            var list = from p in context.Spareparts
                       where p.CategoryId == CategoryId
                       select p;
            return list.ToList();
        }

        public void UnApproveSelected()
        {
            var selectedApproved = from p in context.Spareparts
                                   where p.Approve == true
                                   select p;
            if (!selectedApproved.Equals(null))
            {
                DataAccessSearch.Sparepart sparepart = selectedApproved.First();
                sparepart.Approve = false;
                context.SubmitChanges();
            }
        }

        public DataAccessSearch.Sparepart GetApprovedSparepart()
        {
            context = new AddisTowerDataContext();
            var approvedSpare = from p in context.Spareparts
                                where p.Approve == true
                                select p;
            return approvedSpare.First();
        }

        public DataAccessSearch.ItemImage GetApprovedImageUrl()
        {
            context = new AddisTowerDataContext();
            DataAccessSearch.Sparepart motorcycle = GetApprovedSparepart();
            var selectedMotor = from p in context.ItemImages
                                where p.MotorOrSpareId == motorcycle.Id
                                select p;
            return selectedMotor.First();
        }
    }
}
