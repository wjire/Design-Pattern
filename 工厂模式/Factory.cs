namespace 工厂方法模式
{
    public abstract class Factory
    {
        public abstract Food Cook();
    }

    public class OuFactory : Factory
    {
        public override Food Cook()
        {
            return new Ou();
        }
    }

    public class TudouFactory : Factory
    {
        public override Food Cook()
        {
            return new Tudou();
        }
    }
}
