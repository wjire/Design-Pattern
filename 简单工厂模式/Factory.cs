using System;
using System.Linq;
using System.Reflection;

namespace 简单工厂模式
{
    public class Factory
    {
        private Factory()
        {

        }
        //public static Food Cook(FoodEnum food)
        //{
        //    switch (food)
        //    {
        //        case FoodEnum.藕:
        //            return new Ou();
        //        case FoodEnum.土豆:
        //            return new Tudou();
        //        default:
        //            return null;
        //    }
        //}
        private static string name = System.Configuration.ConfigurationManager.AppSettings["food"];

        public static Food Cook()
        {
            Assembly[] asses = AppDomain.CurrentDomain.GetAssemblies();
            System.Collections.Generic.IEnumerable<Type> types = asses.SelectMany(s => s.GetTypes().Where(w => w.GetInterfaces().Contains(typeof(Food)))).ToList();
            Type type = types.First(f => f.Name == name);


            //Assembly ass = Assembly.Load("简单工厂模式");
            //Type type = ass.GetType("简单工厂模式.Food");
            return Activator.CreateInstance(type) as Food;
        }
    }
}
