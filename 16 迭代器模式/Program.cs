using System;
using System.Collections;
using System.Collections.Generic;

namespace _16_迭代器模式
{
    internal class Program
    {
        /*
         *
         * 为什么会有迭代器
         */


        private static void Main(string[] args)
        {
            List<Person> persons = new List<Person>
            {
                new Person {Id = 1, Name = "wjire1"},
                new Person {Id = 2, Name = "wjire2"},
                new Person {Id = 3, Name = "wjire3"},
                new Person {Id = 4, Name = "wjire4"},
                new Person {Id = 5, Name = "wjire5"},
            };

            PersonCollection pc = new PersonCollection(persons);
            foreach (Person person in pc)
            {
                Console.WriteLine(person.Id);
            }
            Console.ReadKey();
        }
    }




    /// <summary>
    /// 具体的聚合类
    /// </summary>
    public class PersonCollection : IEnumerable<Person>
    {
        private List<Person> persons;
        public PersonCollection(List<Person> persons)
        {
            this.persons = persons;
        }
        

        public IEnumerator<Person> GetEnumerator()
        {
            foreach (Person person in persons)
            {
                yield return person;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
