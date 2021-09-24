using System;
using UnityEngine;

namespace XUtliPoolLib
{

	public class XAnimationPool
	{

		public static XAnimationClip Create()
		{
			return ScriptableObject.CreateInstance<XAnimationClip>();
		}

		public static XAnimationClip Get()
		{
			return XAnimationPool.s_Pool.Get();
		}

		public static void Release(XAnimationClip toRelease)
		{
			bool flag = toRelease != null;
			if (flag)
			{
				toRelease.Reset();
			}
			XAnimationPool.s_Pool.Release(toRelease);
		}

		private static readonly ObjectPool<XAnimationClip> s_Pool = new ObjectPool<XAnimationClip>(new ObjectPool<XAnimationClip>.CreateObj(XAnimationPool.Create), null, null);
	}
}
