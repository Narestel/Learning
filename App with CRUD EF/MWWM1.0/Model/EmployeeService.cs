using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace MWWM1._0.Model
{
    public class EmployeeService
    {
        MVVMDemoDBEntities objContext;

        public EmployeeService()
        {
            objContext = new MVVMDemoDBEntities();
        }
        public List<EmployeeDTO> GetAll()
        {
            List<EmployeeDTO> ObjEmployeesList = new List<EmployeeDTO>();
            try
            {
                var ObjQuery = from Employee in objContext.Employees
                               select Employee;
                foreach (var employee in ObjQuery)
                {
                    ObjEmployeesList.Add(new EmployeeDTO { Id = employee.Id, Name = employee.Name, Age = employee.Age });
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return ObjEmployeesList;
        }

        public bool Add(EmployeeDTO objNewEmployee)
        {
            bool IsAdded = false;
            if (objNewEmployee.Age < 18 || objNewEmployee.Age > 65)
                throw new ArgumentException("Invalid age limit for employee.");
            try
            {
                var ObjEmployee = new Employees();
                ObjEmployee.Id = objNewEmployee.Id;
                ObjEmployee.Name = objNewEmployee.Name;
                ObjEmployee.Age = objNewEmployee.Age;

                objContext.Employees.Add(ObjEmployee);
                var NoOfRowsAffected = objContext.SaveChanges();
                IsAdded = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }


            return IsAdded;
        }

        public bool Update(EmployeeDTO objEmployeeToUpdate)
        {
            bool IsUpdated = false;

            try
            {
                var ObjEmployee = objContext.Employees.Find(objEmployeeToUpdate.Id);
                ObjEmployee.Name = objEmployeeToUpdate.Name;
                ObjEmployee.Age = objEmployeeToUpdate.Age;
                var NoOfRowsAffected = objContext.SaveChanges();
                IsUpdated = NoOfRowsAffected > 0;
            }
            catch (Exception ex)
            {

                throw ex;
            }

            return IsUpdated;
        }

        public bool Delete(int id)
        {
            bool IsDeleted = false;

            try
            {
                var ObjEmployeeToDelete = objContext.Employees.Find(id);
                objContext.Employees.Remove(ObjEmployeeToDelete);
                var NoOfRowsAffected = objContext.SaveChanges();
                IsDeleted = NoOfRowsAffected > 0;

            }
            catch (Exception ex)
            {

                throw ex;
            }

            return IsDeleted;
        }

        public EmployeeDTO Search(int id)
        {
            EmployeeDTO ObjEmployee = null;
            try
            {
                var ObjEmployeeToFind = objContext.Employees.Find(id);
                if (ObjEmployeeToFind != null)
                {
                    ObjEmployee = new EmployeeDTO()
                    {
                        Id = ObjEmployeeToFind.Id,
                        Name = ObjEmployeeToFind.Name,
                        Age = ObjEmployeeToFind.Age
                    };
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ObjEmployee;
        }
    }
}

