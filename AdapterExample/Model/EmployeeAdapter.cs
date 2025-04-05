using System.Globalization;
using System.Reflection.Metadata.Ecma335;

namespace AdapterExample.Model
{
    public interface IEmployeeAdapter
    {
        public EmployeeModel GetEmployee(LegacyEmployeeModel emp);
    }

    public interface IGenericAdapter<TIn, TOut>
    {
        TOut Adapt(TIn input);
    }
    public class EmployeeAdapter:IEmployeeAdapter
    {
        public EmployeeModel GetEmployee(LegacyEmployeeModel emp)
        {
            var kq = new EmployeeModel();
            var listEmp = emp.Name.Split(" ");
            if (listEmp.Length > 0)
            {
                kq.FirstName = listEmp[0];
                kq.LastName = listEmp[1];
            }
            var date = DateTime.ParseExact(emp.BirthDay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            kq.DayOfBirth = date.Day;
            kq.MonthOfBirth = date.Month;
            kq.YearOfBirth = date.Year;
            return kq;
        }
    }
    public class EmployeeV2Adapter : IGenericAdapter<LegacyEmployeeModel, EmployeeModel>
    {
        public EmployeeModel Adapt(LegacyEmployeeModel emp)
        {
            var kq = new EmployeeModel();
            var listEmp = emp.Name.Split(" ");
            if (listEmp.Length > 0)
            {
                kq.FirstName = listEmp[0];
                kq.LastName = listEmp[1];
            }
            var date = DateTime.ParseExact(emp.BirthDay, "dd/MM/yyyy", CultureInfo.InvariantCulture);
            kq.DayOfBirth = date.Day;
            kq.MonthOfBirth = date.Month;
            kq.YearOfBirth = date.Year;
            return kq;
        }
    }
}
