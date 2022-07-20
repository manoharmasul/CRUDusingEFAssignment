using CRUDusingEFAssignment.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDusingEFAssignment.Data
{
    
    public class EmployeeDAL
    {
        ApplicationDbContext db;
        public EmployeeDAL()
        { 
        }
        public List<Employee> GetAllEmployees()
        {
            return db.Employees.ToList();

        }
        public Employee GetEmployeeById(int id)
        {
            Employee e = db.Employees.Where(x => x.Id == id).FirstOrDefault();
            return e;
        }
        public int AddEmployee(Employee emp)
        {
            //add emp object in the employees collections
            db.Employees.Add(emp);
            //reflect the change in database
           int result= db.SaveChanges();
            return result;
        }
        public int UpdateEmployee(Employee emp)
        {
            int result = 0;
            Employee e = db.Employees.Where(x => x.Id == emp.Id).FirstOrDefault();
            if(e!=null)
            {
                e.Name = emp.Name;
                e.Salary = emp.Salary;
                result = db.SaveChanges();
            }
            return result;
        }
        public int DeleteEmployee(int id)
        {
            int result = 0;
            Employee e = db.Employees.Where(x => x.Id == id).FirstOrDefault();
            if (e != null)
            {
                db.Employees.Remove(e);
                result = db.SaveChanges();
            }
            return result;

        }
    }
}
