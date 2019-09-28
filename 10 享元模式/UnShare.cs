namespace _10_享元模式
{
    /// <summary>
    /// 不能共享的部分
    /// </summary>
    public class UnShare
    {
        private string _info;

        public UnShare(string info)
        {
            _info = info;
        }

        public string GetInfo()
        {
            return _info;
        }

        public void SetInfo(string info)
        {
            _info = info;
        }
    }
}
