using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CS4790F17A2Practice.Models;

namespace CS4790F17A2Practice.Models
{
    public class Repository
    {
        public static CourseSection getCourseAndSections(int? id)
        {
            CourseSection courseSection = BasicStudent.getCourseAndSections(id);

            return courseSection;
        }
    }

    public class CourseSection
    {
        public CourseSection()
        {
        }

        public Course course { get; set; }
        public List<Section> sections { get; set; }
    }
 
}