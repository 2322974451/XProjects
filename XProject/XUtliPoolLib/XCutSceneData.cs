using System;
using System.Collections.Generic;
using UnityEngine;

namespace XUtliPoolLib
{

	[Serializable]
	public class XCutSceneData
	{

		[SerializeField]
		public float TotalFrame = 0f;

		[SerializeField]
		public string CameraClip = null;

		[SerializeField]
		public string Name = null;

		[SerializeField]
		public string Script = null;

		[SerializeField]
		public string Scene = null;

		[SerializeField]
		public int TypeMask = -1;

		[SerializeField]
		public bool OverrideBGM = true;

		[SerializeField]
		public bool Mourningborder = true;

		[SerializeField]
		public bool AutoEnd = true;

		[SerializeField]
		public float Length = 0f;

		[SerializeField]
		public float FieldOfView = 45f;

		[SerializeField]
		public string Trigger = "ToEffect";

		[SerializeField]
		public bool GeneralShow = false;

		[SerializeField]
		public bool GeneralBigGuy = false;

		[SerializeField]
		public List<XActorDataClip> Actors = new List<XActorDataClip>();

		[SerializeField]
		public List<XPlayerDataClip> Player = new List<XPlayerDataClip>();

		[SerializeField]
		public List<XFxDataClip> Fxs = new List<XFxDataClip>();

		[SerializeField]
		public List<XAudioDataClip> Audios = new List<XAudioDataClip>();

		[SerializeField]
		public List<XSubTitleDataClip> SubTitle = new List<XSubTitleDataClip>();

		[SerializeField]
		public List<XSlashDataClip> Slash = new List<XSlashDataClip>();
	}
}
