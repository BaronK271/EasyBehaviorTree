// This script is generated by *NodeParamGenerator*
// Any modifications in this script will be lost after regeneration.
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;
using System.Reflection;

namespace EasyBehaviorTree.Creator
{
    public partial class NodeDefine : MonoBehaviour
    {
        // =============================================================================================================================

        [HideInInspector][SerializeField]
        public EnumParamSet enumParamSet = new EnumParamSet();
        [HideInInspector][SerializeField]
        public StringParamSet stringParamSet = new StringParamSet();
        [HideInInspector][SerializeField]
        public IntParamSet intParamSet = new IntParamSet();
        [HideInInspector][SerializeField]
        public FloatParamSet floatParamSet = new FloatParamSet();
        [HideInInspector][SerializeField]
        public BoolParamSet boolParamSet = new BoolParamSet();
        [HideInInspector][SerializeField]
        public StringArrayParamSet stringArrayParamSet = new StringArrayParamSet();
        [HideInInspector][SerializeField]
        public IntArrayParamSet intArrayParamSet = new IntArrayParamSet();
        [HideInInspector][SerializeField]
        public FloatArrayParamSet floatArrayParamSet = new FloatArrayParamSet();
        [HideInInspector][SerializeField]
        public BoolArrayParamSet boolArrayParamSet = new BoolArrayParamSet();

        // =============================================================================================================================

        private NodeDefine()
        {
            ensureCachedMappingsImpl = EnsureCachedMappings;
        }

        private void EnsureCachedMappings()
        {
            if(cachedMappings == null)
            {
                cachedMappings = new Dictionary<Type, NodeParamSetAndName>()
                {
                    // =============================================================================================================================

                    {typeof(Enum),new NodeParamSetAndName() { set = enumParamSet,name = "enumParamSet" } },
                    {typeof(string),new NodeParamSetAndName(){set=stringParamSet,name = "stringParamSet" } },
                    {typeof(int),new NodeParamSetAndName(){set=intParamSet,name = "intParamSet" } },
                    {typeof(float),new NodeParamSetAndName(){set=floatParamSet,name = "floatParamSet" } },
                    {typeof(bool),new NodeParamSetAndName(){set=boolParamSet,name = "boolParamSet" } },
                    {typeof(string[]),new NodeParamSetAndName(){set=stringArrayParamSet,name = "stringArrayParamSet" } },
                    {typeof(int[]),new NodeParamSetAndName(){set=intArrayParamSet,name = "intArrayParamSet" } },
                    {typeof(float[]),new NodeParamSetAndName(){set=floatArrayParamSet,name = "floatArrayParamSet" } },
                    {typeof(bool[]),new NodeParamSetAndName(){set=boolArrayParamSet,name = "boolArrayParamSet" } },

                    // =============================================================================================================================
                };
            }
        }
    }
}
