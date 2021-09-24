using System;
using System.ComponentModel;
using UnityEngine;

namespace XUtliPoolLib
{

	[Serializable]
	public class XResultData : XBaseData
	{

		public XResultData()
		{
			this.Sector_Type = true;
		}

		[SerializeField]
		[DefaultValue(false)]
		public bool LongAttackEffect;

		[SerializeField]
		[DefaultValue(false)]
		public bool Attack_Only_Target;

		[SerializeField]
		[DefaultValue(false)]
		public bool Attack_All;

		[SerializeField]
		[DefaultValue(false)]
		public bool Mobs_Inclusived;

		[SerializeField]
		[DefaultValue(true)]
		public bool Sector_Type;

		[SerializeField]
		[DefaultValue(false)]
		public bool Rect_HalfEffect;

		[SerializeField]
		[DefaultValue(0)]
		public int None_Sector_Angle_Shift;

		[SerializeField]
		[DefaultValue(0f)]
		public float At;

		[SerializeField]
		[DefaultValue(0f)]
		public float Low_Range;

		[SerializeField]
		[DefaultValue(0f)]
		public float Range;

		[SerializeField]
		[DefaultValue(0f)]
		public float Scope;

		[SerializeField]
		[DefaultValue(0f)]
		public float Offset_X;

		[SerializeField]
		[DefaultValue(0f)]
		public float Offset_Z;

		[SerializeField]
		[DefaultValue(false)]
		public bool Loop;

		[SerializeField]
		[DefaultValue(false)]
		public bool Group;

		[SerializeField]
		[DefaultValue(0f)]
		public float Cycle;

		[SerializeField]
		[DefaultValue(0)]
		public int Loop_Count;

		[SerializeField]
		[DefaultValue(0)]
		public int Deviation_Angle;

		[SerializeField]
		[DefaultValue(0)]
		public int Angle_Step;

		[SerializeField]
		[DefaultValue(0f)]
		public float Time_Step;

		[SerializeField]
		[DefaultValue(0)]
		public int Group_Count;

		[SerializeField]
		[DefaultValue(0)]
		public int Token;

		[SerializeField]
		[DefaultValue(false)]
		public bool Clockwise;

		[SerializeField]
		public XLongAttackResultData LongAttackData;

		[SerializeField]
		[DefaultValue(false)]
		public bool Warning;

		[SerializeField]
		[DefaultValue(0)]
		public int Warning_Idx;

		[SerializeField]
		public XResultAffectDirection Affect_Direction = XResultAffectDirection.AttackDir;
	}
}
