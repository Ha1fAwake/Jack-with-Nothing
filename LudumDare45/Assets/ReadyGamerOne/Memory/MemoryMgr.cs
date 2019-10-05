using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.Assertions;
using Object = UnityEngine.Object;

namespace ReadyGamerOne.MemorySystem
{
	/// <summary>
	/// 这个类提供关于内存的优化和管理
	/// 1、所有资源只会从Resources目录加载一次，再取的时候会从这个类的字典中取，尤其是一些预制体，经常频繁加载，使用这个类封装的Instantiate方法可以很好地解决这个问题
	/// 2、提供一些释放资源的接口
	/// 3、以后会提供关于AssetBubble的方法和接口
	/// 4、提供从Resources目录运行时加载一整个目录资源的接口，比如，加载某个文件夹下所有图片，音频
	/// </summary>
	public static  class MemoryMgr 
	{
		#region Private

		//private static List<AssetBundle> assetBundleList=new List<AssetBundle>();
        private static Dictionary<string, Object> sourceObjectDic;

        private static Dictionary<string, Object> SourceObjects
        {
        	get
        	{
        		if(sourceObjectDic==null)
        			sourceObjectDic=new Dictionary<string, Object>();
        		
        		return sourceObjectDic;
        	}
        	set { sourceObjectDic = value; }
        }

		#endregion


		/// <summary>
		/// 根据路径获取资源引用，如果原来加载过，不会重写加载
		/// </summary>
		/// <param name="path"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		/// <exception cref="Exception"></exception>
		public static T GetSourceFromResources<T>(string path)where T : Object
		{
			if (SourceObjects.ContainsKey(path))//加载过这个资源
			{
				if(SourceObjects[path]==null)
					throw new Exception("资源已经释放，但字典中引用亦然保留");
				
				var ans= SourceObjects[path] as T;
				if (ans == null)
					Debug.LogWarning("资源引用存在，但类型转化失败，小心bug");
				
				return ans;
			}
			else//初次加载资源
			{
				var source = Resources.Load<T>(path);
				if (source == null)
				{
					Debug.LogError("资源加载错误，错误路径："+path);
					return null;
				}
	
				SourceObjects.Add(path, source);
				return source;
			}

		}
		
		/// <summary>
		/// 释放通过Resources.Load方法加载来的对象
		/// </summary>
		/// <param name="path"></param>
		/// <param name="sourceObj"></param>
		/// <typeparam name="T"></typeparam>
		public static void ReleaseSourceFromResources<T>(string path, ref T sourceObj) where T : Object
		{
			if (!SourceObjects.ContainsKey(path))
			{
				Debug.LogWarning("资源字典中并不包含这个路径，注意路径是否错误：" + path);
				return;
			}

			var ans = SourceObjects[path] as T;
			if (ans == null)
			{
				Debug.LogWarning("该资源路径下Object转化为null，注意路径是否错误：" + path);
				
			}

			SourceObjects.Remove(path);
			Resources.UnloadAsset(ans);
			sourceObj = null;
		}
		public static void ReleaseSourceFromResources<T>(ref T sourceObj) where T : Object
		{
			if (!SourceObjects.ContainsValue(sourceObj))
			{
				Debug.LogWarning("资源字典中没有这个值，你真的没搞错？");
				return;
			}

			var list = new List<string>();
			foreach(var data in SourceObjects)
				if (data.Value == sourceObj)
				{
					Resources.UnloadAsset(data.Value);
					list.Add(data.Key);
				}
			foreach (var s in list)
			{
				SourceObjects.Remove(s);
			}
			list = null;
			
			
			sourceObj = null;
		}

		/// <summary>
		/// 释放游离资源
		/// </summary>
		public static void ReleaseUnusedAssets()
		{
			SourceObjects.Clear();
			Resources.UnloadUnusedAssets();
		}

		/// <summary>
		/// 根据路径实例化对象
		/// </summary>
		/// <param name="path"></param>
		/// <typeparam name="T"></typeparam>
		/// <returns></returns>
		public static T Instantiate<T>(string path)where T:Object
		{
			return Object.Instantiate(GetSourceFromResources<T>(path));
		}
		
		/// <summary>
		/// 实例化GameObject
		/// </summary>
		/// <param name="path"></param>
		/// <param name="parent"></param>
		/// <returns></returns>
		public static GameObject InstantiateGameObject(string path,Transform parent=null)
		{
			var source = GetSourceFromResources<GameObject>(path);
			Assert.IsTrue(source);
			return Object.Instantiate(source,parent);
		}
		public static GameObject InstantiateGameObject(string path, Vector3 pos, Quaternion quaternion, Transform parent = null)
		{
			var source = GetSourceFromResources<GameObject>(path);
			Assert.IsTrue(source);
			return Object.Instantiate(source,pos,quaternion,parent);
		}
		
		
		
		/// <summary>
		/// 从Resources目录中动态加载指定目录下所有内容
		/// </summary>
		/// <param name="nameClassType">目录下所有资源的名字要作为一个静态类的public static 成员，这里传递 这个静态类的Type</param>
		/// <param name="dirPath">从Resources开始的根目录，比如“Audio/"</param>
		/// <param name="onLoadAsset">加载资源时调用的委托，不能为空</param>
		/// <typeparam name="TAssetType">加载资源的类型</typeparam>
		/// <exception cref="Exception">委托为空会抛异常</exception>
		public static void LoadAssetFromResourceDir<TAssetType>(Type nameClassType, string dirPath = "",Action<string,TAssetType> onLoadAsset=null)
			where TAssetType : Object
		{
			var infoList = nameClassType.GetFields(BindingFlags.Static|BindingFlags.Public);
			foreach (var fieldInfo in infoList)
			{
				string assetName = fieldInfo.GetValue(null) as string;
				
				var res = GetSourceFromResources<TAssetType>(dirPath +assetName);
				
				if(onLoadAsset==null)
					throw new Exception("onLoadAsset为 null, 那你加载资源干啥？？ ");
                
				onLoadAsset.Invoke(assetName, res);
			}
		}
    }
}

