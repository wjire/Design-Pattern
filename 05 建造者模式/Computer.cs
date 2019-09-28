using System;

namespace _05_建造者模式
{
    public class Computer
    {
        public CPU Cpu { get; set; }

        public Disk Disk { get; set; }

        public Display Display { get; set; }

        public void Show()
        {
            Console.WriteLine("电脑组装完毕");
        }
    }

    public class Disk
    {

    }

    public class CPU
    {

    }

    public class Display
    {

    }


}
