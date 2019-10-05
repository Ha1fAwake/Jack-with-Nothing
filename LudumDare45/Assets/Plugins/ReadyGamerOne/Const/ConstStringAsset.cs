using System.Collections.Generic;
using System.IO;
#if UNITY_EDITOR
using UnityEditor;
#endif
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
                    if (File.Exists("Assets/Resources/GlobalConstStrings.asset"))
                        _instance = Resources.Load<ConstStringAsset>("GlobalConstStrings");
                }
#if UNITY_EDITOR
                if (!_instance)
                {
                    _instance = CreateInstance<ConstStringAsset>();
                    var path = "Assets/Resources";
                    if (!Directory.Exists(path))
                        Directory.CreateDirectory(path);
                    AssetDatabase.CreateAsset(_instance, path+"/GlobalConstStrings.asset");
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