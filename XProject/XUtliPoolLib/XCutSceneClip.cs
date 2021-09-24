using System;
using UnityEngine;

namespace XUtliPoolLib
{

	[Serializable]
	public abstract class XCutSceneClip
	{

		[SerializeField]
		public XClipType Type = XClipType.Actor;

		[SerializeField]
		public float TimeLineAt = 0f;
	}
}
