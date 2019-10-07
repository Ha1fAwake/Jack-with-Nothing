using System;
using System.Collections;
using System.Collections.Generic;
using LudumDare.Model;
using LudumDare.Scripts;
using ReadyGamerOne.Const;
using UnityEngine;

public class ItemIdentity : MonoBehaviour
{
    public ConstStringChooser itemName;
    public event Action onAddToBag;
    public event Action onLeaveBag;
    public bool IsInBag { get; private set; } = false;
    public virtual BasicItem ItemInfo => ItemMgr.GetItem(itemName.StringValue);

    private void Start()
    {
        var rig = gameObject.AddComponent<Rigidbody2D>();
        rig.bodyType = RigidbodyType2D.Kinematic;
        rig.gravityScale = 0;
    }


    public virtual void OnAddToBag()
    {
        IsInBag = true;
        onAddToBag?.Invoke();
    }

    public virtual void OnLeaveBag()
    {
        IsInBag = false;
        onLeaveBag?.Invoke();
    }

    public virtual void UseOnTo(ItemIdentity identity)
    {
        if (identity)
        {
            foreach (var mergeInfo in ItemMgr.MergeInfos)
            {
                Debug.Log("Merge:  "+mergeInfo.SourId1+"   "+mergeInfo.SourId2);
                var list = mergeInfo.SourIds;
                if (list.Contains(ItemInfo.id) && list.Contains(identity.ItemInfo.id))
                {
                    global::BagData.MergeItem();
                }
            }
        }
    }

    private void OnEnable()
    {
        Debug.Log("生成");
        BossAi_2.aliveCount++;
    }

    private void OnDestroy()
    {
        Debug.Log("销毁");
        BossAi_2.aliveCount--;
    }
}
