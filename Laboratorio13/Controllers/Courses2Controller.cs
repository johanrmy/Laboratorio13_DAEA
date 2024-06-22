using Laboratorio13.Models;
using Laboratorio13.Models.Request.Course;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Laboratorio13.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class Courses2Controller : ControllerBase
    {
        private readonly SchoolContext _context;
        public Courses2Controller(SchoolContext context)
        {
            _context = context;
        }

        [HttpPost]
        public void Insert(CourseInsertRequest request) {
            try {
                Course course = new Course();
                course.Name = request.Name;
                course.Credit = request.Credit;
                course.Active = true;
                _context.Courses.Add(course);
                _context.SaveChanges();
            }
            catch {
                BadRequest("Course not created");
            }
        }

        [HttpDelete]
        public void Delete(CourseDeleteRequest request)
        {
            var courseToDelete = _context.Courses.FirstOrDefault(c => c.CourseId == request.CourseId);

            if (courseToDelete == null)
            {
                BadRequest("Course not found");
            }
            else
            {
                courseToDelete.Active= false;
                _context.SaveChanges();
            }
        }

        [HttpDelete]
        public void DeleteListCourses(CourseListDeleteRequest request) {
            try
            {
                var coursesToDelete = _context.Courses.Where(c => request.CoursesId.Contains(c.CourseId));

                foreach (var course in coursesToDelete)
                {
                    course.Active = false;
                }

                _context.SaveChanges();

            }
            catch
            {
                BadRequest("Failed to deactivate courses");
            }
        }
    }
}
