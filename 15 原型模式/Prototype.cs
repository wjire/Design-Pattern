using System;

namespace _15_原型模式
{
    public class Prototype
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public Student Student { get; set; }


        private Prototype()
        {

        }

        private static Prototype prototype = null;

        static Prototype()
        {
            Console.WriteLine("初始化一次");
            prototype = new Prototype()
            {
                Id = 1,
                Name = "wjire",
                Student = new Student
                {
                    Id = 11
                }
            };
        }

        public static Prototype CreatePrototype()
        {
            return prototype.MemberwiseClone() as Prototype;
        }
    }

    public class Student
    {
        public int Id { get; set; }
    }
}
