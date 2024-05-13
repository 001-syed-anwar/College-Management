using CollegeManagement.Data;
using CollegeManagement.Models;
using CollegeManagement.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CollegeManagement.Controllers
{
    public class StudentController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public StudentController(ApplicationDbContext dbContext) { this.dbContext = dbContext; }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Add(AddStudentModel StudentModel)
        {
            Student student=new Student {
                reg_no = StudentModel.reg_no,
                name = StudentModel.name,
                age = StudentModel.age,
                email = StudentModel.email,
                phone = StudentModel.phone,
                city = StudentModel.city,
                country = StudentModel.country
                };
            await dbContext.Student.AddAsync(student);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("List", "Student"); ;
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await dbContext.Student.ToListAsync();
            return View(students);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dbContext.Student.FindAsync(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Student studentModel)
        {
            var student=await dbContext.Student.FindAsync(studentModel.Id);
            if(student is not null)
            {
                student.Id = studentModel.Id;
                student.reg_no = studentModel.reg_no;
                student.name = studentModel.name;
                student.age = studentModel.age;
                student.email = studentModel.email;
                student.phone = studentModel.phone;
                student.city = studentModel.city;
                student.country = studentModel.country;
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List","Student");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var student = await dbContext.Student.FindAsync(id);
            if (student is not null)
            {
                dbContext.Student.Remove(student);
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Student");
        }
    }
}
