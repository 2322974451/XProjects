using System;
using UnityEngine;

namespace XUtliPoolLib
{

	[Serializable]
	public class XSubTitleDataClip : XCutSceneClip
	{

		[SerializeField]
		public string Context = null;

		[SerializeField]
		public float Duration = 45f;
	}
}
