using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FactoryWebSiteProject.Models
{
    public class EmployeeBL
    {
        FactoryDBEntities db = new FactoryDBEntities();

        public List<Employee> GetEmployees()
        {
           return db.Employee.ToList();
        }

        public List<Employee> getselectedEmployee(string str )
        {
            List<Employee> list = new List<Employee>();
            var data = db.Employee.Where(x => x.FirstName.Contains(str) || x.LastName.Contains(str)).ToList();
            foreach(var emp in data)
            {
                list.Add(emp);
            }
            var data2 = db.Departments.Where(d => d.DepName.Contains(str)).ToList();
            foreach(var dep in data2)
            {
                var arr = db.Employee.Where(x => x.Department == dep.ID).First();
                list.Add(arr);
            }
            return list;
        }
        public void AddEmployees(Employee emp)
        {
             db.Employee.Add(emp);
            db.SaveChanges();
        }

        public Employee GetEditor(int empID)
        {
            return db.Employee.Where(x => x.ID == empID).First();
        }
        public void Getdata(Employee emp)
        {
            var em =  db.Employee.Where(x => x.ID == emp.ID).First();
            em.ID = emp.ID;
            em.FirstName = emp.FirstName;
            em.LastName = emp.LastName;
            em.StartWorkYear = emp.StartWorkYear;
            em.Department = emp.Department;
            db.SaveChanges();
        }
        public void DeleteEmp(int empID)
        {
            var data = db.Employee.Where(x => x.ID == empID).First();

            var data2 = db.EmployeeShifts.Where(x => x.EmploeeID == empID);

            db.Employee.Remove(data);
            foreach(var item in data2)
            {
                db.EmployeeShifts.Remove(item);
            }

            db.SaveChanges();
        }
        public List<ShiftsToEmp> ShiftToEmp()
        {
            var result = from emp in db.Employee
                         join empshi in db.EmployeeShifts
                         on emp.ID equals empshi.EmploeeID
                         join shi in db.Shifts
                         on empshi.ShiftID equals shi.ID

                         where emp.ID == empshi.EmploeeID
                         select new ShiftsToEmp
                         {
                             FullName = emp.FirstName + " " + emp.LastName,
                             shifts = shi.Date,
                             empID = emp.ID,
                             Start = shi.StartTime,
                             End = shi.EndTime
                             
                         };
            return result.ToList();
        }
        
        public void AddShiftToEmp(int EmployeeID, int ShiftID)
        {
            
            EmployeeShifts shi = new EmployeeShifts();
            shi.ID = shi.ID;
            shi.EmploeeID = ShiftID;
            shi.ShiftID = EmployeeID;


            db.EmployeeShifts.Add(shi);
            db.SaveChanges();
        }
    }
}