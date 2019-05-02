using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;
using System.Linq;
using System.Text;

namespace EasyBehaviorTree.Creator
{
    [DisallowMultipleComponent]
    public class NodeDefine : MonoBehaviour
    {
        [SerializeField][HideInInspector]
        private string nodeFullName;
        [SerializeField][HideInInspector]
        private string assemblyName;

        [SerializeField][HideInInspector]
        private string displayName;
        [SerializeField][HideInInspector]
        private string nodeDescription;

        // =============================================================================================================================
        [HideInInspector][SerializeField]
        public StringParamSet stringParamSet = new StringParamSet();
        [HideInInspector][SerializeField]
        public FloatParamSet floatParamSet = new FloatParamSet();
        [HideInInspector][SerializeField]
        public IntParamSet intParamSet = new IntParamSet();
        [HideInInspector][SerializeField]
        public BoolParamSet boolParamSet = new BoolParamSet();
        [HideInInspector][SerializeField]
        public EnumParamSet enumParamSet = new EnumParamSet();
        // =============================================================================================================================

        
        public static FieldInfo[] GetNodeParamFields(Type type)
        {
            return type.GetFields(BindingFlags.Public| BindingFlags.NonPublic|BindingFlags.Instance)
            .Where(pi => pi.GetCustomAttribute<NodeParamAttribute>(false) != null).ToArray();
        }

        public NodeBase CreateNode()
        {
            Assembly ass = Assembly.Load(assemblyName);
            if(ass != null)
            {
                Type t = ass.GetType(nodeFullName);
                if (t != null)
                {
                    NodeBase node = Activator.CreateInstance(t) as NodeBase;
                    if(node != null)
                    {
                        node.name = displayName;
                        List<string> paramInfo = new List<string>();

                        var fields = GetNodeParamFields(t);

                        foreach (var field in fields)
                        {
                            // =============================================================================================================================
                            stringParamSet.TrySetFieldForType(field, node);
                            floatParamSet.TrySetFieldForType(field, node);
                            intParamSet.TrySetFieldForType(field, node);
                            boolParamSet.TrySetFieldForType(field, node);
                            enumParamSet.TrySetFieldForType(field, node);
                            // =============================================================================================================================

                            paramInfo.Add(field.Name);
                            string value = Convert.ToString(field.GetValue(node));
                            paramInfo.Add(value != null ? value : string.Empty);
                        }
                        node.paramInfo = paramInfo.ToArray();
                    }

                    return node;
                }
            }
            return null;
        }

        public bool IsRoot()
        {
            return transform.parent == null;
        }
    }
}
