﻿using System;

namespace 工厂方法模式
{
    internal class Program
    {
        /*
         * 工厂方法模式定义个了一个创建对象的接口,但由子类决定要实例化的类是哪一个.
         * 但这种决定,并不是说在运行时由子类本身决定,而是选择了哪个子类,就决定了实例化的是哪个类.
         *
         *
         *缺点: 一个工厂只能创建一个类的实例         
         */

        /*
                 *模式的应用场景
        工厂方法模式通常适用于:客户只知道创建产品的工厂名，而不知道具体的产品名。如 TCL电视工厂、海信电视工厂等。
        创建对象的任务由多个具体子工厂中的某一个完成，
        而抽象工厂只提供创建产品的接口,客户不关心创建产品的细节，只关心产品的品牌(工厂就代表品牌)
                 *
                 * 抽象工厂强调品牌的概念!!!
                 */
                 /*
                 *模式的扩展
        抽象工厂模式的扩展有一定的“开闭原则”倾斜性：
        当增加一个新的产品族时只需增加一个新的具体工厂，不需要修改原代码，满足开闭原则。
        当产品族中需要增加一个新种类的产品时，则所有的工厂类都需要进行修改，不满足开闭原则。

        另一方面，当系统中只存在一个等级结构的产品时，抽象工厂模式将退化到工厂方法模式。
         *
         */


        private static void Main(string[] args)
        {

            //工厂方法模式是,选择了什么工厂子类,就决定了创建的是哪个类的实例.
            Factory tuDouFactory = new TudouFactory();
            tuDouFactory.Cook().Print();

            Factory ouFactory = new OuFactory();
            ouFactory.Cook().Print();
            Console.ReadKey();
        }
    }
}
