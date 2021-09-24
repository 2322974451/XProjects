using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{

	[Serializable]
	public class XFxData : XBaseData
	{

		public XFxData()
		{
			this.Follow = true;
			this.ScaleX = 1f;
			this.ScaleY = 1f;
			this.ScaleZ = 1f;
		}

		[SerializeField]
		public SkillFxType Type = SkillFxType.FirerBased;

		[SerializeField]
		[DefaultValue(0f)]
		public float At;

		[SerializeField]
		[DefaultValue(0f)]
		public float End;

		[SerializeField]
		public string Fx = null;

		[SerializeField]
		public string Bone = null;

		[SerializeField]
		[DefaultValue(1f)]
		public float ScaleX;

		[SerializeField]
		[DefaultValue(1f)]
		public float ScaleY;

		[SerializeField]
		[DefaultValue(1f)]
		public float ScaleZ;

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
		[DefaultValue(0f)]
		public float Target_OffsetX;

		[SerializeField]
		[DefaultValue(0f)]
		public float Target_OffsetY;

		[SerializeField]
		[DefaultValue(0f)]
		public float Target_OffsetZ;

		[SerializeField]
		[DefaultValue(true)]
		public bool Follow;

		[SerializeField]
		[DefaultValue(false)]
		public bool StickToGround;

		[SerializeField]
		[DefaultValue(0f)]
		public float Destroy_Delay;

		[SerializeField]
		[DefaultValue(false)]
		public bool Combined;

		[SerializeField]
		[DefaultValue(false)]
		public bool Shield;
	}
}
