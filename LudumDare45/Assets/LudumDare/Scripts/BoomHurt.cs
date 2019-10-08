using System;
using ReadyGamerOne.Common;
using ReadyGamerOne.Const;
using ReadyGamerOne.Utility;
using UnityEngine;

namespace LudumDare.Scripts
{
    public class BoomHurt : TriggerHurt
    {
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            base.OnTriggerEnter2D(other);

            if (transform.IsChildOf(other.transform))
                return;

            var iden = other.GetComponent<ItemIdentity>();
            if (iden)
            {
                if (iden is BoomIdentity)
                    return;
                Destroy(other.gameObject);
            }
        }


    }
}