using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace EasyBehaviorTree
{
    [Serializable]
    public class NodeSelector : NodeComposite
    {
        public override void Destroy()
        {

        }

        public override BTState Update()
        {
            BTState ret = BTState.Failure;
            foreach (var node in Children)
            {
                if (TickNode(node) == BTState.Success)
                {
                    ret = BTState.Success;
                    break;
                }
            }
            return ret;
        }
    }
}