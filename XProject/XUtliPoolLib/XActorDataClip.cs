using System;
using UnityEngine;

namespace XUtliPoolLib
{

	[Serializable]
	public class XActorDataClip : XCutSceneClip
	{

		[SerializeField]
		public string Prefab = null;

		[SerializeField]
		public string Clip = null;

		[SerializeField]
		public float AppearX = 0f;

		[SerializeField]
		public float AppearY = 0f;

		[SerializeField]
		public float AppearZ = 0f;

		[SerializeField]
		public int StatisticsID = 0;

		[SerializeField]
		public bool bUsingID = false;

		[SerializeField]
		public bool bToCommonPool = false;

		[SerializeField]
		public string Tag = null;
	}
}
