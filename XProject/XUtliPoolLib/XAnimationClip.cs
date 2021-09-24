using System;
using UnityEngine;

namespace XUtliPoolLib
{

	public class XAnimationClip : ScriptableObject
	{

		public void Reset()
		{
			this.clip = null;
			this.length = 0f;
		}

		public int GetInstanceID()
		{
			return (this.clip == null) ? 0 : this.clip.GetInstanceID();
		}

		public AnimationClip clip;

		public float length;
	}
}
