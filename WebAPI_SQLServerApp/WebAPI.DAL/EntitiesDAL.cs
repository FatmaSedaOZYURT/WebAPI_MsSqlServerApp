using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPI.DAL.Model;

namespace WebAPI.DAL
{
    public class EntitiesDAL : BaseEntity
    {
        

        public IEnumerable<EmployeeModel> GetEmployees()
        {
            List<EmployeeModel> employees = new List<EmployeeModel>();
            List<Employee> employees2 = db.Employees.ToList();
            foreach (Employee item in employees2)
            {
                employees.Add(new EmployeeModel() { EmployeeID = item.EmployeeID, FirstName = item.FirstName, LastName = item.LastName });
            }
            return employees;
        }
        public EmployeeModel GetEmployeeByID(int id)
        {
            Employee employee = db.Employees.Find(id);
            if (employee != null)
            {
                EmployeeModel model = new EmployeeModel() { EmployeeID = employee.EmployeeID, FirstName = employee.FirstName, LastName = employee.LastName };
                return model; 
            }
            return null;
        }

        public Employee AddEmployee(Employee emp)
        {
            try
            {
                db.Employees.Add(emp);
                db.SaveChanges();
                return emp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public Employee UpdateEmployee(Employee emp)
        {
            try
            {
                IsThereAnyEmployee(emp.EmployeeID);
                db.Entry(emp).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return emp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void IsThereAnyEmployee(int employeeID)
        {
            if(!db.Employees.Any(a => a.EmployeeID == employeeID))
                throw new Exception("Kayıt bulunamadı.");
        }

        public Employee DeleteEmployee(Employee emp)
        {
            try
            {
                IsThereAnyEmployee(emp.EmployeeID);
                db.Entry(emp).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
                return emp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
