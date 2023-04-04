
using ASPWEBAPP.Data;
using ASPWEBAPP.Models;
using ASPWEBAPP.Models.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ASPWEBAPP.Controllers
{
    public class EmployeesController : Controller
    {
        private readonly MVCDbContext mVCDb;

        public EmployeesController(MVCDbContext mVCDb)
        {
            this.mVCDb = mVCDb;
        }

        [HttpGet]
        public  async  Task<IActionResult> Index()
        {
           var employees =  await mVCDb.Employees.ToListAsync();
            return View(employees);
        }

        [HttpGet]
        public IActionResult add()
        {
            return View();
        }
        [HttpPost]
        public async Task< IActionResult> Add(AddEmployeeviewmodel addEmployeeRequest)
        {
            var employee = new EMP()
            {
       
                Name=addEmployeeRequest.Name,
                Email=addEmployeeRequest.Email,
                Salary=addEmployeeRequest.Salary,
                Department=addEmployeeRequest.Department,
                DOB = addEmployeeRequest.DOB

            };

             await mVCDb.Employees.AddAsync(employee);
             await mVCDb.SaveChangesAsync();
            return RedirectToAction("Add");
        }
        [HttpGet]
        public async Task<IActionResult> view( int id)
        {
             var employee = await mVCDb.Employees.FirstOrDefaultAsync(x => x.Id == id);
           if(employee != null)
            {
                var viewModel = new updateviewmodel()
                {
                    Id = employee.Id,
                    Email = employee.Email,
                    Name = employee.Name,
                    Salary = employee.Salary,
                    Department = employee.Department,
                    DOB = employee.DOB

                };
                return await Task.Run(()=> View( "View",viewModel));
            }
        return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task<IActionResult> View(updateviewmodel model)
        {
            var employee = await mVCDb.Employees.FirstAsync();

            if(employee != null)
            {
                employee.Name = model.Name;
                employee.Salary = model.Salary;
                employee.Department = model.Department;
                employee.DOB = model.DOB;
                employee.Email= model.Email;

               await mVCDb.SaveChangesAsync();

                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        
    }
}
