using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace ReadyGamerOne.Const
{
    public class ConstStringAsset:ScriptableObject
    {
        private static ConstStringAsset _instance;
        public static ConstStringAsset Instance
        {
            get
            {

                if (!_instance)
                {
                    if(File.Exists("Assets/GlobalConstStrings.asset"))
                        _instance = UnityEditor.AssetDatabase.LoadAssetAtPath<ConstStringAsset>("Assets/GlobalConstStrings.asset");
                }
#if UNITY_EDITOR
                if (!_instance)
                {
                    _instance = CreateInstance<ConstStringAsset>();
                    UnityEditor.AssetDatabase.CreateAsset(_instance, "Assets/GlobalConstStrings.asset");
                }
#endif
                if (_instance == null)
                    throw new System.Exception("初始化失败");

                return _instance;
            }
        }

        public List<string> constStrings = new List<string>(); 
    }
}