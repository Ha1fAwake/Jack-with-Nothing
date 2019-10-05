using System;
using UnityEngine;
#if UNITY_EDITOR

#endif
namespace LudumDare.Model
{
    [Serializable]
    public class BasicItem//:ScriptableObject
    {
            public int id;
            public string itemName;
            public string descriptions;
            public Sprite sprite;

            public override string ToString()
            {
                var text = "===<BaseItem>===\n";
                text += "ItemName: " + itemName + "\n";
                text += "Description: " + descriptions + "\n";
                text += "Sprite: " + sprite.name + "\n";
                return text;
            }
    }
}