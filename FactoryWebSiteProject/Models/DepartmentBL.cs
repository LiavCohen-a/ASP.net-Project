using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryWebSiteProject.Models
{
    public class DepartmentBL
    {
        FactoryDBEntities db = new FactoryDBEntities();

        public List<Departments> GetDepartments()
        {
            var result = db.Departments.ToList();
            return result;
        }
        public List<ManInDep> Getmaneger()
        {
            var result = from emp in db.Employee
                         join dep in db.Departments
                         on emp.ID equals dep.ID
                         where dep.ID == emp.Department
                         select new ManInDep
                         {
                             ManegerName = emp.FirstName + " " + emp.LastName,
                             Depart =  dep.DepName
                         };
            return result.ToList();        
        }

        public Departments EditData(int depID)
        {
            var d = db.Departments.Where(x => x.ID == depID).First();
            return d;
        }

        public void EditData(Departments dep)
        {
            var d = db.Departments.Where(x => x.ID == dep.ID).First();
            d.ID = dep.ID;
            d.DepName = dep.DepName;
            d.ManegerEmpID = dep.ManegerEmpID;
            db.SaveChanges();
        }
        public void DeleteDep(int depid)
        {
            var result = db.Departments.Where(x => x.ID == depid).First();
            db.Departments.Remove(result);
            db.SaveChanges();
        }
        public void CreateDep(Departments deps)
        {
            db.Departments.Add(deps);
            db.SaveChanges();
        }


    }
}