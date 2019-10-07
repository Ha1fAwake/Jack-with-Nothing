using System;
using ReadyGamerOne.Const;
using UnityEngine;




namespace LudumDare.Model
{
    [Serializable]
    public class BasicItem//:ScriptableObject
    {
            public int id;
            public ConstStringChooser itemName;
            public string descriptions;
            public Sprite fontSprite;
            public Sprite infoSprite;
            public string exchangeCondition;
            [SerializeField] private GameObject prefab;

            public GameObject Prefab
            {
                get
                {
                    if(prefab==null)
                        throw new Exception("你还没有对这个物体预制体赋值："+ItemName);
                    return prefab;
                }
            }
            public string ItemName => itemName.StringValue;
            public override string ToString()
            {
                var text = "===<BaseItem>===\n";
                text += "ItemName: " + itemName.StringValue + "\n";
                text += "Description: " + descriptions + "\n";
                text += "InfoSprite: " + infoSprite.name + "\n";
                text += "FontSprite: " + fontSprite.name + "\n";
                return text;
            }
    }
}