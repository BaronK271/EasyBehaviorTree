using System;

namespace AillieoUtils.EasyBehaviorTree
{
    [Serializable]
    public class NodeSequence : NodeComposite
    {
        private int curIndex;

        public override void Reset()
        {
            base.Reset();
            curIndex = 0;
        }

        public override void Cleanup()
        {

        }


        public override BTState Update(float deltaTime)
        {
            if (lastState != null)
            {
                return lastState.Value;
            }

            int nodeCount = Children.Count;

            while (curIndex < nodeCount)
            {
                var node = Children[curIndex];
                var ret = NodeTick(node, deltaTime);
                switch (ret)
                {
                    case BTState.Success:
                        ++curIndex;
                        continue;
                    case BTState.Running:
                        return BTState.Running;
                    case BTState.Failure:
                        lastState = BTState.Failure;
                        return BTState.Failure;
                }

            }

            lastState = BTState.Success;
            return BTState.Success;
        }
    }
}
