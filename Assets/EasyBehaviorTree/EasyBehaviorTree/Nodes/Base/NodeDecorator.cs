using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace EasyBehaviorTree
{
    [Serializable]
    public abstract class NodeDecorator : NodeBase, IDecorator
    {

        protected IDecoratee mTarget;

        public IDecoratee Target { get => mTarget; 

#if UNITY_EDITOR

        set => mTarget = value; 
#endif
        }

        public virtual BTState PostUpdate()
        {
            return BTState.Success;
        }

        public virtual BTState PreUpdate()
        {
            return BTState.Success;
        }


    }
}