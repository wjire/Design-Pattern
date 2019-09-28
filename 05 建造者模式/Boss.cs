namespace _05_建造者模式
{
    public class Boss
    {
        private IBuilder builder;

        public Boss(IBuilder builder)
        {
            this.builder = builder;
        }

        public Computer BuildComputer()
        {
            return new Computer
            {
                Cpu = builder.BuildCPU(),
                Disk = builder.BuildDisk(),
                Display = builder.BuildDisplay()
            };
        }
    }
}
