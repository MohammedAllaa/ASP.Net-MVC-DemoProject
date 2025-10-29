using IKEA.BLL.Dto_s.DepartmentDto_s;
using IKEA.BLL.Dto_s.EmployeeDto_s;
using IKEA.BLL.Services.DepartmentServices;
using IKEA.BLL.Services.EmployeeServices;
using IKEA.DAL.Models.Employee;
using IKEA.PL.ViewModel.DepartmentVMs;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers
{
    [Authorize]

    public class EmployeesController : Controller
    {
        private readonly IEmployeeServices employeeServices;
        private readonly ILogger<EmployeesController> logger;
        private readonly IWebHostEnvironment enviroment;
        //private readonly IDepartmentServices departmentServices;

        public EmployeesController(IEmployeeServices employeeServices,ILogger<EmployeesController> logger,IWebHostEnvironment enviroment )
        {
            this.employeeServices = employeeServices;
            this.logger = logger;
            this.enviroment = enviroment;
           // this.departmentServices = departmentServices;
        }

        public IActionResult Index(string? searchValue)
        {
            if (searchValue == null)
                return View(employeeServices.GetAllEmployees());
            else
                return View(employeeServices.GetSearchedEmployyes(searchValue));

        }
        [HttpGet]
        [Authorize(Roles ="NUser")]
        public IActionResult Create()
        {
            //ViewData["Departments"] = departmentServices.GetAllDepartments();
            return View();
        }

        [HttpPost]

        public IActionResult Create(CreatedEmployeeDto dto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = employeeServices.CreateEmployee(dto);
                    if (result > 0)
                    {
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        ModelState.AddModelError("", "Employee Can't Created");
                        return View(dto);
                    }

                }
                catch (Exception ex)
                {
                    if (enviroment.IsDevelopment())
                    {
                        //For development : store at file
                        logger.LogError(ex.Message);
                        return View(dto);
                    }
                    else
                    {
                        //production : store at table at data base
                        throw;
                    }
                }

            }
            else
            {
                return View(dto);
            }
        }

        [HttpGet]
        public IActionResult Details(int? Id)
        {
            if (Id == null) { return BadRequest(); }
            var employee = employeeServices.GetEmployeeById(Id.Value);

            if (employee == null) { return NotFound(); }

            return View(employee);
        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null) { return BadRequest(); }
            var employee = employeeServices.GetEmployeeById(Id.Value);

            if (employee == null) { return NotFound(); }

            var MappedEmployee = new UpdatedEmployeeDto
            {
                Id = employee.Id,
                Name = employee.Name,
                Age = employee.Age,
                Address = employee.Address,
                HiringDate = employee.HiringDate,
                Email = employee.Email,
                PhoneNumber = employee.PhoneNumber,
                Salary = employee.Salary,
                Gender = employee.Gender,
                EmployeeType = employee.EmployeeType,
                IsActive = employee.IsActive,

            };
            

            return View(MappedEmployee);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]

        public IActionResult Edit(UpdatedEmployeeDto employeeDto)
        {
            if (!ModelState.IsValid) { return View(employeeDto); }

            var Message = string.Empty;

            try
            {
                int result = employeeServices.UpdateEmployee(employeeDto);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return View(employeeDto);
                }

            }
            catch (Exception ex)
            {
                if (enviroment.IsDevelopment())
                {
                    //For development : store at file
                    logger.LogError(ex.Message);
                    return View(employeeDto);
                }
                else
                {
                    //production : store at table at data base
                    throw;
                }

            }
        }


        [HttpGet]
        public IActionResult Delete([FromRoute] int? Id)
        {
            if (Id is null) { return BadRequest(); }

            var Department = employeeServices.GetEmployeeById(Id.Value);
            if (Department is null) return NotFound();

            return View(Department);

        }

        [HttpPost]
        //[ValidateAntiForgeryToken]

        public IActionResult Delete(int Id)
        {
            bool IsDeleted = false;
            var message = string.Empty;
            try
            {
                var IsDeletedd = employeeServices.DeleteEmployee(Id);
                if (IsDeletedd > 0)
                {
                    IsDeleted = true;
                }
                else { IsDeleted = false; }
                if (IsDeleted)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    message = "Employee is Not Deleted";
                }
            }
            catch (Exception ex)
            {
                if (enviroment.IsDevelopment())
                {
                    //For development : store at file
                    logger.LogError(ex.Message);
                    message = "Wrong";
                }
                else
                {
                    //production : store at table at data base
                    throw;
                }

            }
            ModelState.AddModelError("", message);
            return RedirectToAction(nameof(Delete), new { id = Id });
        }
    }
}
