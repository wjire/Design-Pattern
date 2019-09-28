namespace 联系多个模式的组合
{
    /// <summary>
    /// 鹅工厂
    /// </summary>
    public abstract class AbstractGooseFactory
    {
        public abstract GooseAdapter CreateGoose();
    }


    public class GooseFactory : AbstractGooseFactory
    {
        public override GooseAdapter CreateGoose()
        {
            return new GooseAdapter(new Goose());
        }
    }
}
