using System;
using System.Collections;
using System.Collections.Generic;
using LudumDare.Model;
using ReadyGamerOne.Const;
using UnityEngine;

public class ItemIdentity : MonoBehaviour
{
    public ConstStringChooser itemName;
    public event Action onAddToBag;
    
    public bool IsInBag { get; private set; } = false;
    public virtual BasicItem ItemInfo => ItemMgr.GetItem(itemName.StringValue);

    public virtual void OnAddToBag()
    {
        IsInBag = true;
        onAddToBag?.Invoke();
    }

    public virtual void OnLeaveBag()
    {
        IsInBag = false;
    }

    public virtual void UseOnTo(ItemIdentity identity)
    {
        
    }
}
