using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{

	[Serializable]
	public class XAudioData : XBaseData
	{

		[SerializeField]
		[DefaultValue(0f)]
		public float At;

		[SerializeField]
		public string Clip = null;

		[SerializeField]
		public AudioChannel Channel = AudioChannel.Skill;
	}
}
