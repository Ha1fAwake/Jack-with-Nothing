using System.Collections;
using System.Collections.Generic;
using LudumDare.Model;
using ReadyGamerOne.Const;
using UnityEngine;

public class ItemIdentity : MonoBehaviour
{
    public ConstStringChooser itemName;

    public BasicItem ItemInfo => ItemMgr.GetItem(itemName.StringValue);

}
