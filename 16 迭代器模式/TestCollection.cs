using System.Collections.Generic;

namespace _16_迭代器模式
{

    /// <summary>
    /// 聚合类基类
    /// </summary>
    public interface ICollection
    {
        IIterator GetIterator();
    }

    /// <summary>
    /// 迭代器基类
    /// </summary>
    public interface IIterator
    {
        bool MoveNext();
        object GetCurrent();
        void Next();
        void Reset();
    }


    public class TestCollection : ICollection
    {
        private List<Person> _personList;

        public TestCollection()
        {
            _personList = new List<Person>
            {
                new Person {Id = 1, Name = "wjire1"},
                new Person {Id = 2, Name = "wjire2"},
                new Person {Id = 3, Name = "wjire3"},
                new Person {Id = 4, Name = "wjire4"},
                new Person {Id = 5, Name = "wjire5"},
            };
        }


        public IIterator GetIterator()
        {
            return new TestIterator(this);
        }

        public Person GetElement(int index)
        {
            return _personList[index];
        }

        public int Length => _personList.Count;
    }



    public class TestIterator : IIterator
    {
        private readonly TestCollection _testCollection;
        private int _index;
        public TestIterator(TestCollection testCollection)
        {
            _testCollection = testCollection;
        }

        public bool MoveNext()
        {
            if (_index < _testCollection.Length)
            {
                return true;
            }
            return false;
        }

        public object GetCurrent()
        {
            return _testCollection.GetElement(_index);
        }

        public void Next()
        {
            _index++;
        }

        public void Reset()
        {
            _index = 0;
        }
    }
}
