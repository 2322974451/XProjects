using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{

	[Serializable]
	public class XWarningData : XBaseData
	{

		public XWarningData()
		{
			this.Scale = 1f;
		}

		[SerializeField]
		public XWarningType Type = XWarningType.Warning_None;

		[SerializeField]
		[DefaultValue(0f)]
		public float At;

		[SerializeField]
		[DefaultValue(0f)]
		public float FxDuration;

		[SerializeField]
		[DefaultValue(0f)]
		public float OffsetX;

		[SerializeField]
		[DefaultValue(0f)]
		public float OffsetY;

		[SerializeField]
		[DefaultValue(0f)]
		public float OffsetZ;

		[SerializeField]
		public string Fx = null;

		[SerializeField]
		[DefaultValue(1f)]
		public float Scale = 1f;

		[SerializeField]
		[DefaultValue(false)]
		public bool Mobs_Inclusived;

		[SerializeField]
		[DefaultValue(0)]
		public int MaxRandomTarget;

		[SerializeField]
		[DefaultValue(false)]
		public bool RandomWarningPos;

		[SerializeField]
		[DefaultValue(0)]
		public float PosRandomRange;

		[SerializeField]
		[DefaultValue(0)]
		public int PosRandomCount;
	}
}
