namespace _04_抽象工厂
{
    public interface IFactory
    {
        Plant CreatePlant();
        Animal CreateAnimal();
    }


    //public abstract class Factory : IFactory
    //{
    //    public abstract Plant CreatePlant();

    //    public abstract Animal CreateAnimal();
    //}


    public class ChengduFactory : IFactory
    {
        public  Plant CreatePlant()
        {
            return new Vegetables();
        }

        public  Animal CreateAnimal()
        {
            return new Cow();
        }
    }


    public class ShehongFactory : IFactory
    {
        public  Plant CreatePlant()
        {
            return new Fruit();
        }

        public  Animal CreateAnimal()
        {
            return new Horse();
        }
    }
}
