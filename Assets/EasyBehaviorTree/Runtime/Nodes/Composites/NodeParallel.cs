using System.Collections.Generic;
using System;

namespace AillieoUtils.EasyBehaviorTree
{
    [Serializable]
    public class NodeParallel : NodeComposite
    {

        public enum ParallelStrategy
        {
            FailCertain,
            PassCertain,
        }

        [NodeParam]
        public readonly ParallelStrategy strategy;

        [NodeParam]
        public readonly int targetCount;

        private Dictionary<int, BTState> nodeStates = new Dictionary<int, BTState>();

        public override void Reset()
        {
            base.Reset();
            nodeStates.Clear();
        }

        public override void Cleanup()
        {

        }

        public override bool Validate(out string error)
        {
            bool ret = base.Validate(out error);
            if(ret)
            {
                if (targetCount > Children.Count)
                {
                    error = "Not enough child nodes";
                }
            }
            return error == null;
        }

        public override BTState Update(float deltaTime)
        {
            if (lastState != null)
            {
                return lastState.Value;
            }

            int nodeCount = Children.Count;
            for(int i = 0; i < nodeCount; ++i)
            {
                if (!nodeStates.ContainsKey(i))
                {
                    var ret = NodeTick(Children[i], deltaTime);
                    if(ret != BTState.Running)
                    {
                        nodeStates.Add(i, ret);
                    }
                }
            }

            return CheckTarget();
        }

        private BTState CheckTarget()
        {
            int pass = 0, fail = 0, rest = 0;
            foreach(var state in nodeStates)
            {
                if(state.Value == BTState.Success)
                {
                    pass++;
                }
                else if (state.Value == BTState.Failure)
                {
                    fail++;
                }
                else
                {
                    rest++;
                }
            }

            switch(strategy)
            {
                case ParallelStrategy.PassCertain:
                    if(pass >= targetCount)
                    {
                        lastState = BTState.Success;
                        return BTState.Success;
                    }
                    else if(rest == 0)
                    {
                        return BTState.Failure;
                    }
                    break;
                case ParallelStrategy.FailCertain:
                    if (fail >= targetCount)
                    {
                        lastState = BTState.Failure;
                        return BTState.Failure;
                    }
                    else if (rest == 0)
                    {
                        return BTState.Success;
                    }
                    break;
                default:
                    break;
            }

            return BTState.Running;
        }
    }
}
