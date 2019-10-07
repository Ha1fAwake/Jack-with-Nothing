using ReadyGamerOne.Global;
using ReadyGamerOne.Script;
using UnityEngine;

namespace LudumDare.Scripts
{
    public class GameMgr : BasicGameMgr
    {
        protected override void RefreshGlobalVar()
        {
            GlobalVar.G_Canvas = GameObject.Find("Canvas");
        }
    }
}