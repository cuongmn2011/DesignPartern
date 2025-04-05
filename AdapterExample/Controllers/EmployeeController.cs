using AdapterExample.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AdapterExample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeAdapter _employeeAdapter;
        private readonly IGenericAdapter<LegacyEmployeeModel, EmployeeModel> _employeeV2Adapter;
        public EmployeeController(IEmployeeAdapter employeeAdapter, IGenericAdapter<LegacyEmployeeModel, EmployeeModel> generic) 
        { 
            _employeeAdapter = employeeAdapter;
            _employeeV2Adapter = generic;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var empData = new LegacyEmployeeModel
            {
                Name = "Nguyễn Cường",
                BirthDay = "20/11/1996",
                Id = "1"
            };
            //return Ok(_employeeAdapter.GetEmployee(empData));
            return Ok(_employeeV2Adapter.Adapt(empData));

        }
    }
}
