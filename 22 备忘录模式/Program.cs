using System;
using System.Collections.Generic;
using Tools;

namespace _22_备忘录模式
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            List<ContactPerson> list = new List<ContactPerson>
            {
                new ContactPerson {Name = "1", Phone = "1111"},
                new ContactPerson {Name = "2", Phone = "1111"},
                new ContactPerson {Name = "3", Phone = "1111"},
                new ContactPerson {Name = "4", Phone = "1111"},
                new ContactPerson {Name = "5", Phone = "1111"},
            };

            PhoneOwner owner = new PhoneOwner(list);
            Memo memo = owner.CreateMemo();
            foreach (ContactPerson person in memo.ContactPersonList)
            {
                Console.WriteLine(person.Name + ":" + person.Phone);
            }
            Console.WriteLine("**************");

            owner.ContactPersonList.RemoveAt(4);
            foreach (ContactPerson person in owner.ContactPersonList)
            {
                Console.WriteLine(person.Name + ":" + person.Phone);
            }
            Console.WriteLine("**************");

            owner.RegainFromMemo(memo);

            foreach (ContactPerson person in owner.ContactPersonList)
            {
                Console.WriteLine(person.Name + ":" + person.Phone);
            }
            Console.WriteLine("**************");
            Console.ReadKey();
        }
    }


    /// <summary>
    /// 联系人
    /// </summary>
    public class ContactPerson
    {
        public string Name { get; set; }

        public string Phone { get; set; }
    }


    /// <summary>
    /// 发起人
    /// </summary>
    public class PhoneOwner
    {
        public List<ContactPerson> ContactPersonList { get; set; } = new List<ContactPerson>();

        public PhoneOwner(List<ContactPerson> entities)
        {
            ContactPersonList.AddRange(entities);
        }


        public Memo CreateMemo()
        {
            return new Memo(ContactPersonList);
        }


        public void RegainFromMemo(Memo memo)
        {
            //这里一定要深拷贝
            ContactPersonList = memo.ContactPersonList.SerializeObject().DeserializeObject<List<ContactPerson>>();
        }
    }


    /// <summary>
    /// 备忘录
    /// </summary>
    public class Memo
    {
        public List<ContactPerson> ContactPersonList { get; set; }

        public Memo(List<ContactPerson> entities)
        {
            //这里一定要深拷贝
            ContactPersonList = new List<ContactPerson>(entities.SerializeObject().DeserializeObject<List<ContactPerson>>());
        }
    }
}
