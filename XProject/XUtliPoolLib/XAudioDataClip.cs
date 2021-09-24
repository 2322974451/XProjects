using System;
using UnityEngine;

namespace XUtliPoolLib
{

	[Serializable]
	public class XAudioDataClip : XCutSceneClip
	{

		[SerializeField]
		public string Clip = null;

		[SerializeField]
		public int BindIdx = 0;

		[SerializeField]
		public AudioChannel Channel = AudioChannel.Skill;
	}
}
