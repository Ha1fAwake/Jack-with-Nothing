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
    }
}