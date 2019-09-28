using System;

namespace _18_状态者模式
{
    public class Test
    {
        public static void TestState()
        {
            ScoreContext context = new ScoreContext();
            context.GetState();
            context.AddScore(70);
            context.GetState();
            context.AddScore(25);
            context.GetState();
        }
    }


    public class ScoreContext
    {
        private AbstractState state;

        public ScoreContext()
        {
            state = new LowState(this);//给个默认的状态
        }

        public void SetState(AbstractState state)
        {
            this.state = state;
        }

        public void AddScore(decimal score)
        {
            state.Score += score;
            CheckState();
        }

        public void GetState()
        {
            state.GetState();
        }

        public void CheckState()
        {
            state.CheckState();
        }
    }



    public abstract class AbstractState
    {
        protected ScoreContext Context;

        public decimal Score { get; set; }

        public AbstractState(ScoreContext context)
        {
            Context = context;
        }

        protected AbstractState(AbstractState state)
        {
            Score = state.Score;
            Context = state.Context;
        }


        public abstract void CheckState();

        public void GetState()
        {
            Console.WriteLine($"分数:{Score},状态:{GetCurrentState()}");
        }

        protected abstract string GetCurrentState();
    }


    public class HighState : AbstractState
    {
        public override void CheckState()
        {

            if (Score < 60)
            {
                Context.SetState(new LowState(this));
            }
            else if (Score < 90)
            {
                Context.SetState(new MiddleState(this));
            }
        }

        protected override string GetCurrentState()
        {
            return "优秀";
        }


        public HighState(ScoreContext context) : base(context)
        {
        }

        public HighState(AbstractState state) : base(state)
        {
        }
    }

    public class MiddleState : AbstractState
    {

        public override void CheckState()
        {
            if (Score >= 90)
            {
                Context.SetState(new HighState(this));
            }
            else if (Score < 60)
            {
                Context.SetState(new LowState(this));
            }
        }

        protected override string GetCurrentState()
        {
            return "中等";
        }


        public MiddleState(ScoreContext context) : base(context)
        {
        }

        public MiddleState(AbstractState state) : base(state)
        {
        }
    }

    public class LowState : AbstractState
    {

        public override void CheckState()
        {
            if (Score >= 90)
            {
                Context.SetState(new HighState(this));
            }
            else if (Score >= 60)
            {
                Context.SetState(new MiddleState(this));
            }
        }

        protected override string GetCurrentState()
        {
            return "及格";
        }

        public LowState(ScoreContext context) : base(context)
        {
        }

        public LowState(AbstractState state) : base(state)
        {
        }
    }
}
