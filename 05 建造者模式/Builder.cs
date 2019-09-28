using System;

namespace _05_建造者模式
{

    public interface IBuilder
    {
        Computer Computer { get;  set; }

        Computer GetComputer();

        CPU BuildCPU();

        Disk BuildDisk();

        Display BuildDisplay();
    }


    public class Builder1 : IBuilder
    {

        public Computer Computer { get; set; }

        public Computer GetComputer()
        {
            return Computer;
        }

        public CPU BuildCPU()
        {
            Console.WriteLine("组装CPU");
            return new CPU();
        }

        public Disk BuildDisk()
        {
            Console.WriteLine("组装Disk");
            return new Disk();
        }

        public Display BuildDisplay()
        {
            Console.WriteLine("组装Display");
            return new Display();
        }
    }
}
