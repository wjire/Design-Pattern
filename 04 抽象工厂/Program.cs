using System;

namespace _04_抽象工厂
{
    internal class Program
    {
        /*
         * 抽象工厂是横向扩展,它无法纵向扩展.致命缺陷是:工厂的职责无法扩展,一旦扩展,意味着所有的工厂都要修改代码.......
         * 所以,抽象工厂的使用需要确保工厂的职责稳定,不变.
         * 
         * 工厂方法是纵向扩展
         * 
         */

        /*
         *前面介绍的工厂方法模式中考虑的是一类产品的生产，如畜牧场只养动物、电视机厂只生产电视机、计算机软件学院只培养计算机软件专业的学生等。

同种类称为同等级，也就是说：工厂方法模式只考虑生产同等级的产品，但是在现实生活中许多工厂是综合型的工厂，能生产多等级（种类） 的产品，如农场里既养动物又种植物，电器厂既生产电视机又生产洗衣机或空调，大学既有软件专业又有生物专业等。

抽象工厂模式将考虑多等级产品的生产，将同一个具体工厂所生产的位于不同等级的一组产品称为一个产品族，
         *
         */


        /*
         * 下例中:动物和植物属于不同种类,也就是不同级.
         *
         */

        private static void Main(string[] args)
        {
            IFactory f = new ChengduFactory();
            Plant cdPlant = f.CreatePlant();
            Animal cdAnimal = f.CreateAnimal();
            cdPlant.Show();
            cdAnimal.Show();

            Console.WriteLine();
            IFactory shehong = new ShehongFactory();
            Plant shPlant = shehong.CreatePlant();
            Animal shAnimal = f.CreateAnimal();
            shPlant.Show();
            shAnimal.Show();
            Console.ReadKey();
        }
    }
}
