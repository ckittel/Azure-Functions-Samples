using System;

namespace SampleFunctions.Data.Models
{
    public class Student
    {
        public Student()
        {

        }

        public Student(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
        public Guid Id { get; set;  }
        public string Name { get; set;  }
    }

    public class NewStudent
    {
        public string Name { get; set;  }
    }
}
