using System;
using UnityEngine;

namespace XUtliPoolLib
{

	[Serializable]
	public class XFxDataClip : XCutSceneClip
	{

		[SerializeField]
		public string Fx = null;

		[SerializeField]
		public int BindIdx = 0;

		[SerializeField]
		public string Bone = null;

		[SerializeField]
		public float Scale = 1f;

		[SerializeField]
		public bool Follow = true;

		[SerializeField]
		public float Destroy_Delay = 0f;

		[SerializeField]
		public float AppearX = 0f;

		[SerializeField]
		public float AppearY = 0f;

		[SerializeField]
		public float AppearZ = 0f;

		[SerializeField]
		public float Face = 0f;
	}
}
