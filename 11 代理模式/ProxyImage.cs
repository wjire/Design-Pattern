using System;
using System.Threading;
using System.Threading.Tasks;

namespace _11_代理模式
{

    public interface IImage
    {
        void Paint();
    }

    public class RealImage : IImage
    {
        public void Paint()
        {
            Console.WriteLine("画真实的画");
        }
    }



    public class ProxyImage: IImage
    {
        private RealImage _realImage;

      
        public void Paint()
        {
            Console.WriteLine("先画个代理画");
            Task.Run(() =>
            {
                Thread.Sleep(3000); //模拟创建真实对象非常耗时
                _realImage = new RealImage();
                _realImage.Paint();
            });
        }
    }
}
