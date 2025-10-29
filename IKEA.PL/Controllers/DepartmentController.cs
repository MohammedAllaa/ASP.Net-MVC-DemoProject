using IKEA.BLL.Dto_s.DepartmentDto_s;
using IKEA.BLL.Services.DepartmentServices;
using IKEA.PL.ViewModel.DepartmentVMs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IKEA.PL.Controllers
{
    [Authorize (Roles = "NUser")]

    public class DepartmentController : Controller
    {
        private readonly IDepartmentServices _departmentServices;
        private readonly ILogger<DepartmentController> logger;
        private readonly IWebHostEnvironment webHOst;

        public DepartmentController(IDepartmentServices department, ILogger<DepartmentController> logger, IWebHostEnvironment webHOst)
        {
            _departmentServices = department;
            this.logger = logger;
            this.webHOst = webHOst;
        }

        public IActionResult Index()
        {
            ViewData["Msg"] = "Hello VD";
            ViewBag.Msg = "Hello VB";
            var departments = _departmentServices.GetAllDepartments();
            return View(departments);
        }

        [HttpGet]
        public IActionResult Create() => View();

        [HttpPost]

        public IActionResult Create(CreateDepartmentDto departmentDto)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    int result = _departmentServices.AddDepartment(departmentDto);
                    if (result > 0)
                    {
                        TempData["Msg"] = $"Department {departmentDto.Name} Created Successfully";
                        return RedirectToAction("Index");
                    }
                    else
                    {
                        TempData["Msg"] = $"Department can not Created";
                        ModelState.AddModelError("", "Something went wrong");
                        return View(departmentDto);
                    }

                }
                catch (Exception ex)
                {
                    if (webHOst.IsDevelopment())
                    {
                        //For development : store at file
                        logger.LogError(ex.Message);
                        return View(departmentDto);
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
                return View(departmentDto);
            }
        }

        [HttpGet]
        public IActionResult Details(int? Id)
        {
            if (Id == null) { return BadRequest(); }
            var Department = _departmentServices.GetDepartmentById(Id.Value);

            if (Department == null) { return NotFound(); }

            return View(Department);


        }

        [HttpGet]
        public IActionResult Edit(int? Id)
        {
            if (Id == null) { return BadRequest(); }
            var Department = _departmentServices.GetDepartmentById(Id.Value);

            if (Department == null) { return NotFound(); }

            var departmentVM = new DepartmentViewModel
            {
                Id = Department.Id,
                Name = Department.Name,
                Description = Department.Description,
                Code = Department.Code
            };

            return View(departmentVM);
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Edit([FromRoute] int? Id, DepartmentViewModel model)
        {
            if (!ModelState.IsValid) { return View(model); }

            var department = new UpdatedDepartmentDto
            {
                Id = Id.Value,
                Name = model.Name,
                Description = model.Description,
                Code = model.Code
            };

            try
            {
                int result = _departmentServices.UpdateDepartment(department);
                if (result > 0)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    ModelState.AddModelError("", "Something went wrong");
                    return View(model);
                }

            }
            catch (Exception ex)
            {
                if (webHOst.IsDevelopment())
                {
                    //For development : store at file
                    logger.LogError(ex.Message);
                    return View(model);
                }
                else
                {
                    //production : store at table at data base
                    throw;
                }

            }
        }
        [HttpGet]
        public IActionResult Delete([FromRoute] int? Id) {
            if (Id is null) { return BadRequest(); }

            var Department = _departmentServices.GetDepartmentById(Id.Value);
            if (Department is null) return NotFound();

            return View(Department);
        
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]

        public IActionResult Delete (int Id)
        {
            bool IsDeleted = false;
            var message = string.Empty;
            try
            {
               var IsDeletedd = _departmentServices.DeleteDepartment(Id);
                if (IsDeletedd > 0)
                {
                     IsDeleted = true;
                }
                else {  IsDeleted = false; }
                if (IsDeleted)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    message = "Department is Not Deleted";  
                }
            }
            catch (Exception ex)
            {
                if (webHOst.IsDevelopment())
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
