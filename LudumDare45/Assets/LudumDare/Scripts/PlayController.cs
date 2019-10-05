using System;
using ReadyGamerOne.Script;
using ReadyGamerOne.Utility;
using UnityEngine;

namespace LudumDare.Scripts
{
    public class PlayController:AbstractCharacterController
    {
        public override Func<Vector2, bool> CanWalk => IfCanWalk;
        
        private bool IfCanWalk(Vector2 input)
        {
            return Mathf.Abs(input.x) >= 0.01f || Mathf.Abs(input.y) >= 0.01f;
        }


        protected override void Start()
        {
            base.Start();
            onWalk += (input, scale) =>
            {
                if (input.x > 0)
                    BagData.PlayerFace = BagData.Direction.left;
                else if (input.x < 0)
                    BagData.PlayerFace = BagData.Direction.right;
                if (input.y < 0)
                    BagData.PlayerFace = BagData.Direction.down;
                else if (input.y > 0)
                    BagData.PlayerFace = BagData.Direction.up;
            };
        }
    }
}