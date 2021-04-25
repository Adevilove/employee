using PrabinINT.Context;
using PrabinINT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PrabinINT.Provider
{
    public class EmployeeProvider
    {
        public bool InsertUpdate(EmployeeModel model)
        {
            using (PBINTVEntities ent = new PBINTVEntities())
            {
                //  var userid = HttpContext.Current.User.Identity.GetUserId();
                var data = ent.EmployeeTbls.Where(x => x.Id == model.Id).FirstOrDefault();
                if (data == null)
                {
                    data = new EmployeeTbl();
                }

                data.Employee_Name = model.Employee_Name;
                data.Address = model.Address;
                data.Date_Of_Birth = model.Date_Of_Birth;
                data.Salary = model.Salary;
              
                if (model.Id > 0)
                {

                   
                    data.UpdatedDate = DateTime.Now;
                    ent.Entry(data).State = System.Data.EntityState.Modified;

                }
                else
                {
                    
                    data.CreatedDate = DateTime.Now;
                    ent.EmployeeTbls.Add(data);

                }

                int save = ent.SaveChanges();
                if (save > 0)
                {
                    return true;
                }

                else
                {
                    return false;
                }
            }

            //}
        }
        public List<EmployeeModel> GetEmployeeList()
        {
            using (PBINTVEntities ent = new PBINTVEntities())
            {
                var getlist = ent.EmployeeTbls
                    .Select(x => new EmployeeModel()
                    {
                        Id = x.Id,
                        Employee_Name = x.Employee_Name,
                        Address = x.Address,
                        Date_Of_Birth = x.Date_Of_Birth,
                        Salary = x.Salary,

                    }).ToList();
                return getlist;
            }
        }
    }
}