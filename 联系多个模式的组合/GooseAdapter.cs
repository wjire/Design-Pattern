namespace 联系多个模式的组合
{

    /// <summary>
    /// 鹅的适配器
    /// </summary>
    public class GooseAdapter : IQuackable
    {
        private readonly Goose _goose;
        public GooseAdapter(Goose goose)
        {
            _goose = goose;
        }


        public void Quack()
        {
            _goose.Honk();
        }

        public void RegisterObserver(IObserver observer)
        {
            throw new System.NotImplementedException();
        }

        public void NotifyObserver()
        {
            throw new System.NotImplementedException();
        }
    }
}
