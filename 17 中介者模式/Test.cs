using System;
using System.Collections.Generic;

namespace _17_中介者模式
{
    public class Test
    {
        public static void TestMediator()
        {
            Mediator1 med = new Mediator1();
            Consumer1 c1 = new Consumer1("c1");
            Consumer1 c2 = new Consumer1("c2");
            Consumer1 c3 = new Consumer1("c3");
            med.AddConsumer(c1);
            med.AddConsumer(c2);
            med.AddConsumer(c3);
            c1.Send(med, "在坐的各位都是垃圾");
            c2.Send(med, c3, "你是垃圾");
        }
    }

    public abstract class Mediator
    {
        public List<Consumer> conList = new List<Consumer>();

        public void AddConsumer(Consumer con)
        {
            if (!conList.Contains(con))
            {
                conList.Add(con);
                con.SetMediator(this);
            }
        }

        public abstract void ReplayToSingle(Consumer to, string msg);

        public abstract void ReplayToAll(Consumer from, string msg);
    }


    public class Mediator1 : Mediator
    {

        public override void ReplayToSingle(Consumer to, string msg)
        {
            to.Receive(msg);
        }

        public override void ReplayToAll(Consumer from, string msg)
        {
            foreach (Consumer consumer in conList)
            {
                if (consumer == from)
                {
                    continue;
                }
                consumer.Receive(msg);
            }
        }
    }

    public abstract class Consumer
    {
        protected Mediator mediator;

        protected string Name { get; set; }

        public Consumer(string name)
        {
            Name = name;
        }

        public void SetMediator(Mediator med)
        {
            mediator = med;
        }

        public void Receive(string msg)
        {
            Console.WriteLine($"{Name} receive " + msg);
        }

        public void Send(Mediator med, string msg)
        {
            if (med == null)
            {
                return;
            }

            med.ReplayToAll(this, msg);
        }

        public void Send(Mediator med, Consumer to, string msg)
        {
            if (med == null)
            {
                return;
            }

            med.ReplayToSingle(to, msg);
        }
    }


    public class Consumer1 : Consumer
    {
        public Consumer1(string name) : base(name)
        {
        }
    }

    public class Consumer2 : Consumer
    {
        public Consumer2(string name) : base(name)
        {
        }
    }

    public class Consumer3 : Consumer
    {
        public Consumer3(string name) : base(name)
        {
        }
    }
}
