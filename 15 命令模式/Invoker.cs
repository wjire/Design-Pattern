using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _15_命令模式
{
    /// <summary>
    /// 命令的执行者
    /// </summary>
    public class Invoker
    {
        private readonly BaseCommand _baseCommand;

        public Invoker(BaseCommand baseCommand)
        {
            this._baseCommand = baseCommand;
        }

        public void Action()
        {
            this._baseCommand.Execute();
        }
    }
}
