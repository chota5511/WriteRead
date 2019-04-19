using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WriteRead
{
    public class Student
    {
        private int id;
        private string name;
        private string dateOfBirth;
        private float english;
        private float math;

        //Getter and Setter
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string DateOfBirth
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }
        public float English
        {
            get { return english; }
            set { english = value; }
        }
        public float Math
        {
            get { return math; }
            set { math = value; }
        }

        //Constructor
        public Student()
        {
            this.name = "";
            this.dateOfBirth = "";
        }

        public Student(Student _student)
        {
            this.ID = _student.id;
            this.Name = _student.Name;
            this.DateOfBirth = _student.DateOfBirth;
            this.English = _student.English;
            this.Math = _student.Math;
        }

        public Student(int _id,string _name, string _dateOfBirth,float _english ,float _math)
        {
            this.ID = _id;
            this.Name = _name;
            this.DateOfBirth = _dateOfBirth;
            this.English = _english;
            this.Math = _math;
        }

        //Method
        public float Average()
        {
            return (this.English + this.Math) / 2;
        }
    }
}
