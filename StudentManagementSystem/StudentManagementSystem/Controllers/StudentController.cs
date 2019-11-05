using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace StudentManagementSystem.Controllers
{

    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Students> _student = new List<Students>();
        private static List<Course> _course = new List<Course>();


        [HttpPost("api/students")]
        public IActionResult CreateStudents(Students student)
        {

            bool flag = false;
            var laststud = _student.OrderByDescending(x => x.StudentId).FirstOrDefault();
            int id = laststud == null ? 1 : laststud.StudentId + 1;
            foreach (var course in _course)
            {
                if (student.Course == course.CourseName)
                {
                    flag = true;
                }
            }
            if (flag == false)
            {
                return Conflict("Course is Not is list");
            }
            if (Convert.ToDateTime(student.DateOfBirth) > DateTime.Now)
            {
                return Conflict("enter a valid date");
            }
            if (Convert.ToDateTime(student.EnrollmentDate) > DateTime.Now)
            {
                return Conflict("enter a valid date");
            }

            else
            {
                var studToBeAdded = new Students
                {

                    StudentId = id,
                    FirstName = student.FirstName,
                    LastName = student.LastName,
                    DateOfBirth = student.DateOfBirth,
                    Address = student.Address,
                    Course = student.Course,
                    PhoneNo = student.PhoneNo,
                    EnrollmentDate = student.EnrollmentDate
                };
                _student.Add(studToBeAdded);
                return Ok(studToBeAdded.StudentId);
            }


        }

        [HttpGet("api/students")]

        public IActionResult GetStudentList()
        {
            var student = from s in _student
                          select new { s.FirstName, s.LastName };
            return Ok(_student);
        }

        //GET api/course_details
        [HttpGet("api/course/details")]
        public IActionResult GetCourseListDetails()
        {
            var courselist = from C in _course
                             join S in _student on C.CourseName equals S.Course
                             group S by S.Course into g
                             select new { CourseName = g.Key, Student_Count = g.Count() };
            return Ok(courselist);
        }



        // GET api/student/id
        [HttpGet("api/students/{id}")]
        public IActionResult GetStudentDetailsById(int id)
        {
            foreach (var entity in _student)
            {
                if (entity.StudentId == id)
                {
                    return Ok(entity);
                }

            }
            return NotFound();
        }


        // GET api/course/id
        [HttpGet("api/course/{C_name}")]
        public IActionResult GetCourseDetailsById(string C_name)
        {
            foreach (var entity in _course)
            {
                if (entity.CourseName == C_name)
                {
                    return Ok(entity);
                }

            }
            return NotFound();
        }


        [HttpGet("api/course")]

        public IActionResult GetCourseDetails()
        {
            return Ok(_course);
        }

        [HttpPost("api/course")]
        public IActionResult CreateCourseDetails(Course course)
        {
            var courseToBeAdded = new Course
            {

                CourseName = course.CourseName,
                Sub1 = course.Sub1,
                Sub2 = course.Sub2,
                Sub3 = course.Sub3
            };
            _course.Add(courseToBeAdded);
            return Ok(courseToBeAdded.CourseName);
        }


             [HttpPut("api/stud/{id}")]
        public IActionResult EdidtStudentDetails(int id, Students student)
        {
            foreach (var entity in _student)
            {
                if (Convert.ToDateTime(student.DateOfBirth) > DateTime.Now)
                {
                    return Conflict("enter a valid date");
                }
                if (Convert.ToDateTime(student.EnrollmentDate) > DateTime.Now)
                {
                    return Conflict("enter a valid date");
                }
                else if (entity.StudentId == id)
                {

                    entity.FirstName = student.FirstName;
                    entity.LastName = student.LastName;
                    entity.DateOfBirth = student.DateOfBirth;
                    entity.Address = student.Address;
                    entity.Course = student.Course;
                    entity.PhoneNo = student.PhoneNo;
                    entity.EnrollmentDate = student.EnrollmentDate;
                    return Ok(entity.StudentId);

                }
            }
            return NotFound();
        }


        [HttpPut("api/course")]
        public IActionResult EditCourseDetails(Course course)
        {
            foreach (var entity in _course)
            {
                if (entity.CourseName == course.CourseName)
                {
                    entity.CourseName = course.CourseName;
                    entity.Sub1 = course.Sub1;
                    entity.Sub2 = course.Sub2;
                    entity.Sub3 = course.Sub3;
                    return Ok(entity.CourseName);
                }
            }
            return NotFound();
        }

        [HttpDelete("api/stud/{id}")]
        public IActionResult DelStudentDetails(int id)
        {
            foreach (var entity in _student)
            {
                if (entity.StudentId == id)
                {
                    _student.Remove(entity);
                    return Ok();
                }
            }
            return NotFound();

        }

        [HttpDelete("api/course/{id}")]
        public IActionResult DeleteCourseDetails(string id)
        {
            foreach (var entity in _course)
            {
                if (entity.CourseName == id)
                {
                    _course.Remove(entity);
                    return Ok();
                }
            }
            return NotFound();

        }

    }


}


