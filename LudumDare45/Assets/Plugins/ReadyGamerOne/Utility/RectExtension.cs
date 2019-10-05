using UnityEditor;
using UnityEngine;

namespace ReadyGamerOne.Utility
{
    /// <summary>
    /// Rect 拓展类，用于编辑器拓展
    /// </summary>
    public static class RectExtension
    {

        #region 上下左右四部分

       public static Rect GetUp(this Rect rect,float end=.5f,float start=.0f)
       {
           return new Rect(rect.position+new Vector2(0,rect.size.y*start), 
               new Vector2(rect.size.x, rect.size.y* (end-start)));
       }

       public static Rect GetBottom(this Rect rect, float end = .5f, float start = .0f)
       {
           return new Rect(rect.position + new Vector2(0, rect.size.y * (1 - end)),
               new Vector2(rect.size.x, rect.size.y * (end - start)));
       }

       public static Rect GetRight(this Rect rect,float end = 0.5f,float start=0.0f)
       {
           return new Rect(rect.position + new Vector2(rect.size.x * (1-end), 0),
               new Vector2(rect.size.x * (end-start), rect.size.y));
       }

       public static Rect GetLeft(this Rect rect,float end =0.5f,float start=0.0f)
       {
           return new Rect(rect.position+new Vector2(rect.size.x*start,0),
               new Vector2(rect.size.x * (end-start), rect.size.y));
       }

       #endregion

        #region 获取指定行矩形区域

        public static Rect GetRectAtIndex(this Rect rect, int index)
        {
            float height = 0;
#if UNITY_EDITOR
            height = EditorGUIUtility.singleLineHeight;
#else
            height =16;
#endif
            
            return new Rect(rect.position + new Vector2(0, index * height),
                new Vector2(rect.size.x, height));
        }
        
        public static Rect GetRectFromIndex(this Rect rect, int index)
        {            
            float height = 0;
#if UNITY_EDITOR
            height = EditorGUIUtility.singleLineHeight;
#else
            height =16;
#endif
            return new Rect(rect.position+new Vector2(0,index*height),
                new Vector2(height,rect.y-index*height));

        }

        public static Rect GetRectFromIndexWithHeight(this Rect rect, ref int index, float height)
        {
                    
            float h = 0;
#if UNITY_EDITOR
            h = EditorGUIUtility.singleLineHeight;
#else
            h =16;
#endif
            var ans= new Rect(rect.position + new Vector2(0,  index * h),
                new Vector2(rect.size.x, height));

            index += Mathf.CeilToInt(height / h);
            
            return ans;
        }
        
        public static Rect GetRightPartAtIndex(this Rect rect, int index)
        {
            return rect.GetRectAtIndex(index).GetRight();
        }

        public static Rect GetLeftPartAtIndex(this Rect rect, int index)
        {
            return rect.GetRectAtIndex(index).GetLeft();
        }

        #endregion
        
    }
}