using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryWebSiteProject.Models
{
    public class ShiftBL
    {
        FactoryDBEntities db = new FactoryDBEntities();
        

        public void AddShifts(Shifts shi)
        {
           db.Shifts.Add(shi);
            db.SaveChanges();
        }
        public List<Shifts> GetShiftPer()
        {
            
            var List = db.Shifts.ToList();
            return List;
        }
        public List<List<EmpInShift>> GetEmpNameToShift(List<Shifts> shifts)
        {
            List<List<EmpInShift>> empShifts = new List<List<EmpInShift>>();
            shifts.ForEach(s =>
            {
                var result = from emp in db.Employee
                             join shi in db.EmployeeShifts 
                             on emp.ID equals shi.EmploeeID
                             where shi.ShiftID == s.ID
                             select new EmpInShift

                             {
                                 FullName = emp.FirstName + emp.LastName,
                                 empID = emp.ID
                             };

                empShifts.Add(result.ToList());
            });
            return empShifts;

                        }

        public void DeleteByName(string name)
        {
            var user =  db.Employee.Where(x => x.FirstName + "" + x.LastName == name).First();



            var data2 = db.EmployeeShifts.Where(x => x.EmploeeID == user.ID).ToList();

         db.Employee.Remove(user);
            foreach (var item in data2)
            {
                db.EmployeeShifts.Remove(item);
            }

          db.SaveChanges();
        }
    }
}