using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace CS4790F17A2Practice.Models
{
    public class BasicStudent
    {
        public static Course getCourse(int courseNo)
        {
            Course course = new Course();

            BasicStudentDbContext db = new BasicStudentDbContext();
            course =  db.courses.Find(courseNo);

            return course;
        }

        public static CourseSection getCourseAndSections(int? id)
        {
            BasicStudentDbContext db = new BasicStudentDbContext();
            CourseSection courseSection = new CourseSection();
            courseSection.course = db.courses.Find(id);

            var sections = db.sections.Where(s => s.courseNumber == courseSection.course.courseNumber);
            courseSection.sections = sections.ToList();

            return courseSection;
        }
    }

    [Table("Course")]
    public class Course
    {
        [Key]
        public int  Id { get; set; }
        [DisplayName("Course Number")]
        public string courseNumber { get; set; }
        [DisplayName("Course Name")]
        public string courseName { get; set; }
        [DisplayName("Credit Hours")]
        public int creditHours { get; set; }
        [DisplayName("Maximum Enrollment")]
        public int? maxEnrollment { get; set; }
    }

    [Table("Section")]
    public class Section
    {
        [Key]
        public int Id { get; set; }
        public int sectionID { get; set; }
        public int sectionNumber { get; set; }
        public string courseNumber { get; set; }
        public string sectionDays { get; set; }
        public DateTime sectionTime { get; set; }
    }

    public class BasicStudentDbContext : DbContext
    {
        public DbSet<Course> courses { get; set; }
        public DbSet<Section> sections { get; set; }
    }

}